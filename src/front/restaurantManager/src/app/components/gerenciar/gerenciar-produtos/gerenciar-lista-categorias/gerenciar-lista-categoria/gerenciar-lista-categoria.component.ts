import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/interfaces/categoria';
import { CategoriaService } from 'src/app/services/categoria.service.';

@Component({
  selector: 'app-gerenciar-lista-categoria',
  imports: [CommonModule, FormsModule],
  templateUrl: './gerenciar-lista-categoria.component.html',
  styleUrl: './gerenciar-lista-categoria.component.css'
})
export class GerenciarListaCategoriaComponent {
  categoria$?: Observable<Categoria[] | null>;
  nomeCategoriaAlterada = '';
  categoriaCriada?: Categoria | null;

  nomeNovaCategoria = "";
  images = {
    editar: "assets/images/editar.svg",
    remover: "assets/images/remover.svg"
  }
  constructor(private categoriaService: CategoriaService) {}

  ngOnInit() {
    this.carregarCategorias();
    this.categoria$ = this.categoriaService.categoria$;
  }

  editar(categoria: Categoria) {
    categoria.nome = this.nomeCategoriaAlterada;
    this.categoriaService.atualizarCategoria(categoria).subscribe({
      next: () => {
        console.log('Categoria atualizada com sucesso!');
      },
      error: (err) => {
        console.error('Erro ao atualizar categoria:', err);
      }
    });
  }

  remover(categoriaId: number) {
    this.categoriaService.deletarCategoria(categoriaId).subscribe({
      next: () => {
        console.log('Categoria removida com sucesso!');
        this.carregarCategorias();
      },
      error: (err) => {
        console.error('Erro ao remover categoria:', err);
      }
    });
  }

  adicionar() {
    this.categoriaService.criarCategoria(this.nomeNovaCategoria).subscribe({
      next: () => {
        console.log('Categoria criada com sucesso!');
        this.carregarCategorias();
        this.nomeNovaCategoria;
      },
      error: (err) => {
        console.error('Erro ao criar categoria:', err);
      }
    });
  }

  private carregarCategorias() {
    this.categoriaService.getCategorias().subscribe(
      (data) => {
        this.categoriaService.setCategoria(data)
      },
      (error) => {
        console.error("Erro ao carregar categorias: ", error)
      }
    );
  }
}
