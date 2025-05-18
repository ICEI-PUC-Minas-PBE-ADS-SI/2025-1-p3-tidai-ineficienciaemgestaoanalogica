import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { VerPedidosComponent } from './components/ver-pedidos/ver-pedidos.component';
import { FazerPedidosComponent } from './components/fazer-pedidos/fazer-pedidos.component';
import { RelatoriosComponent } from './components/relatorios/relatorios.component';
import { GerenciarComponent } from './components/gerenciar/gerenciar.component';
import { HomeComponent } from './components/home/home.component';
import { ListaCategoriasComponent } from './components/ver-pedidos/atualizar-pedido/lista-categorias/lista-categorias.component';
import { AtualizarPedidoComponent } from './components/ver-pedidos/atualizar-pedido/atualizar-pedido.component';
import { authGuard } from './guards/auth.guard';
import { roleGuard } from './guards/role.guard';
import { NaoAutorizadoComponent } from './components/auth/nao-autorizado/nao-autorizado.component';
import { LoginComponent } from './components/auth/login/login.component';
import { FecharPedidoComponent } from './components/ver-pedidos/fechar-pedido/fechar-pedido.component';
import { ModalAvisoComponent } from './components/modal-aviso/modal-aviso.component';
import { RelatorioPedidoComponent } from './components/ver-pedidos/fechar-pedido/relatorio-pedido/relatorio-pedido.component';
import { PedidoCriacaoComponent } from './components/fazer-pedidos/pedido-criacao/pedido-criacao.component';
import { DiarioComponent } from './components/relatorios/diario/diario.component';
import { PeriodoComponent } from './components/relatorios/periodo/periodo.component';
import { RelatorioComponent } from './components/relatorios/diario/relatorio/relatorio.component';
import { RelatorioPeriodoComponent } from './components/relatorios/periodo/relatorio-periodo/relatorio-periodo.component';
import { IndividualComponent } from './components/relatorios/individual/individual.component';
import { GerenciarProdutosComponent } from './components/gerenciar/gerenciar-produtos/gerenciar-produtos.component';
import { GerenciarFuncionariosComponent } from './components/gerenciar/gerenciar-funcionarios/gerenciar-funcionarios.component';
import { GerenciarMesasComponent } from './components/gerenciar/gerenciar-mesas/gerenciar-mesas.component';
import { GerenciarListaCategoriasComponent } from './components/gerenciar/gerenciar-produtos/gerenciar-lista-categorias/gerenciar-lista-categorias.component';
import { GerenciarListaCategoriaComponent } from './components/gerenciar/gerenciar-produtos/gerenciar-lista-categorias/gerenciar-lista-categoria/gerenciar-lista-categoria.component';
import { CriarFuncionarioComponent } from './components/gerenciar/gerenciar-funcionarios/criar-funcionario/criar-funcionario.component';
import { EditarFuncionarioComponent } from './components/gerenciar/gerenciar-funcionarios/editar-funcionario/editar-funcionario.component';
import { EditarProdutoComponent } from './components/gerenciar/gerenciar-produtos/gerenciar-produto/editar-produto/editar-produto.component';
import { AdicionarProdutoComponent } from './components/gerenciar/gerenciar-produtos/gerenciar-produto/adicionar-produto/adicionar-produto.component';

export const routes: Routes = [
    { 
        path: "", 
        component: HomeComponent, 
        canActivate: [authGuard] 
    },
    { 
        path: "login", 
        component: LoginComponent 
    },
    { 
        path: "ver-pedidos", 
        component: VerPedidosComponent, 
        canActivate: [authGuard]
    },
    { 
        path: "ver-pedidos/atualizar/:mesaId", 
        component: AtualizarPedidoComponent, 
        canActivate: [authGuard]
    },
    { 
        path: "ver-pedidos/fechar/:mesaId", 
        component: FecharPedidoComponent, 
        canActivate: [authGuard]
    },
    {
        path: "ver-pedidos/fechar/:mesaId/relatorio",
        component: RelatorioPedidoComponent,
        canActivate: [authGuard]
    },
    { 
        path: "fazer-pedidos", 
        component: FazerPedidosComponent, 
        canActivate: [authGuard] 
    },
    {
        path: "fazer-pedidos/:mesaId",
        component: PedidoCriacaoComponent,
        canActivate: [authGuard]
    },
    { 
        path: "relatorios", 
        component: 
        RelatoriosComponent, 
        canActivate: [authGuard, roleGuard], 
        data: {
            roles: ['Gerente']
        } 
    },
    {
        path: "relatorios/diario",
        component: DiarioComponent,
        canActivate: [authGuard, roleGuard],
        data: {roles: ['Gerente']}
    },
    {
        path: "relatorios/diario/:dia",
        component: RelatorioComponent, 
        canActivate: [authGuard, roleGuard],
        data: {roles: ['Gerente']}
    },
    {
        path: "relatorios/periodo",
        component: PeriodoComponent,
        canActivate: [authGuard, roleGuard],
        data: {roles: ['Gerente']}
    },
    {
        path: "relatorios/periodo/:diaInicio/:diaFim",
        component: RelatorioPeriodoComponent, 
        canActivate: [authGuard, roleGuard],
        data: {roles: ['Gerente']}
    },
    {
        path: "relatorios/individual/:id",
        component: IndividualComponent,
        canActivate: [authGuard, roleGuard],
        data: {roles: ['Gerente']}
    },
    { 
        path: "gerenciar", 
        component: GerenciarComponent, 
        canActivate: [authGuard, roleGuard], 
        data: {roles: ['Gerente']} 
    },
    { 
        path: "gerenciar/produtos", 
        component: GerenciarProdutosComponent, 
        canActivate: [authGuard, roleGuard], 
        data: {roles: ['Gerente']} 
    },
    { 
        path: "gerenciar/produtos/lista-categoria", 
        component: GerenciarListaCategoriaComponent, 
        canActivate: [authGuard, roleGuard], 
        data: {roles: ['Gerente']} 
    },
    { 
        path: "gerenciar/produtos/adicionar", 
        component: AdicionarProdutoComponent, 
        canActivate: [authGuard, roleGuard], 
        data: {roles: ['Gerente']} 
    },
    { 
        path: "gerenciar/produtos/editar/:produtoId", 
        component: EditarProdutoComponent, 
        canActivate: [authGuard, roleGuard], 
        data: {roles: ['Gerente']} 
    },
    { 
        path: "gerenciar/funcionarios", 
        component: GerenciarFuncionariosComponent, 
        canActivate: [authGuard, roleGuard], 
        data: {roles: ['Gerente']} 
    },
    { 
        path: "gerenciar/funcionarios/criar", 
        component: CriarFuncionarioComponent, 
        canActivate: [authGuard, roleGuard], 
        data: {roles: ['Gerente']} 
    },
    { 
        path: "gerenciar/funcionarios/editar/:funcionarioId", 
        component: EditarFuncionarioComponent, 
        canActivate: [authGuard, roleGuard], 
        data: {roles: ['Gerente']} 
    },
    { 
        path: "gerenciar/mesas", 
        component: GerenciarMesasComponent, 
        canActivate: [authGuard, roleGuard], 
        data: {roles: ['Gerente']} 
    },
    { 
        path: "nao-autorizado", 
        component: NaoAutorizadoComponent 
    }
];
