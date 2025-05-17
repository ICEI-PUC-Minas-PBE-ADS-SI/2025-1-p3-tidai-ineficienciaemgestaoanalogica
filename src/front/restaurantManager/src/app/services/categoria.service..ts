import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { BehaviorSubject, Observable } from "rxjs";
import { Categoria } from "../interfaces/categoria";

@Injectable({
    providedIn: 'root'
})
export class CategoriaService {
    private apiUrl = `${environment.apiUrl}/api/Categorias`;
    private categoriaSubject = new BehaviorSubject<Categoria[] | null>(null);
    public categoria$ = this.categoriaSubject.asObservable();

    constructor(private http: HttpClient) {}

    getCategorias(): Observable<Categoria[]> {
        return this.http.get<Categoria[]>(this.apiUrl)
    }

    getCategoria(id: number): Observable<Categoria> {
        return this.http.get<Categoria>(`${this.apiUrl}/${id}`)
    }

    criarCategoria(nomeCategoria: string): Observable<void> {
        return this.http.post<void>(`${this.apiUrl}`, {nome: nomeCategoria});
    }

    atualizarCategoria(categoria: Categoria): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${categoria.id}`, categoria);
    }

    deletarCategoria(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`)
    }

    setCategoria(categoria: Categoria[]) {
        this.categoriaSubject.next(categoria);
    }
}