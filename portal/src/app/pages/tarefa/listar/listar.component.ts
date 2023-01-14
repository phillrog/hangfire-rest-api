import { AfterViewInit, ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbSortDirection, NbSortRequest, NbTreeGridDataSource, NbTreeGridDataSourceBuilder, NbTreeGridPresentationNode } from '@nebular/theme';
import { TarefaModel } from '../models/tarefa.model';
import { TarefaService } from '../services/tarefa.service';

interface TreeNode<T> {
  data: T;
}

@Component({
  selector: 'ngx-listar',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.scss']
})
export class ListarComponent implements AfterViewInit {

  constructor(private router: Router,
    private route: ActivatedRoute,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<TarefaModel>,
    private tarefaService: TarefaService) {
    this.dataSource = this.dataSourceBuilder.create([]);
  }

  ngAfterViewInit(): void {
    this.carregar();
  }

  incluir() {
    this.router.navigate(['../incluir'], { relativeTo: this.route });
  }

  defaultColumns = ['nomeCompleto', 'url', 'verbo', 'dataAgendamento'];
  defaultName = {'nomeCompleto' : 'Nome Completo', 'url': 'Url', 'verbo': 'Verbo', 'dataAgendamento': 'Data Agendamento'};
  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<TarefaModel>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;


  updateSort(sortRequest: NbSortRequest): void {
    this.sortColumn = sortRequest.column;
    this.sortDirection = sortRequest.direction;
  }

  getSortDirection(column: string): NbSortDirection {
    if (this.sortColumn === column) {
      return this.sortDirection;
    }
    return NbSortDirection.NONE;
  }

  getShowOn(index: number) {
    const minWithForMultipleColumns = 400;
    const nextColumnStep = 100;
    return minWithForMultipleColumns + (nextColumnStep * index);
  }

  public data: TarefaModel[] = [];
  carregar(): void {
    this.tarefaService.listar().subscribe((response: any) => {
      const data = response.map(m => new NbTreeGridPresentationNode(m, [], false, 0)) ;
      this.dataSource.setData( data);
    });
  }
}
