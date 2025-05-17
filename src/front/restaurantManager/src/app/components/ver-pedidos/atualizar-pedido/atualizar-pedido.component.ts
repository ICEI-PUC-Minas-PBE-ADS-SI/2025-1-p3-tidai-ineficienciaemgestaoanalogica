import { Component, ElementRef, ViewChild } from '@angular/core';
import { ListaCategoriasComponent } from "./lista-categorias/lista-categorias.component";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute} from '@angular/router';
import { PedidoService } from 'src/app/services/pedido.service';
import { Pedido } from 'src/app/interfaces/pedido';
import { environment } from "src/environments/environment";
import { map, filter, Observable, take } from 'rxjs';
import { MesaService } from 'src/app/services/mesa.service';
import { ItemPedido } from 'src/app/interfaces/item-pedido';
import { ModalAvisoComponent } from "../../modal-aviso/modal-aviso.component";

@Component({
  selector: 'app-atualizar-pedido',
  templateUrl: './atualizar-pedido.component.html',
  styleUrl: './atualizar-pedido.component.css',
  imports: [ListaCategoriasComponent, CommonModule, FormsModule, ModalAvisoComponent],
})
export class AtualizarPedidoComponent {
  environment = environment;
  nomeMesa: string = "";
  pedido$!:  Observable<Pedido | null>;
  isHovered = false;

  constructor(private route: ActivatedRoute, private pedidoService: PedidoService, private mesaService: MesaService) {}

  ngOnInit(): void{
    const mesaId = Number(this.route.snapshot.paramMap.get('mesaId'))

    this.pedidoService.getPedidoPelaMesa(mesaId).subscribe(
      (data) => {
        this.pedidoService.setPedido(data);
      },
      (error) =>
      {
        console.error('Erro ao carregar pedidos: ', error)
      }
    )
    this.pedido$ = this.pedidoService.pedido$;

    this.mesaService.getMesa(mesaId).subscribe(
      (data) => {
        this.nomeMesa = data.nome;
      }
    )
  }

  onToggleExtra(item: ItemPedido, extraId: number, checked:boolean) {
    if(!item.extrasSelecionados) {
      item.extrasSelecionados = [];
    }

    if(checked) {
      if(!item.extrasSelecionados.includes(extraId)) {
        item.extrasSelecionados.push(extraId);
      }
    } else {
      item.extrasSelecionados = item.extrasSelecionados.filter(id => id !== extraId);
    }
  }

  calcularTotal(): Observable<number> {
    return this.pedidoService.pedido$.pipe(
      filter((pedido): pedido is Pedido => pedido !== null),
      map(pedido =>
        pedido.itensPedido.reduce((total, item) => {
          const precoExtras = item.produto.extras
            .filter(extra => item.extrasSelecionados.includes(extra.id))
            .map(extra => extra.precoAdicional)
            .reduce((soma, preco) => soma + preco, 0) || 0;

          return total + (item.precoUnitario + precoExtras) * item.quantidade;
        }, 0)
      )
    );
  }
 

  atualizarPedido() {
    this.pedidoService.pedido$.pipe(
      filter((pedido): pedido is Pedido => pedido !== null),
      take(1)
    ).subscribe(pedido => {
      const body = {
        id: pedido.id,
        mesaId: pedido.mesaId,
        funcionarioId: pedido.funcionarioId,
        observacao: pedido.observacao,
        itensPedido: pedido.itensPedido.map(item => ({
          produtoId: item.produto.id,
          quantidade: item.quantidade,
          precoUnitario: item.precoUnitario,
          extrasSelecionados: item.extrasSelecionados
        }))
      };
      this.pedidoService.updatePedido(pedido.id, body).subscribe(() =>{
        console.log('Pedido atualizado.');
      });
    });
  }

  incrementar(item: ItemPedido) {
    this.pedidoService.pedido$.pipe(take(1)).subscribe(pedido => {
      if(pedido) {
        item.quantidade++;
        this.pedidoService.setPedido({ ...pedido })
      }
    });
  }

  decrementar(item: ItemPedido) {
    this.pedidoService.pedido$.pipe(take(1)).subscribe(pedido => {
      if(pedido){
        if(item.quantidade > 1) {
          item.quantidade--;
        } else {
          pedido.itensPedido = pedido.itensPedido.filter(i => i !== item);
        }
        this.pedidoService.setPedido({ ...pedido });
      }
    });
  }
}