import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MesaService } from 'src/app/services/mesa.service';
import { PedidoService } from 'src/app/services/pedido.service';
import { environment } from 'src/environments/environment';
import { filter, map, Observable, take } from 'rxjs';
import { Pedido } from 'src/app/interfaces/pedido';
import { CommonModule } from '@angular/common';
import { Extra } from 'src/app/interfaces/extra';
import { ItemPedido } from 'src/app/interfaces/item-pedido';
import { Relatorio } from 'src/app/interfaces/relatorio';

@Component({
  selector: 'app-fechar-pedido',
  imports: [CommonModule],
  templateUrl: './fechar-pedido.component.html',
  styleUrl: './fechar-pedido.component.css'
})
export class FecharPedidoComponent {
  environment = environment;
  nomeMesa: string = "";
  extras: Extra[] | null = null;
  taxaGarcom: number = 0;
  precoFinal: number = 0;
  pedido$!:  Observable<Pedido | null>;

  constructor(private route: ActivatedRoute, private router: Router, private pedidoService: PedidoService, private mesaService: MesaService) {}
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

    this.pedido$.subscribe((pedido) => {
      if(pedido){
        const preco = pedido.itensPedido.reduce(
          (soma, item) => soma + (item.precoUnitario * item.quantidade), 0
        );
        this.taxaGarcom = preco * 0.1;
        this.precoFinal = preco + this.taxaGarcom;
      }
    });

    this.mesaService.getMesa(mesaId).subscribe(
      (data) => {
        this.nomeMesa = data.nome;
      }
    )
  }

  getExtras(itemPedido : ItemPedido): Extra[] {
    return itemPedido.produto.extras.filter(extra => 
      itemPedido.extrasSelecionados.includes(extra.id)
    );
  }

  fecharPedido() : void {
    this.pedidoService.pedido$.pipe(
      filter((pedido): pedido is Pedido => pedido !== null),
      take(1)
    ).subscribe(pedido => {
      this.pedidoService.fecharPedido(pedido.id).subscribe(
        (relatorio: Relatorio) =>{
          console.log(relatorio);
          this.router.navigate(['relatorio'], { relativeTo: this.route, state: { relatorio: relatorio } })
      });
    });
  }
}