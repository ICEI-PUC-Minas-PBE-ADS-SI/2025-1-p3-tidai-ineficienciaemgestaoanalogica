import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { filter, map, Observable, take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ItemPedido } from 'src/app/interfaces/item-pedido';
import { Pedido } from 'src/app/interfaces/pedido';
import { MesaService } from 'src/app/services/mesa.service';
import { PedidoService } from 'src/app/services/pedido.service';
import { GerenciarListaCategoriasComponent } from "./gerenciar-lista-categorias/gerenciar-lista-categorias.component";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-gerenciar-produtos',
  imports: [GerenciarListaCategoriasComponent, CommonModule, FormsModule],
  templateUrl: './gerenciar-produtos.component.html',
  styleUrl: './gerenciar-produtos.component.css'
})
export class GerenciarProdutosComponent {
}
