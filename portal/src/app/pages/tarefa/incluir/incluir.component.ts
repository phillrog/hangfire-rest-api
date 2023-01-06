import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'ngx-incluir-tarefa',
  styleUrls: ['./incluir.component.scss'],
  templateUrl: './incluir.component.html',
})
export class IncluirTarefaComponent {

  profileForm = this.fb.group({
    nome: ['', Validators.required]
  });
  
  constructor(private fb: FormBuilder) {
    
  }
  
  onSubmit() {

  }
}
