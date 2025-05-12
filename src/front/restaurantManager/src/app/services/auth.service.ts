import { Injectable } from '@angular/core';
import { Funcionario } from '../interfaces/funcionario';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, Observable, of, tap } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = `${environment.apiUrl}/api/Funcionarios`;
  private funcionario: Funcionario | null = null;
  constructor(private http: HttpClient, private router: Router) {}

  fazerLogin(usuario: string, senha: string): Observable<Funcionario> {
    return this.http.post<Funcionario>(`${this.apiUrl}/login`, {Usuario: usuario, Senha: senha}, { withCredentials: true }).pipe(
      tap(funcionario => this.funcionario = funcionario)
    );
  }
  carregarFuncionario(): Observable<Funcionario | null> {
    return this.http.get<Funcionario>(`${this.apiUrl}/logado`, {withCredentials: true}).pipe(
      tap(data => this.funcionario = data),
      catchError(() => {
        this.funcionario = null;
        return of(null);
      })
    );
  }

  estaAutenticado(): boolean {
    return this.funcionario !== null 
  }

  possuiRole(role: string[]): boolean {
    return role.includes(this.funcionario!.tipo);
  }

  logout() {
    this.funcionario = null;
    this.router.navigate(['/login']);
  }

  getFuncionario(): Funcionario | null {
    return this.funcionario
  }
}
