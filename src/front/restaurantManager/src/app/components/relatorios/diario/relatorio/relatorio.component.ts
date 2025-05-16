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
  constructor(private route: ActivatedRoute, private pedidoService: PedidoService) {}

  ngOnInit(){
    const dia = String(this.route.snapshot.paramMap.get('dia'))

    this.pedidoService.getRelatorioDia(dia).subscribe(
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
