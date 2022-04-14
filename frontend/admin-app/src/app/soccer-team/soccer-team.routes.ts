import { Route } from '@angular/router';

import { SoccerTeamComponent } from './soccer-team.component';
import { AddSoccerTeamComponent } from './add-soccer-team/add-soccer-team.component';
import { UpdateComponent } from '../soccer-event/update/update.component';

export const SoccerTeamRoutes: Route[] = [
  {
    path: '',
    component: SoccerTeamComponent,
  },
  {
    path: 'add',
    component: AddSoccerTeamComponent,
  },
  {
    path: 'update',
    component: UpdateComponent,
  },
];
