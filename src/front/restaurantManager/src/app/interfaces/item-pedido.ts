import { Produto } from "./produto";

export interface ItemPedido{
    produto: Produto;
    quantidade: number;
    precoUnitario: number;
    extrasSelecionados: number[];
}