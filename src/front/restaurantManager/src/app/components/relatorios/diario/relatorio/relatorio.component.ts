import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Relatorio } from 'src/app/interfaces/relatorio';
import { PedidoService } from 'src/app/services/pedido.service';

@Component({
  selector: 'app-relatorio',
  imports: [CommonModule, RouterLink],
  templateUrl: './relatorio.component.html',
  styleUrl: './relatorio.component.css'
})
export class RelatorioComponent {

  relatorios?: Relatorio[]
  mostrarVersaoImpressao = false;
  precoFinal = 0;
  dataDia = ""

  constructor(private route: ActivatedRoute, private pedidoService: PedidoService) {}

  ngOnInit(){
    const dia = String(this.route.snapshot.paramMap.get('dia'))

    this.pedidoService.getRelatorioDia(dia).subscribe(
      (data) => {
        this.relatorios = data;
        this.precoFinal = data.reduce((soma, r) => soma + r.precoFinal, 0);
      },
      (error) =>
      {
        console.error('Erro ao carregar relatorios: ', error)
      }
    );
    this.dataDia = new Date(dia).toLocaleDateString('pt-BR');
  }

  dataConvert(data: Date): string
  {
    const dataFormatada = new Date(data)
    return dataFormatada.toLocaleDateString('pt-BR')
  }

  async imprimirRelatorio() {
    this.mostrarVersaoImpressao = true;

    await new Promise(resolve => setTimeout(resolve,100))

    window.print();

    this.mostrarVersaoImpressao = false;
  }
}
