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

export const routes: Routes = [
    { path: "", component: HomeComponent, canActivate: [authGuard] },
    { path: "login", component: LoginComponent },
    { path: "ver-pedidos", component: VerPedidosComponent, canActivate: [authGuard]},
    { path: "atualizar-pedidos/:mesaId", component: AtualizarPedidoComponent, canActivate: [authGuard]},
    { path: "fazer-pedidos", component: FazerPedidosComponent, canActivate: [authGuard] },
    { path: "relatorios", component: RelatoriosComponent, canActivate: [authGuard, roleGuard], data: {roles: ['Gerente']} },
    { path: "gerenciar", component: GerenciarComponent, canActivate: [authGuard, roleGuard], data: {roles: ['Gerente']} },
    { path: "nao-autorizado", component: NaoAutorizadoComponent }
];
