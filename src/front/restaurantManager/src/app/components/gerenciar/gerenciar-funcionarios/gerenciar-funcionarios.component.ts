import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Funcionario } from 'src/app/interfaces/funcionario';
import { FuncionarioLogado } from 'src/app/interfaces/funcionario-logado';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-gerenciar-funcionarios',
  imports: [CommonModule, FormsModule],
  templateUrl: './gerenciar-funcionarios.component.html',
  styleUrl: './gerenciar-funcionarios.component.css'
})
export class GerenciarFuncionariosComponent {

  funcionarios?: Funcionario[] | null;
  images = {
    editar: "assets/images/editar.svg",
    remover: "assets/images/remover.svg"
  }
  constructor(private funcionarioService: AuthService) {}

  ngOnInit() {
    this.funcionarioService.getFuncionarios().subscribe(
      (data) => {
        this.funcionarios = data
      },
      (error) => {
        console.error("Erro ao carregar funcionários: ", error)
      }
    );
  }

}
