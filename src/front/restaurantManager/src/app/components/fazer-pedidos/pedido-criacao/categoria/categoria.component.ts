import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProdutoComponent } from "../produto/produto.component";
import { Categoria } from 'src/app/interfaces/categoria';
import { Produto } from 'src/app/interfaces/produto';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-categoria',
  imports: [ProdutoComponent, CommonModule],
  templateUrl: './categoria.component.html',
  styleUrl: './categoria.component.css'
})
export class CategoriaComponent implements OnInit {
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
