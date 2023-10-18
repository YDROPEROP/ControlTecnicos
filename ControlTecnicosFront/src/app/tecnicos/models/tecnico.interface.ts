export interface ITecnico {
    id: number;
    nombre: string;
    codigo: string;
    sueldoBase: number;
    elementosTecnicos: IElementosTecnico[];
    elementos: IElemento[];
    sucursalId: number;
    sucursal: ISucursal;
}

export interface ISucursal {
    id: number;
    nombre: string;
}

export interface IElementosTecnico {
    id?: number;
    tecnicoId: number;
    elementoId: number;
    cantidad: number;
    elemento?: IElemento;
    tecnico?: ITecnico;
}

export interface IElemento {
    id: number;
    nombre: string;
}