using Microsoft.AspNetCore.SignalR;

public class PedidoHub : Hub
{
    public async Task EnviarAtualizacao(string mensagem)
    {
        await Clients.All.SendAsync("Receber atualização", mensagem);
    }
}