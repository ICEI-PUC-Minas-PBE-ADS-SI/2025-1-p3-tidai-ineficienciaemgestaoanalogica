import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { Mesa } from 'src/app/interfaces/mesa';
import { MesaService } from 'src/app/services/mesa.service';

@Component({
  selector: 'app-gerenciar-mesas',
  imports: [CommonModule, FormsModule],
  templateUrl: './gerenciar-mesas.component.html',
  styleUrl: './gerenciar-mesas.component.css'
})
export class GerenciarMesasComponent {
  mesas$?: Observable<Mesa[] | null>;
  nomeMesaAlterada = '';
  nomeNovaMesa = '';
  mesaCriada?: Mesa | null;
  images = {
    editar: "assets/images/editar.svg",
    remover: "assets/images/remover.svg"
  }
  constructor(private mesaService: MesaService) {}

  ngOnInit() {
    this.carregarMesas();
    this.mesas$ = this.mesaService.mesas$;
  }

  editar(mesa: Mesa) {
    mesa.nome = this.nomeMesaAlterada;
    this.mesaService.atualizarMesa(mesa).subscribe({
      next: () => {
        console.log('Mesa atualizada com sucesso!');
        this.nomeMesaAlterada = '';
      },
      error: (err) => {
        console.error('Erro ao atualizar mesa:', err);
      }
    });
  }

  remover(mesaId: number) {
    this.mesaService.deletarMesa(mesaId).subscribe({
      next: () => {
        console.log('Mesa removida com sucesso!');
        this.carregarMesas();
      },
      error: (err) => {
        console.error('Erro ao remover mesa:', err);
      }
    });
  }

  adicionar() {
    this.mesaService.criarMesa(this.nomeNovaMesa).subscribe({
      next: () => {
        console.log('Mesa criada com sucesso!');
        this.carregarMesas();
        this.nomeNovaMesa = '';
      },
      error: (err) => {
        console.error('Erro ao criar mesa:', err);
      }
    });
  }

  private carregarMesas() {
    this.mesaService.getMesas().subscribe(
      (data) => {
        this.mesaService.setMesas(data)
      },
      (error) => {
        console.error("Erro ao carregar categorias: ", error)
      }
    );
  }
}

