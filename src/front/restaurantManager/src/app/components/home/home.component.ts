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
    verPedidos: "imgs/ver_pedidos.svg",
    fazerPedidos: "imgs/fazer_pedidos.svg",
    relatorios: "imgs/relatorio.svg",
    gerenciar: "imgs/gerenciar.svg",
  }
}
