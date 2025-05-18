import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Mesa } from 'src/app/interfaces/mesa';
import { MesaService } from 'src/app/services/mesa.service';

@Component({
  selector: 'app-fazer-pedidos',
  imports: [CommonModule, RouterLink],
  templateUrl: './fazer-pedidos.component.html',
  styleUrl: './fazer-pedidos.component.css'
})
export class FazerPedidosComponent {
  mesas: Mesa[] = [];

  constructor(private mesaService: MesaService) {}

  ngOnInit(): void {
    this.mesaService.getMesasSemPedidoAberto().subscribe(
      (data) => {
        this.mesas = data;
      },
      (error) => {
        console.error('Erro ao carregar mesas: ', error)
      }
    )
  }
}
