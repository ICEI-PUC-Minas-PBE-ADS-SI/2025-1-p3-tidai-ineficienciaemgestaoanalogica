import { Injectable } from "@angular/core";
import { environment } from "../environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { BehaviorSubject, Observable } from "rxjs";
import { Pedido } from "../interfaces/pedido";
import { ItemPedido } from "../interfaces/item-pedido";
import { PedidoOutput } from "../interfaces/pedido-output";
import { Relatorio } from "../interfaces/relatorio";
import { RelatorioPeriodo } from "../interfaces/relatorio-periodo";

@Injectable({
    providedIn: 'root'
})
export class PedidoService {
    private apiUrl = `${environment.apiUrl}/api/Pedidos`;
    private apiUrlRelatorios = `${environment.apiUrl}/api/Relatorios`

    private pedidoSubject = new BehaviorSubject<Pedido | null>(null);
    public pedido$ = this.pedidoSubject.asObservable();

    constructor(private http: HttpClient) {}

    getPedidoPelaMesa(mesaId: number): Observable<Pedido> {
        return this.http.get<Pedido>(`${this.apiUrl}/pedidos-da-mesa/${mesaId}`)
    }

    createPedido(pedido: PedidoOutput): Observable<void> {
        return this.http.post<void>(`${this.apiUrl}`, pedido)
    }

    updatePedido(id: number, pedido: PedidoOutput): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${id}`, pedido)
    }

    fecharPedido(id: number): Observable<Relatorio> {
        return this.http.post<Relatorio>(`${this.apiUrl}/fechar/${id}`, id);
    }
    getRelatorioDia(dia: string): Observable<Relatorio[]> {
        const params = new HttpParams().set('dia', dia);
        return this.http.get<Relatorio[]>(`${this.apiUrlRelatorios}/dia`, {params});
    }

    getRelatorioPeriodo(diaInicio: string, diaFim: string): Observable<RelatorioPeriodo[]> {
        const params = new HttpParams().set('inicio', diaInicio).set('fim', diaFim);
        return this.http.get<RelatorioPeriodo[]>(`${this.apiUrlRelatorios}/periodo`, {params});
    }

    getRelatorioId(id: number): Observable<Relatorio> {
        return this.http.get<Relatorio>(`${this.apiUrlRelatorios}/${id}`)
    }
    setPedido(pedido: Pedido) {
        this.pedidoSubject.next(pedido);
    }

    getPedido(): Pedido | null {
        return this.pedidoSubject.getValue();
    }


    adicionarItem(item: ItemPedido) {
        const pedido = this.getPedido()
        if(!pedido) return;

        pedido.itensPedido.push(item);

        this.pedidoSubject.next(pedido);
    }

    atualizarItem(item: ItemPedido) {
        const pedido = this.getPedido();
        if (!pedido) return;

        const index = pedido.itensPedido.findIndex(i => i.produto.id !== item.produto.id);
        if(index != -1) {
            pedido.itensPedido[index] = item;
            this.pedidoSubject.next(pedido);
        }
    }

    removerItem(produtoId: number) {
        const pedido = this.getPedido();
        if(!pedido) return;

        pedido.itensPedido = pedido.itensPedido.filter(i => i.produto.id !== produtoId)
        this.pedidoSubject.next(pedido);
    }

}
