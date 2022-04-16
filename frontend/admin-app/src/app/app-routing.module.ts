import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: () => import('../app/soccer-event/soccer-event.module').then(x => x.SoccerEventModule) },
  { path: 'teams', loadChildren: () => import('../app/soccer-team/soccer-team.module').then(x => x.SoccerTeamModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
