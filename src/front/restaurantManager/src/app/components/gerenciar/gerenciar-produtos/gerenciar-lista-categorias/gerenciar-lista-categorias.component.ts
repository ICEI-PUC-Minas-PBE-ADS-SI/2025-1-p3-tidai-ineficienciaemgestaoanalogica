import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Categoria } from 'src/app/interfaces/categoria';
import { CategoriaService } from 'src/app/services/categoria.service.';
import { GerenciarCategoriaComponent } from "../gerenciar-categoria/gerenciar-categoria.component";
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-gerenciar-lista-categorias',
  imports: [CommonModule, GerenciarCategoriaComponent, RouterLink],
  templateUrl: './gerenciar-lista-categorias.component.html',
  styleUrl: './gerenciar-lista-categorias.component.css'
})
export class GerenciarListaCategoriasComponent {
  categorias: Categoria[] = [];
  activeIndex = 0;

  constructor(private categoriaService: CategoriaService) {}

  ngOnInit(): void {
    this.categoriaService.getCategorias().subscribe(
      (data) => {
        this.categorias = data;
      },
      (error) =>
      {
        console.error('Erro ao carregar categorias: ', error)
      }
    )
  }

  scrollToSection(event: Event, id: string, index: number)
  {
    event.preventDefault();
    this.activeIndex = index;
    const el = document.getElementById(id);
    if (el) {
      el.scrollIntoView({behavior: 'smooth'})
    }
  }
}
