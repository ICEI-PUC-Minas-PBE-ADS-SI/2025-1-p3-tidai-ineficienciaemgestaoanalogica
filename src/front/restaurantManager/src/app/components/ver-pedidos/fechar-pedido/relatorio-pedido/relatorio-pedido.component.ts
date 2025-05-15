import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { ModalAvisoComponent } from 'src/app/components/modal-aviso/modal-aviso.component';
import { Pedido } from 'src/app/interfaces/pedido';
import { Relatorio } from 'src/app/interfaces/relatorio';

@Component({
  selector: 'app-relatorio-pedido',
  imports: [CommonModule, ModalAvisoComponent],
  templateUrl: './relatorio-pedido.component.html',
  styleUrl: './relatorio-pedido.component.css'
})
export class RelatorioPedidoComponent {

  relatorio!: Relatorio | null;
  ngOnInit(): void {
    this.relatorio = history.state?.relatorio ?? null;
    console.log(this.relatorio)

    if(this.relatorio)
    {
      this.relatorio.dataHoraFim = new Date(this.relatorio?.dataHoraFim);
    }

    if (!this.relatorio) {
      // opcional: redirecionar ou buscar novamente o pedido
      console.warn('Pedido não encontrado no state!');
    }
  }
}
