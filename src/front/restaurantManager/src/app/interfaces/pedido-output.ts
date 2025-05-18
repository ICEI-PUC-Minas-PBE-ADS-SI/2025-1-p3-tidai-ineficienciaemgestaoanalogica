import { ItemPedidoOutput } from "./item-pedido-output";

export interface PedidoOutput {
    mesaId: number;
    funcionarioId: number;
    observacao: string;
    itensPedido: ItemPedidoOutput[];
}