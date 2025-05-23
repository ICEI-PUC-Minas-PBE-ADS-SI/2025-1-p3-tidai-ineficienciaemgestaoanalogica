import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  imgLogout = "/assets/images/logout.svg"

  constructor(private authService : AuthService, private router: Router) {}

  logout() {
    this.authService.logout().subscribe({
      next: () => {
        this.router.navigateByUrl('/login');
      },
      error: (err) => {
        console.error('Erro ao fazer logout', err);
      }
    });
  }
}
