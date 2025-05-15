import { ItemPedido } from "./item-pedido";
import { ItemRelatorioPedido } from "./item-relatorio-pedido";

export interface Relatorio {
    id: number,
    dataHoraInicio: Date,
    dataHoraFim: Date,
    nomeMesa: string,
    nomeFuncionario: string,
    precoFinal: number,
    itens: ItemRelatorioPedido[]
}