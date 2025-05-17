import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { ItemPedido } from 'src/app/interfaces/item-pedido';
import { Produto } from 'src/app/interfaces/produto';
import { PedidoService } from 'src/app/services/pedido.service';

@Component({
  selector: 'app-gerenciar-produto',
  imports: [FormsModule],
  templateUrl: './gerenciar-produto.component.html',
  styleUrl: './gerenciar-produto.component.css'
})
export class GerenciarProdutoComponent {
  @Input() produto!: Produto;
  environment = environment;
  images = {
    editar: "assets/images/editar-no-border.svg",
  }
}
