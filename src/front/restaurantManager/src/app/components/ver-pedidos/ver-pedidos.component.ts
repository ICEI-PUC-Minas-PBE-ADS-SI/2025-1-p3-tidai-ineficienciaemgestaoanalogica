import { Component } from '@angular/core';
import { Mesa } from 'src/app/interfaces/mesa';
import { MesasComponent } from './mesas/mesas.component';
import { CommonModule } from '@angular/common';
import { MesaService } from 'src/app/services/mesa.service';
import { PedidoSocketService } from 'src/app/services/pedido-socket.service';

@Component({
  selector: 'app-lista-mesas',
  imports: [MesasComponent, CommonModule],
  templateUrl: './ver-pedidos.component.html',
  styleUrl: './ver-pedidos.component.css'
})
export class VerPedidosComponent {
  mesas: Mesa[] = [];

  constructor(private mesaService: MesaService, private socketService: PedidoSocketService) {}


  ngOnInit(): void {
    this.socketService.iniciarConexao();

    this.socketService.pedidoAtualizado$.subscribe(() => {
      this.mesaService.getMesasComPedidoAberto().subscribe(
        (data) => {
          this.mesas = data;
        },
        (error) => {
          console.error('Erro ao recarregar as mesas: ', error)
        }
      )
    })

    this.mesaService.getMesasComPedidoAberto().subscribe(
      (data) => {
        this.mesas = data;
      },
      (error) => {
        console.error('Erro ao carregar mesas: ', error)
      }
    )
  }
}