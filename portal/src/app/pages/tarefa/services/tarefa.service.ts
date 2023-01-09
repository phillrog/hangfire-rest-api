import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { TarefaModel } from '../models/tarefa.model';


@Injectable({
  providedIn: 'root'
})
export class TarefaService {
  baseUrl: any;

  constructor( private httpCLient: HttpClient) {
      this.baseUrl = environment.hangfireTarefaApi;
  }

  toModel(agendamento: any) : TarefaModel {
      return new TarefaModel(
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

  agendar(agendamento: TarefaModel) : Observable<any> {
      return this.httpCLient.post(`${this.baseUrl}agendar`, agendamento );
  }
}
