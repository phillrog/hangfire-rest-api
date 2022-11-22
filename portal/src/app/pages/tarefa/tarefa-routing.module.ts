import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { IncluirTarefaComponent } from './incluir/incluir.component';

const routes: Routes = [
  {
    path: '',
    component: IncluirTarefaComponent,
    children: [
      {
        path: 'incluir',
        component: IncluirTarefaComponent,
      }
    ],
  },
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

