import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Produto } from "../interfaces/produto";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class ProdutoService {
    private apiUrl = `${environment.apiUrl}/api/Produtos`;

    constructor(private http: HttpClient) {}
    getProdutosPorCategoria(categoriaId: number): Observable<Produto[]> {
        return this.http.get<Produto[]>(`${this.apiUrl}/categoria/${categoriaId}`)
    }
    criarProduto(produto: Produto): Observable<Produto> {
        return this.http.post<Produto>(this.apiUrl, produto);
    }

    atualizarProduto(produto: Produto): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${produto.id}`, produto);
    }

    deletarProduto(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`)
    }
}