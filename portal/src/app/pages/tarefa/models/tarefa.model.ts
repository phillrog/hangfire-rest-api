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
    public Id: any;
	public Nome: string;
	public NomeCompleto: string;
	public Url: string;
	public Body: any;
	public DataAgendamento: Date;
	public HoraAgendamento: string;
	public DataInicio: Date;
	public TipoAgendamento: AgendamentoEnum;
	public Agendamento: string;
	public TipoVerbo: VerboEnum;
	public Horas: number;
	public Minutos: number;
	public Verbo: string;
	public TipoService: ServiceEnum;
	public Service: string;
	public Selecionado: boolean;
	public Edicao: boolean;
    public Ativo: boolean;
}