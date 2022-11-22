import { NgModule } from "@angular/core";
import { NbInputModule, NbCardModule, NbButtonModule, NbActionsModule, NbCheckboxModule, NbDatepickerModule, NbSelectModule, NbIconModule } from "@nebular/theme";
import { IncluirTarefaComponent } from "./incluir/incluir.component";
import { TarefaRoutingModule } from "./tarefa-routing.module";
import { FormsModule as ngFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    NbInputModule,
    NbCardModule,
    NbButtonModule,
    NbActionsModule,
    NbCheckboxModule,
    NbDatepickerModule,
    NbSelectModule,
    TarefaRoutingModule,
    ngFormsModule,
  ],
  declarations: [
    IncluirTarefaComponent
  ],
})
export class TarefaModule { }
