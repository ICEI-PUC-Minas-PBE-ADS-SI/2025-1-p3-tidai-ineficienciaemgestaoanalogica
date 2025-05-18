import { ItemPedido } from "./item-pedido";

export interface Pedido {
    id: number;
    mesaId: number;
    funcionarioId: number;
    observacao: string;
    itensPedido: ItemPedido[];
}