import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { map, Observable, switchMap } from 'rxjs';
import { Funcionario } from 'src/app/interfaces/funcionario';
import { FuncionarioLogado } from 'src/app/interfaces/funcionario-logado';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-gerenciar-funcionarios',
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './gerenciar-funcionarios.component.html',
  styleUrl: './gerenciar-funcionarios.component.css'
})
export class GerenciarFuncionariosComponent {

  funcionarios?: Funcionario[] | null;
  senhaUsuarioLogado: string = '';
  nomeUsuarioLogado: string = '';
  erroLogin: string | null = null;

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

  remover(funcionarioId: number) {
    const senha = this.senhaUsuarioLogado;
    const usuario = this.nomeUsuarioLogado;

    this.senhaUsuarioLogado = '';
    this.nomeUsuarioLogado = '';
    this.erroLogin = null;

    this.funcionarioService.fazerLogin(usuario, senha).pipe(
      switchMap(() => this.funcionarioService.carregarFuncionario())
    ).subscribe({
      next: (funcionario) => {
        if (funcionario && funcionario.tipo === 'Gerente') {
          this.funcionarioService.removerFuncionario(funcionarioId).subscribe({
            next: () => {
              console.log("Funcionário removido com sucesso");
              this.funcionarios = this.funcionarios?.filter(f => f.id !== funcionarioId) || null;
            },
            error: (err) => {
              console.error("Erro ao excluir funcionário:", err);
              this.erroLogin = "Erro ao excluir funcionário.";
            }
          });
        } else {
          this.erroLogin = "Apenas gerentes podem excluir funcionários.";
        }
      },
      error: () => {
        this.erroLogin = 'Usuário ou senha incorretos';
      }
    });
  }

  login(usuario: string, senha: string) {
    this.funcionarioService.fazerLogin(usuario, senha).subscribe({
      next: () => {
        this.erroLogin = null;
      },
      error: () => {
        this.erroLogin = 'Usuário ou senha incorretos';
      }
    })
  }
}
