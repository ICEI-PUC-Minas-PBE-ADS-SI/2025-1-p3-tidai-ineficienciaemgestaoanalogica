import { ItemPedidoOutput } from "./item-pedido-output";

export interface PedidoOutput {
    id: number;
    mesaId: number;
    funcionarioId: number;
    observacao: string;
    itensPedido: ItemPedidoOutput[];
}