import { Component, OnInit } from '@angular/core';
import { TecnicosService } from '../../services/tecnicos.service';
import { IElemento, ISucursal, ITecnico } from '../../models/tecnico.interface';
import { lastValueFrom } from 'rxjs';
import { Tecnico } from '../../models/tecnico.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-lista-tecnicos',
  templateUrl: './lista-tecnicos.component.html',
  styleUrls: ['./lista-tecnicos.component.css']
})
export class ListaTecnicosComponent implements OnInit {
  tecnicos: ITecnico[] = [];
  sucursales: ISucursal[] = [];
  elementos: IElemento[] = [];
  tecnico: ITecnico = new Tecnico();

  constructor(
    private _tecnicosService: TecnicosService
  ) { }

  async ngOnInit(): Promise<void> {
    this.tecnicos = await lastValueFrom(this._tecnicosService.obtenerTecnicos());
    this.sucursales = await lastValueFrom(this._tecnicosService.obtenerSucursales());
    this.elementos = await lastValueFrom(this._tecnicosService.obtenerElementos());
  }

  editarTecnico(tecnico: ITecnico): void {
    this.tecnico = tecnico;
    const buttonModal = document.getElementById('botonModal') as HTMLElement;
    buttonModal.click();
  }

  async eliminarTecnico(id: number): Promise<void> {
    await lastValueFrom(this._tecnicosService.eliminarTecnico(id));
    Swal.fire({
      icon: 'success',
      title: 'Correcto',
      text: 'Técnico eliminado correctamente'
    });
  }

  actualizarTecnico(tecnico: ITecnico): void {
    this.tecnico = tecnico;
  }
}
