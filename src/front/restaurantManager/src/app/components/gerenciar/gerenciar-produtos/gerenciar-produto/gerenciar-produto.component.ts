import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { ItemPedido } from 'src/app/interfaces/item-pedido';
import { Produto } from 'src/app/interfaces/produto';
import { PedidoService } from 'src/app/services/pedido.service';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-gerenciar-produto',
  imports: [CommonModule ,FormsModule, RouterLink],
  templateUrl: './gerenciar-produto.component.html',
  styleUrl: './gerenciar-produto.component.css'
})
export class GerenciarProdutoComponent {
  @Input() produto!: Produto;
  @Output() produtoRemovido = new EventEmitter<number>();
  environment = environment;
  images = {
    editar: "assets/images/editar-no-border.svg",
  }

  constructor(private produtoService: ProdutoService) {}

  remover(produtoId: number)
  {
    this.produtoService.deletarProduto(produtoId).subscribe({
      next: () => {
        console.log("Produto Removido")
        this.produtoRemovido.emit(produtoId);
      },
      error: (err) => {
        console.error("Erro ao remover produto:",err)
      }
    });
  }
}
