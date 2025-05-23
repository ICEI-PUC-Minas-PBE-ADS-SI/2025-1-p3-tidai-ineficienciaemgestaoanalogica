import { Component } from '@angular/core';
import { ModalAvisoComponent } from "../../modal-aviso/modal-aviso.component";
import { ListaCategoriasComponent } from "../../ver-pedidos/atualizar-pedido/lista-categorias/lista-categorias.component";
import { environment } from 'src/environments/environment';
import { filter, map, Observable, take } from 'rxjs';
import { Pedido } from 'src/app/interfaces/pedido';
import { ActivatedRoute } from '@angular/router';
import { PedidoService } from 'src/app/services/pedido.service';
import { MesaService } from 'src/app/services/mesa.service';
import { ItemPedido } from 'src/app/interfaces/item-pedido';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { PedidoOutput } from 'src/app/interfaces/pedido-output';

@Component({
  selector: 'app-pedido-criacao',
  imports: [ModalAvisoComponent, ListaCategoriasComponent, FormsModule, CommonModule],
  templateUrl: './pedido-criacao.component.html',
  styleUrl: './pedido-criacao.component.css'
})
export class PedidoCriacaoComponent {
  environment = environment;
  nomeMesa: string = "";
  pedido$!:  Observable<Pedido | null>;
  isHovered = false;

  constructor(private route: ActivatedRoute, private pedidoService: PedidoService, private mesaService: MesaService, private authService: AuthService) {}
  ngOnInit(): void{
    const mesaId = Number(this.route.snapshot.paramMap.get('mesaId'))
    const funcionarioId = Number(this.authService.getFuncionario()?.id)

    const novoPedido: Pedido = {
      id: 0,
      mesaId: mesaId,
      funcionarioId:  funcionarioId,
      observacao: '',
      itensPedido: [],
    };
    this.pedidoService.setPedido(novoPedido);

    this.pedido$ = this.pedidoService.pedido$;

    this.mesaService.getMesas().subscribe(
      (data) => {
        const mesa = data.find(m => m.id);
        this.nomeMesa = mesa !== undefined ? mesa.nome : "";
      },
      (error) => {
        console.error('Erro ao carregar nome da mesa: ', error)
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


  criarPedido() {
    this.pedidoService.pedido$.pipe(
      filter((pedido): pedido is Pedido => pedido !== null),
      take(1)
    ).subscribe(pedido => {
      const body = {
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
      this.pedidoService.createPedido(body).subscribe(() =>{
        console.log('Pedido criado com sucesso.');
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
