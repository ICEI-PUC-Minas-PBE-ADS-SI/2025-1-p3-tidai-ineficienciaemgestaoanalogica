import { Injectable } from "@angular/core";
import { environment } from "../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Categoria } from "../interfaces/categoria";

@Injectable({
    providedIn: 'root'
})
export class CategoriaService {
    private apiUrl = `${environment.apiUrl}/api/Categorias`;

    constructor(private http: HttpClient) {}

    getCategorias(): Observable<Categoria[]> {
        return this.http.get<Categoria[]>(this.apiUrl)
    }

    getCategoria(id: number): Observable<Categoria> {
        return this.http.get<Categoria>(`${this.apiUrl}/${id}`)
    }

    criarCategoria(categoria: Categoria): Observable<Categoria> {
        return this.http.post<Categoria>(this.apiUrl, categoria);
    }

    atualizarCategoria(categoria: Categoria): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${categoria.id}`, categoria);
    }

    deletarCategoria(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`)
    }
}