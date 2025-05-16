import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ModalAvisoComponent } from '../../modal-aviso/modal-aviso.component';
import { Relatorio } from 'src/app/interfaces/relatorio';
import { ActivatedRoute } from '@angular/router';
import { PedidoService } from 'src/app/services/pedido.service';

@Component({
  selector: 'app-individual',
  imports: [CommonModule, ModalAvisoComponent],
  templateUrl: './individual.component.html',
  styleUrl: './individual.component.css'
})
export class IndividualComponent {
  relatorio!: Relatorio | null;
  constructor(private route: ActivatedRoute, private pedidoService: PedidoService) {}
  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'))
    this.pedidoService.getRelatorioId(id).subscribe(
      (data) => {
          this.relatorio = data;
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

  timeConvert(data: Date): string
  {
    const dataFormatada = new Date(data)
    return dataFormatada.toLocaleTimeString('pt-BR')
  }
}
