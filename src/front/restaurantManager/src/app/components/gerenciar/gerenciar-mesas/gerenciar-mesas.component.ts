import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Mesa } from 'src/app/interfaces/mesa';
import { MesaService } from 'src/app/services/mesa.service';

@Component({
  selector: 'app-gerenciar-mesas',
  imports: [CommonModule, FormsModule],
  templateUrl: './gerenciar-mesas.component.html',
  styleUrl: './gerenciar-mesas.component.css'
})
export class GerenciarMesasComponent {
  mesas?: Mesa[] | null;
  images = {
    editar: "assets/images/editar.svg",
    remover: "assets/images/remover.svg"
  }
  constructor(private mesaService: MesaService) {}

  ngOnInit() {
    this.mesaService.getMesas().subscribe(
      (data) => {
        this.mesas = data
      },
      (error) => {
        console.error("Erro ao carregar funcionários: ", error)
      }
    );
  }

}
