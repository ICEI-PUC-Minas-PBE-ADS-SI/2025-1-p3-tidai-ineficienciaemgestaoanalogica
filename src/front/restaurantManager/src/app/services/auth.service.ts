import { Injectable } from '@angular/core';
import { FuncionarioLogado } from '../interfaces/funcionario-logado';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, Observable, of, tap } from 'rxjs';
import { environment } from '../../environments/environment';
import { Funcionario } from '../interfaces/funcionario';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = `${environment.apiUrl}/api/Funcionarios`;
  private funcionario: FuncionarioLogado | null = null;
  constructor(private http: HttpClient, private router: Router) {}

  fazerLogin(usuario: string, senha: string): Observable<FuncionarioLogado> {
    return this.http.post<FuncionarioLogado>(`${this.apiUrl}/login`, {Usuario: usuario, Senha: senha}, { withCredentials: true }).pipe(
      tap(funcionario => this.funcionario = funcionario)
    );
  }

  getFuncionarios() : Observable<Funcionario[] | null> {
    return this.http.get<Funcionario[]>(`${this.apiUrl}`);
  }
  carregarFuncionario(): Observable<FuncionarioLogado | null> {
    return this.http.get<FuncionarioLogado>(`${this.apiUrl}/logado`, {withCredentials: true}).pipe(
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

  getFuncionario(): FuncionarioLogado | null {
    return this.funcionario
  }
}
