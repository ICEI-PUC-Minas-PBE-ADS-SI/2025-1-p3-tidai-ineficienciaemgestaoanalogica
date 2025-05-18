import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Funcionario } from 'src/app/interfaces/funcionario';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-editar-funcionario',
  imports: [CommonModule, FormsModule],
  templateUrl: './editar-funcionario.component.html',
  styleUrl: './editar-funcionario.component.css'
})
export class EditarFuncionarioComponent {
  funcionario?: Funcionario | null;
  novaSenha: string = '';
  constructor(private route: ActivatedRoute, private router: Router, private funcionarioService: AuthService) {}

  ngOnInit() {
    const funcionarioId = Number(this.route.snapshot.paramMap.get('funcionarioId'));
    console.log(funcionarioId);

    this.funcionarioService.getFuncionarioById(funcionarioId).subscribe(
      (data) => {
        console.log(data)
        this.funcionario = data;
      },
      (error) => {
        console.error("Erro ao carregar funcionário", error);
      }
    )
  }

  atualizar(){
    if(this.funcionario == null)
      console.log('Funcionario vazio.')
    else {
      const body = {
        id: this.funcionario.id,
        nome: this.funcionario.nome,
        usuario: this.funcionario.usuario,
        tipo: this.funcionario.tipo,
        senha: this.novaSenha
      };
      this.funcionarioService.atualizarFuncionario(body.id, body).subscribe({
        next: () => {
          console.log("Funcionário atualizado");
          this.router.navigate(['../../'], { relativeTo: this.route})
        },
        error: (err) => {
          console.error("Erro ao atualizar funcionário:", err);
        }
      })
    }
  }
}
