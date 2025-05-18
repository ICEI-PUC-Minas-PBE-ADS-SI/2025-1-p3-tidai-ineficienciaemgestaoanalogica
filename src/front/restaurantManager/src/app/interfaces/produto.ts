import { Extra } from "./extra";

export interface Produto {
    id: number;
    nome: string;
    descricao?: string;
    preco: number;
    foto: string;
    categoriaId: number;
    extras: Extra[];
}