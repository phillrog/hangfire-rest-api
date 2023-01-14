import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'Cadastros',
    icon: 'edit-2-outline',
    children: [
      {
        title: 'Tarefa',
        link: '/pages/tarefas/listar',
      }
    ],
  }
];
