import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'

import { TecnicosRoutingModule } from './tecnicos-routing.module';
import { ListaTecnicosComponent } from './components/lista-tecnicos/lista-tecnicos.component';
import { ModalTecnicoComponent } from './components/modal-tecnico/modal-tecnico.component';
import { TecnicosService } from './services/tecnicos.service';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ListaTecnicosComponent,
    ModalTecnicoComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    TecnicosRoutingModule
  ],
  providers: [
    TecnicosService
  ]
})
export class TecnicosModule { }
