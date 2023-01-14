import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { IncluirTarefaComponent } from './incluir/incluir.component';
import { ListarComponent } from './listar/listar.component';

const routes: Routes = [
  {
    path: '',    
    children: [
      {
        path: 'listar',
        component: ListarComponent,
      },
      {
        path: 'incluir',
        component: IncluirTarefaComponent,
      }
    ],
  }

];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule,
  ],
})
export class TarefaRoutingModule {
}

