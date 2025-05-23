import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Relatorio } from 'src/app/interfaces/relatorio';

@Component({
  selector: 'app-relatorio-pedido',
  imports: [CommonModule],
  templateUrl: './relatorio-pedido.component.html',
  styleUrl: './relatorio-pedido.component.css'
})
export class RelatorioPedidoComponent {

  relatorio!: Relatorio | null;
  mostrarVersaoImpressao = false;

  ngOnInit(): void {
    this.relatorio = history.state?.relatorio ?? null;
  }
  dataConvert(data: Date): string
  {
    const dataFormatada = new Date(data)
    return dataFormatada.toLocaleDateString('pt-BR')
  }

  timeConvert(data: Date): string
  {
    const dataFormatada = new Date(data)
    return dataFormatada.toLocaleTimeString('pt-BR')
  }

  async imprimirRelatorio() {
    this.mostrarVersaoImpressao = true;

    await new Promise(resolve => setTimeout(resolve,100))

    window.print();

    this.mostrarVersaoImpressao = false;
  }
}
