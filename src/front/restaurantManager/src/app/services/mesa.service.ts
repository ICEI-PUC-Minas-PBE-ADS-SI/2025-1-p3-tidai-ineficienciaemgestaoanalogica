import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Observable } from "rxjs";
import { Mesa } from "../interfaces/mesa";

@Injectable({
    providedIn: 'root'
})
export class MesaService {
    private apiUrl = `${environment.apiUrl}/api/Mesas`;
    private mesaSubject = new BehaviorSubject<Mesa[] | null>(null);
    public mesas$ = this.mesaSubject.asObservable();

    constructor(private http: HttpClient) {}

    getMesas(): Observable<Mesa[]> {
        return this.http.get<Mesa[]>(this.apiUrl)
    }

    getMesasComPedidoAberto(): Observable<Mesa[]> {
        return this.http.get<Mesa[]>(`${this.apiUrl}/com-pedidos-abertos`)
    }

    getMesasSemPedidoAberto(): Observable<Mesa[]> {
        return this.http.get<Mesa[]>(`${this.apiUrl}/sem-pedidos-abertos`)
    }

    getMesa(id: number): Observable<Mesa> {
        return this.http.get<Mesa>(`${this.apiUrl}/${id}`)
    }

    criarMesa(nomeMesa: String): Observable<Mesa> {
        return this.http.post<Mesa>(`${this.apiUrl}`, {nome: nomeMesa});
    }

    atualizarMesa(mesa: Mesa): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${mesa.id}`, mesa);
    }

    deletarMesa(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`)
    }

    setMesas(mesas: Mesa[]) {
        this.mesaSubject.next(mesas);
    }
}