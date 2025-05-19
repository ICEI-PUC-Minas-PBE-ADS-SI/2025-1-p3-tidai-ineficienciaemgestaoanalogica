using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public class PedidoService
{
    private readonly AppDbContext _context;

    public PedidoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pedido> CriarPedidoAsync(CriarPedidoDTO dto)
    {
        var pedido = new Pedido
        {
            MesaId = dto.MesaId,
            FuncionarioId = dto.FuncionarioId,
            Observacao = dto.Observacao,
            DataHoraInicio = DateTime.Now,
            ItensPedido = dto.ItensPedido.Select(ip => new ItemPedido{
                ProdutoId = ip.ProdutoId,
                Quantidade = ip.Quantidade,
                PrecoUnitario = ip.PrecoUnitario,
                ExtrasSelecionados = ip.ExtrasSelecionados.Select(extraId => new ExtraSelecionado
                {
                    ExtraId = extraId,
                }).ToList()
            }).ToList()
        };

        pedido.PrecoFinal = pedido.ItensPedido.Select(ip => ip.PrecoUnitario * ip.Quantidade).Sum();
        _context.Pedidos.Add(pedido);

        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<Pedido?> AtualizarPedidoAsync(AtualizarPedidoDTO dto)
    {
        var pedido = await _context.Pedidos
            .Include(p => p.ItensPedido!)
                .ThenInclude(ip => ip.ExtrasSelecionados)
            .FirstOrDefaultAsync(p => p.Id == dto.Id);

        if (pedido == null) return null;

        pedido.MesaId = dto.MesaId;
        pedido.FuncionarioId = dto.FuncionarioId;
        pedido.Observacao = dto.Observacao;

        _context.ItensPedido.RemoveRange(pedido.ItensPedido!);

        var novosItens = new List<ItemPedido>();

        foreach(var ip in dto.ItensPedido)
        {
            var novoItem = new ItemPedido
            {
                PedidoId = pedido.Id,
                ProdutoId = ip.ProdutoId,
                Quantidade = ip.Quantidade,
                PrecoUnitario = ip.PrecoUnitario,
                ExtrasSelecionados = new List<ExtraSelecionado>()
            };

            var extrasValidos = await _context.Extras
                .Where(e => ip.ExtrasSelecionados.Contains(e.Id) && e.ProdutoId == ip.ProdutoId)
                .Select(e => e.Id)
                .ToListAsync();

            novoItem.ExtrasSelecionados = extrasValidos
                .Select(extraId => new ExtraSelecionado { ExtraId = extraId })
                .ToList();
            
            novosItens.Add(novoItem);
        }

        pedido.ItensPedido = novosItens;

        pedido.PrecoFinal = pedido.ItensPedido.Select(ip => ip.PrecoUnitario * ip.Quantidade).Sum();

        await _context.SaveChangesAsync();
        return pedido;
    }


    public async Task<RelatorioPedidoDTO?> FecharPedidoAsync(int id)
    {
        var pedido = await _context.Pedidos
            .Include(p => p.Mesa!)
            .Include(p => p.Funcionario!)
            .Include(p => p.ItensPedido!)
                .ThenInclude(i => i.Produto!)
            .Include(p => p.ItensPedido!)
                .ThenInclude(i => i.ExtrasSelecionados ?? new List<ExtraSelecionado>())
                .ThenInclude(e => e.Extra)
            .FirstOrDefaultAsync(p => p.Id == id);

        if(pedido == null)
            return null;

        foreach (var i in pedido.ItensPedido!)
        {
            Console.WriteLine(i.PrecoUnitario);
            Console.WriteLine(i.Produto!.Nome);
            Console.WriteLine(i.Quantidade);
            Console.WriteLine(i.ExtrasSelecionados);
        }

        var relatorio = new RelatorioPedido
        {
            DataHoraInicio = pedido.DataHoraInicio,
            DataHoraFim = DateTime.Now,
            NomeMesa = pedido.Mesa?.Nome ?? "Desconhecido",
            NomeFuncionario = pedido.Funcionario?.Nome ?? "Desconhecido",
            PrecoFinal = pedido.PrecoFinal,
            Itens = pedido.ItensPedido?.Select(i => new ItemRelatorioPedido{
                PrecoUnitario = i.PrecoUnitario,
                NomeProduto = i.Produto?.Nome ?? "Produto Removido",
                Quantidade = i.Quantidade,
                ExtrasSelecionados = i.ExtrasSelecionados?
                    .Select(e => e.Extra?.Nome ?? "Extra removido")
                    .ToList() ?? new List<string>()
            }).ToList() ?? new List<ItemRelatorioPedido>()
        };

        _context.RelatorioPedidos.Add(relatorio);
        _context.Pedidos.Remove(pedido);

        await _context.SaveChangesAsync();

        return MapearRelatorioPedido(relatorio);
    }

    public async Task<PedidoDTO?> MapearPedidoResponse(int id)
    {
        var pedido = await _context.Pedidos
            .Include(p => p.ItensPedido!)
                .ThenInclude(ip => ip.Produto!)
                    .ThenInclude(p => p.Extras ?? new List<Extra>())
            .Include(p => p.ItensPedido!)
                .ThenInclude(ip => ip.ExtrasSelecionados)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pedido == null)
            return null;

        return new PedidoDTO
        {
            Id = pedido.Id,
            MesaId = pedido.MesaId,
            FuncionarioId = pedido.FuncionarioId,
            Observacao = pedido.Observacao,
            DataHoraInicio = pedido.DataHoraInicio,
            DataHoraFim = pedido.DataHoraFim,
            PrecoFinal = pedido.PrecoFinal,
            ItensPedido = pedido.ItensPedido?.Select(ip => new ItemPedidoDTO
            {
                Quantidade = ip.Quantidade,
                PrecoUnitario = ip.PrecoUnitario,
                ExtrasSelecionados = ip.ExtrasSelecionados?.Select(e => e.ExtraId).ToList() ?? new(),
                Produto = ip.Produto != null ? new ProdutoDTO
                {
                    Id = ip.Produto.Id,
                    Nome = ip.Produto.Nome,
                    Descricao = ip.Produto.Descricao,
                    Preco = ip.Produto.Preco,
                    Foto = ip.Produto.Foto,
                    CategoriaId = ip.Produto.CategoriaId,
                    Extras = ip.Produto.Extras != null ? ip.Produto.Extras.Select(e => new ExtraDTO
                    {
                        Id = e.Id,
                        Nome = e.Nome,
                        PrecoAdicional = e.PrecoAdicional
                    }).ToList() : new List<ExtraDTO>()
                } : new ProdutoDTO()
            }).ToList() ?? new()
        };
    }

    public RelatorioPedidoDTO MapearRelatorioPedido(RelatorioPedido relatorio)
    {
        return new RelatorioPedidoDTO
        {
            Id = relatorio.Id,
            NomeMesa = relatorio.NomeMesa ?? "",
            NomeFuncionario = relatorio.NomeFuncionario ?? "",
            DataHoraInicio = relatorio.DataHoraInicio,
            DataHoraFim = relatorio.DataHoraFim,
            PrecoFinal = relatorio.PrecoFinal,
            Itens = relatorio.Itens?.Select(i => new ItemRelatorioPedidoDTO 
            {
                NomeProduto = i.NomeProduto,
                Quantidade = i.Quantidade,
                PrecoUnitario = i.PrecoUnitario,
                Extras = i.ExtrasSelecionados
            }).ToList() ?? new List<ItemRelatorioPedidoDTO>()
        };
    }
}