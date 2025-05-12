import { PedidoResumo } from "./pedido-resumo";

export interface Mesa {
    id: number;
    nome: string;
    observacao: string;
    itensPedido: PedidoResumo[];
}