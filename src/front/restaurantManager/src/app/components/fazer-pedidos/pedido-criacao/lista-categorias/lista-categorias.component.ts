import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Categoria } from 'src/app/interfaces/categoria';
import { CategoriaService } from 'src/app/services/categoria.service.';
import { CategoriaComponent } from "../categoria/categoria.component";
import { Pedido } from 'src/app/interfaces/pedido';

var bootstrap: any;

@Component({
  selector: 'app-lista-categorias',
  imports: [CategoriaComponent, CommonModule],
  templateUrl: './lista-categorias.component.html',
  styleUrl: './lista-categorias.component.css'
})
export class ListaCategoriasComponent {
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
