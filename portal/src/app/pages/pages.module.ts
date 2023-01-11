import { NgModule } from '@angular/core';
import { NbMenuModule } from '@nebular/theme';

import { ThemeModule } from '../@theme/theme.module';
import { PagesComponent } from './pages.component';
import { PagesRoutingModule } from './pages-routing.module';
import { TarefaModule } from './tarefa/tarefa.module';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
    PagesRoutingModule,
    ThemeModule,
    NbMenuModule,
    TarefaModule,
    HttpClientModule
  ],
  declarations: [
    PagesComponent,
  ],
})
export class PagesModule {
}
