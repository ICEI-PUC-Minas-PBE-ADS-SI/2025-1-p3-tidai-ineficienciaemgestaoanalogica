import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Funcionario } from 'src/app/interfaces/funcionario';
import { FuncionarioRegistro } from 'src/app/interfaces/funcionario-registro';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-criar-funcionario',
  imports: [CommonModule, FormsModule],
  templateUrl: './criar-funcionario.component.html',
  styleUrl: './criar-funcionario.component.css'
})
export class CriarFuncionarioComponent {
  funcionario?: FuncionarioRegistro | null;
  constructor(private route: ActivatedRoute, private router: Router, private funcionarioService: AuthService) {}

  ngOnInit() {
    this.funcionario = {
      nome: '',
      usuario: '',
      senha: '',
      tipo: ''
    }
  }

  criar(){
    if(this.funcionario == null)
      console.log('Funcionario vazio.')
    else {
      this.funcionarioService.criarFuncionario(this.funcionario).subscribe({
        next: () => {
          console.log("Funcionário criado");
          this.router.navigate(['../'], { relativeTo: this.route})
        },
        error: (err) => {
          console.error("Erro ao criar funcionário:", err);
        }
      })
    }
  }
}
