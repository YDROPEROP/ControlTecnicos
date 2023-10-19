export interface ITecnico {
    id: number;
    nombre: string;
    codigo: string;
    sueldoBase: number;
    fechaCreacion: string;
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
    fechaCreacion?: string;
    cantidad: number;
    elemento?: IElemento;
    tecnico?: ITecnico;
}

export interface IElemento {
    id: number;
    nombre: string;
    cantidad: number;
    noValido: boolean;
}