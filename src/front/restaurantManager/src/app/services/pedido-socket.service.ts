import * as signalR from '@microsoft/signalr'
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PedidoSocketService {
  private apiUrl = `${environment.apiUrl}/hub/pedidos`;
  private hubConnection!: signalR.HubConnection;
  private pedidoAtualizado = new Subject<void>();

  pedidoAtualizado$ = this.pedidoAtualizado.asObservable();

  private conexaoIniciada = false;

  iniciarConexao() {
    if(this.conexaoIniciada) return;

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this.apiUrl)
      .build();

    this.hubConnection
      .start()
      .then(() => {
        console.log('Conectado ao SignalR'); 
        this.conexaoIniciada = true;
      })
      .catch((err) => console.error('Erro ao conectar ao SignalR', err));
    
    this.hubConnection.on('ReceberAtualizacao', () => {
      this.pedidoAtualizado.next();
    });
  }
}
