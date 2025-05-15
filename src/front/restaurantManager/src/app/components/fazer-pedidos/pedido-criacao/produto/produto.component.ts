import { Component, Input, input } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { Produto } from 'src/app/interfaces/produto';
import { environment } from "src/app/environments/environment";
import { ItemPedido } from 'src/app/interfaces/item-pedido';
import { PedidoService } from 'src/app/services/pedido.service';

@Component({
  selector: 'app-produto',
  imports: [FormsModule],
  templateUrl: './produto.component.html',
  styleUrl: './produto.component.css'
})
export class ProdutoComponent {
  @Input() produto!: Produto;
  environment = environment;
  quantidade = 1;

  constructor(private pedidoService: PedidoService) {}

  increment(){
    this.quantidade++;
  }

  decrement(){
    if(this.quantidade > 1)
    this.quantidade--;
  }

  adicionarProduto(){
    const item: ItemPedido = {
      produto: this.produto,
      precoUnitario: this.produto.preco,
      quantidade: this.quantidade,
      extrasSelecionados: [],
    };
    
    this.pedidoService.adicionarItem(item);
  }

  images = {
    incrementar: "assets/images/incrementar.svg",
    decrementar: "assets/images/decrementar.svg",
  }
}
