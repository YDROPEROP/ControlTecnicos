import { Component, Input } from '@angular/core';
import { IElemento, IElementosTecnico, ISucursal, ITecnico } from '../../models/tecnico.interface';
import { Tecnico } from '../../models/tecnico.model';
import { TecnicosService } from '../../services/tecnicos.service';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-modal-tecnico',
  templateUrl: './modal-tecnico.component.html',
  styleUrls: ['./modal-tecnico.component.css']
})
export class ModalTecnicoComponent {
  @Input() tecnico: ITecnico = new Tecnico();
  @Input() sucursales: ISucursal[] = [];
  @Input() elementos: IElemento[] = [];

  get editarTecnico(): boolean {
    return Boolean(this.tecnico.id);
  }

  constructor(
    private _tecnicosService: TecnicosService
  ) { }

  async onSubmit(tecnico: ITecnico): Promise<void> {
    if (this.editarTecnico) {
      const elementosTecnicos: IElementosTecnico[] = tecnico.elementos.map(et => ({ tecnicoId: tecnico.id, elementoId: et.id, cantidad: 1 }));
      await lastValueFrom(this._tecnicosService.actualizarElementosTecnico(elementosTecnicos));
      await lastValueFrom(this._tecnicosService.actualizaTecnico(tecnico));
    } else {
      const elementosTecnicos: IElementosTecnico[] = tecnico.elementos.map(et => ({ tecnicoId: tecnico.id, elementoId: et.id, cantidad: 1 }));
      await lastValueFrom(this._tecnicosService.actualizarElementosTecnico(elementosTecnicos));
      await lastValueFrom(this._tecnicosService.crearTecnico(tecnico));
    }
    this.limpiarTecnico();
  }

  limpiarTecnico(): void {
    this.tecnico = new Tecnico();
  }
}
