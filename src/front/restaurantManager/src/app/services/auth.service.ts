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

  getFuncionarioById(id: Number) : Observable<Funcionario | null> {
    return this.http.get<Funcionario>(`${this.apiUrl}/${id}`);
  }

  atualizarFuncionario(id: Number, funcionario: Object) : Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, funcionario);
  }

  criarFuncionario(funcionario: Object) : Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/registrar`, funcionario)
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

  removerFuncionario(funcionarioId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${funcionarioId}`);
  }

  estaAutenticado(): boolean {
    return this.funcionario !== null
  }

  possuiRole(role: string[]): boolean {
    return role.includes(this.funcionario!.tipo);
  }

  logout(): Observable<void>{
    return this.http.post<void>(`${this.apiUrl}/logout`, {});
  }

  getFuncionario(): FuncionarioLogado | null {
    return this.funcionario
  }
}
