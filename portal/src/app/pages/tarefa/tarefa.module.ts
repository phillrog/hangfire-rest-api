import { NgModule } from "@angular/core";
import { NbInputModule, NbCardModule, NbButtonModule, NbActionsModule, NbCheckboxModule, NbDatepickerModule, NbSelectModule, NbIconModule } from "@nebular/theme";
import { IncluirTarefaComponent } from "./incluir/incluir.component";
import { TarefaRoutingModule } from "./tarefa-routing.module";
import { FormsModule, FormsModule as ngFormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from "@angular/common";

@NgModule({
  imports: [
    CommonModule,
    NbInputModule,
    NbCardModule,
    NbButtonModule,
    NbActionsModule,
    NbCheckboxModule,
    NbDatepickerModule,
    NbSelectModule,
    TarefaRoutingModule,
    ngFormsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    IncluirTarefaComponent
  ],
})
export class TarefaModule { }
