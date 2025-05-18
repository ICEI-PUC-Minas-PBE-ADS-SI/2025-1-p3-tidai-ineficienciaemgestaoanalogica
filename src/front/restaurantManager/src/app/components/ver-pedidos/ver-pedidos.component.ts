import { Component } from '@angular/core';
import { Mesa } from 'src/app/interfaces/mesa';
import { MesasComponent } from './mesas/mesas.component';
import { CommonModule } from '@angular/common';
import { MesaService } from 'src/app/services/mesa.service';

@Component({
  selector: 'app-lista-mesas',
  imports: [MesasComponent, CommonModule],
  templateUrl: './ver-pedidos.component.html',
  styleUrl: './ver-pedidos.component.css'
})
export class VerPedidosComponent {
  mesas: Mesa[] = [];

  constructor(private mesaService: MesaService) {}

  ngOnInit(): void {
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