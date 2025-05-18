import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Relatorio } from 'src/app/interfaces/relatorio';
import { RelatorioPeriodo } from 'src/app/interfaces/relatorio-periodo';
import { PedidoService } from 'src/app/services/pedido.service';

@Component({
  selector: 'app-relatorio-periodo',
  imports: [CommonModule, RouterLink],
  templateUrl: './relatorio-periodo.component.html',
  styleUrl: './relatorio-periodo.component.css'
})
export class RelatorioPeriodoComponent {
  relatorios?: RelatorioPeriodo[]
  constructor(private route: ActivatedRoute, private pedidoService: PedidoService) {}

  ngOnInit(){
    const diaInicio = String(this.route.snapshot.paramMap.get('diaInicio'))
    const diaFim = String(this.route.snapshot.paramMap.get('diaFim'))

    this.pedidoService.getRelatorioPeriodo(diaInicio, diaFim).subscribe(
      (data) => {
        this.relatorios = data;
      },
      (error) =>
      {
        console.error('Erro ao carregar relatorios: ', error)
      }
    );
  }

  dataConvert(data: Date): string
  {
    const dataFormatada = new Date(data)
    return dataFormatada.toLocaleDateString('pt-BR')
  }
}
