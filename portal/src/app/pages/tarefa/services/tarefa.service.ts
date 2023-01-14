import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { TarefaModel } from '../models/tarefa.model';
import {v4 as uuidv4} from 'uuid';

@Injectable({
  providedIn: 'root'
})
export class TarefaService {
  baseUrl: any;

  constructor(private httpCLient: HttpClient) {
    this.baseUrl = environment.hangfireTarefaApi;
  }

  toModel(agendamento: any): TarefaModel {
    return new TarefaModel(
      uuidv4(),
      agendamento.nome,
      agendamento.url,
      agendamento.dataAgendamento,
      agendamento.horaAgendamento,
      Number(agendamento.tipoAgendamento),
      Number(agendamento.tipoServico),
      Number(agendamento.tipoVerbo),
      agendamento.payload
    );
  }

  agendar(agendamento: TarefaModel): Observable<any> {
    return this.httpCLient.post(`${this.baseUrl}agendar`, agendamento);
  }

  listar(): Observable<TarefaModel[]> {
    return this.httpCLient.get<TarefaModel[]>(`${this.baseUrl}listar`);
  }
}
