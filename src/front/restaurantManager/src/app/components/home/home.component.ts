import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-home',
  imports: [RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  images = {
    verPedidos: "assets/images/ver_pedidos.svg",
    fazerPedidos: "assets/images/fazer_pedidos.svg",
    relatorios: "assets/images/relatorio.svg",
    gerenciar: "assets/images/gerenciar.svg",
  }
}
