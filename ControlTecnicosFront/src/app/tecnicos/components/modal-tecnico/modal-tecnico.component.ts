import { Component, EventEmitter, Input, Output, OnChanges, SimpleChanges } from '@angular/core';
import { IElemento, IElementosTecnico, ISucursal, ITecnico } from '../../models/tecnico.interface';
import { Tecnico } from '../../models/tecnico.model';
import { TecnicosService } from '../../services/tecnicos.service';
import { lastValueFrom } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-modal-tecnico',
  templateUrl: './modal-tecnico.component.html',
  styleUrls: ['./modal-tecnico.component.css']
})
export class ModalTecnicoComponent implements OnChanges {
  @Input() tecnico: ITecnico = new Tecnico();
  @Output() onTecnico: EventEmitter<ITecnico> = new EventEmitter<ITecnico>();
  @Input() sucursales: ISucursal[] = [];
  @Input() elementos: IElemento[] = [];

  codigoIncorrecto: boolean = false;

  get editarTecnico(): boolean {
    return Boolean(this.tecnico.id);
  }

  constructor(
    private _tecnicosService: TecnicosService
  ) { }

  ngOnChanges(): void {
    if (this.editarTecnico) {
      this.elementos.forEach(e => {
        const elementoTecnico = this.tecnico.elementosTecnicos.find(et => et?.elemento?.id === e.id);
        if (elementoTecnico) {
          e.cantidad = elementoTecnico.cantidad;
        } else {
          e.cantidad = 0;
        }
      })
    }
  }

  async onSubmit(tecnico: ITecnico): Promise<void> {
    try {
      const exp = RegExp(/^[a-zA-Z0-9]*$/)
      if (!exp.test(tecnico.codigo)) {
        this.codigoIncorrecto = true;
        return;
      } else {
        this.codigoIncorrecto = false;
      }
  
      const noHaSeleccionadoElementos = this.elementos.reduce((acc, e) => acc += e.cantidad ?? 0, 0) === 0;
      if (noHaSeleccionadoElementos) {
        Swal.fire({
          icon: 'error',
          title: 'Error de validación',
          text: 'Debe agregar al menos un elemento'
        });
        return;
      }
  
      this.elementos.forEach(e => {
        e.noValido = e.cantidad < 0 || e.cantidad > 10;
      });
  
      if (this.elementos.some(e => e.noValido)) return;

      const elementosTecnicos: IElementosTecnico[] = this.elementos
        .filter(e => e.cantidad)
        .map(e => ({ tecnicoId: tecnico.id, elementoId: e.id, cantidad: e.cantidad }));
  
      if (this.editarTecnico) {
        await lastValueFrom(this._tecnicosService.actualizaTecnico(tecnico, elementosTecnicos));
  
        Swal.fire({
          icon: 'success',
          title: 'Correcto',
          text: 'Técnico actualizado correctamente'
        });
      } else {
        await lastValueFrom(this._tecnicosService.crearTecnico(tecnico, elementosTecnicos));
  
        Swal.fire({
          icon: 'success',
          title: 'Correcto',
          text: 'Técnico creado correctamente'
        });
      }
    } catch (error: any) {
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: error?.message
      });
    }

    const botonCerrarModal = document.getElementById('botonCerrarModal') as HTMLElement;
    botonCerrarModal.click();
  }

  limpiarTecnico(): void {
    this.tecnico = new Tecnico();
    this.onTecnico.emit(this.tecnico);
  }
}
