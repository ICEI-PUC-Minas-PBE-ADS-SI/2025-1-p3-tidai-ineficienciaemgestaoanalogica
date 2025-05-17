import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Categoria } from 'src/app/interfaces/categoria';
import { Produto } from 'src/app/interfaces/produto';
import { ProdutoService } from 'src/app/services/produto.service';
import { GerenciarProdutoComponent } from "../gerenciar-produto/gerenciar-produto.component";

@Component({
  selector: 'app-gerenciar-categoria',
  imports: [CommonModule, GerenciarProdutoComponent],
  templateUrl: './gerenciar-categoria.component.html',
  styleUrl: './gerenciar-categoria.component.css'
})
export class GerenciarCategoriaComponent {
  @Input() categoria!: Categoria;
  produtos: Produto[] = [];

  constructor(private produtoService : ProdutoService) {}

  ngOnInit(): void {
    this.produtoService.getProdutosPorCategoria(this.categoria.id).subscribe(
      (data) => {
        this.produtos = data;
      },
      (error) => {
        console.error('Erro ao carregar produtos', error)
      }
    );
  }
}
