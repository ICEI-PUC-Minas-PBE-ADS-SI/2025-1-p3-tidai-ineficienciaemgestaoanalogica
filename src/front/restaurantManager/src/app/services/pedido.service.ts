import { Injectable } from "@angular/core";
import { environment } from "../environments/environment";
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Observable } from "rxjs";
import { Pedido } from "../interfaces/pedido";
import { ItemPedido } from "../interfaces/item-pedido";
import { PedidoOutput } from "../interfaces/pedido-output";

@Injectable({
    providedIn: 'root'
})
export class PedidoService {
    private apiUrl = `${environment.apiUrl}/api/Pedidos`;

    private pedidoSubject = new BehaviorSubject<Pedido | null>(null);
    public pedido$ = this.pedidoSubject.asObservable();

    constructor(private http: HttpClient) {}

    getPedidoPelaMesa(mesaId: number): Observable<Pedido> {
        return this.http.get<Pedido>(`${this.apiUrl}/pedidos-da-mesa/${mesaId}`)
    }

    updatePedido(id: number, pedido: PedidoOutput): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${id}`, pedido)
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

        const existente = pedido.itensPedido.find(i => i.produto.id === item.produto.id)
        if(existente) {
            existente.quantidade += item.quantidade;
        } else {
            pedido.itensPedido.push(item);
        }

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
