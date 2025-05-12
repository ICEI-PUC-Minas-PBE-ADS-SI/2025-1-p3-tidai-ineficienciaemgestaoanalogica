import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  usuario: string = '';
  senha: string = '';
  erroLogin: string | null = null;

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.fazerLogin(this.usuario, this.senha).subscribe({
      next: () => {
        this.router.navigate(['/']);
      },
      error: () => {
        this.erroLogin = 'Usuário ou senha incorretos.';
      }
    })
  }

}
