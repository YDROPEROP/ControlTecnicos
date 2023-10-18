import { IElemento, IElementosTecnico, ISucursal, ITecnico } from "./tecnico.interface";

export class Tecnico implements ITecnico {
    id!: number;
    nombre!: string;
    codigo!: string;
    sueldoBase!: number;
    elementosTecnicos!: ElementosTecnico[];
    elementos!: Elemento[];
    sucursalId!: number;
    sucursal!: Sucursal;
}

export class Sucursal implements ISucursal {
    id!: number;
    nombre!: string;
}

export class ElementosTecnico implements IElementosTecnico {
    id!: number;
    tecnicoId!: number;
    elementoId!: number;
    cantidad!: number;
    elemento!: Elemento;
    tecnico!: Tecnico;
}

export class Elemento implements IElemento {
    id!: number;
    nombre!: string;
}