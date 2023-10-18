import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaTecnicosComponent } from './components/lista-tecnicos/lista-tecnicos.component';

const routes: Routes = [
  {
    path: '',
    component: ListaTecnicosComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TecnicosRoutingModule { }
