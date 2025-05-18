import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { GerenciarListaCategoriasComponent } from "./gerenciar-lista-categorias/gerenciar-lista-categorias.component";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-gerenciar-produtos',
  imports: [GerenciarListaCategoriasComponent, CommonModule, FormsModule, RouterLink],
  templateUrl: './gerenciar-produtos.component.html',
  styleUrl: './gerenciar-produtos.component.css'
})
export class GerenciarProdutosComponent {
}
