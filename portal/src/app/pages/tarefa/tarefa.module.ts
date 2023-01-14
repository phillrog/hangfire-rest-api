import { NgModule } from "@angular/core";
import { NbInputModule, NbCardModule, NbButtonModule, NbActionsModule, NbCheckboxModule, NbDatepickerModule, NbSelectModule, NbIconModule, NbTooltipModule, NbTreeGridModule } from "@nebular/theme";
import { IncluirTarefaComponent } from "./incluir/incluir.component";
import { TarefaRoutingModule } from "./tarefa-routing.module";
import { FormsModule, FormsModule as ngFormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from "@angular/common";
import { ListarComponent } from './listar/listar.component';
import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import ptBr from '@angular/common/locales/pt';
import {NbDateFnsDateModule} from '@nebular/date-fns'

registerLocaleData(ptBr);

@NgModule({
  imports: [
    CommonModule,
    NbInputModule,
    NbIconModule,
    NbCardModule,
    NbButtonModule,
    NbActionsModule,
    NbCheckboxModule,
    NbDatepickerModule,
    NbSelectModule,
    TarefaRoutingModule,
    ngFormsModule,
    FormsModule,
    ReactiveFormsModule,
    NbTooltipModule,
    NbTreeGridModule,
    NbDateFnsDateModule.forRoot({ format: 'dd/MM/yyyy' })
  ],
  declarations: [
    IncluirTarefaComponent,
    ListarComponent
  ],
  providers: [    {provide: LOCALE_ID,      useValue: 'pt-BR'    }  ]
})
export class TarefaModule { }
