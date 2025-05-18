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

    getProdutoPorId(produtoId: number): Observable<Produto> {
        return this.http.get<Produto>(`${this.apiUrl}/${produtoId}`)
    }
    criarProduto(produto: Object): Observable<void> {
        return this.http.post<void>(this.apiUrl, produto);
    }

    atualizarProduto(produto: Produto): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${produto.id}`, produto);
    }

    deletarProduto(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`)
    }

    uploadImagem(arquivo: File, caminhoAntigo?: string): Observable<{ caminho: string }> {
        const formData = new FormData();
        formData.append('arquivo', arquivo);

        if(caminhoAntigo) formData.append('caminhoAntigo', caminhoAntigo);

        return this.http.post<{ caminho: string }>(`${this.apiUrl}/upload-imagem`, formData);
    }
}