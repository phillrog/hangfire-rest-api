import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { TarefaService } from '../services/tarefa.service';

@Component({
  selector: 'ngx-incluir-tarefa',
  styleUrls: ['./incluir.component.scss'],
  templateUrl: './incluir.component.html',
})
export class IncluirTarefaComponent implements OnInit {

  tarefaForm : FormGroup;
  submitted = false;
  
  constructor(private fb: FormBuilder,
    private tarefaService: TarefaService) {
    
  }

  ngOnInit(): void {
      this.criarForm();
  }
  
  onSubmit() {
      this.submitted = true;
      if(this.tarefaForm.invalid)
          return;

      const param = this.tarefaService.toModel(this.tarefaForm.value);
      this.tarefaService.agendar(param).subscribe((response: any) => {
          this.resetarForm();
      })
  }

  criarForm() {
      this.tarefaForm = this.fb.group({
        nome: ['teste', Validators.required],
        url: ['https://www.google.com/', Validators.required],
        tipoAgendamento: ['1', Validators.required],
        dataAgendamento: ['', Validators.required],
        horaAgendamento: ['', Validators.required],
        tipoServico: ['1', Validators.required],
        tipoVerbo: ['1', Validators.required],
        payload: [''],
      });
    
  }

  resetarForm() {
      this.submitted = false;
      this.tarefaForm.reset();
  }

  get f() { return this.tarefaForm.controls; }
}
