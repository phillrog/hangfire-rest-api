export enum AgendamentoEnum {
	UnicoImediato = 1,
	Unico = 2,
	Diario = 3,
	Semanal = 4,
	Mensal = 5,
	Horario = 6,
	Minuto = 7
}

export enum ServiceEnum {
	Rest = 1
}

export enum VerboEnum {
	Get = 1,
	Post = 2,
	Put = 3,
	Delete = 4
}

export class TarefaModel {
    Id: any;
	Nome: string;
	NomeCompleto: string;
	Url: string;
	Body: any;
	DataAgendamento: Date;
	HoraAgendamento: string;
	DataInicio: Date;
	TipoAgendamento: AgendamentoEnum;
	Agendamento: string;
	TipoVerbo: VerboEnum;
	Horas: number;
	Minutos: number;
	Verbo: string;
	TipoService: ServiceEnum;
	Service: string;
	Selecionado: boolean;
	Edicao: boolean;
    Ativo: boolean;

	/**
	 *
	 */
	constructor(nome: string, url: string, dataAgendamento: Date, horaAgendamento: string,
		tipoAgendamento: number,
		tipoServico: number,
		tipoVerbo: number,
		payload: string
		) {
		this.Nome = nome;
		this.Url = url;
		this.DataAgendamento = dataAgendamento;
		this.HoraAgendamento = horaAgendamento;
		this.TipoAgendamento = tipoAgendamento;
		this.TipoService = tipoServico;
		this.TipoVerbo = tipoVerbo;
		this.Body = payload;
	}
}