import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddSoccerTeamComponent } from './add-soccer-team/add-soccer-team.component';
import { UpdateSoccerTeamComponent } from './update-soccer-team/update-soccer-team.component';
import { SoccerTeamRoutes } from './soccer-team.routes';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    AddSoccerTeamComponent,
    UpdateSoccerTeamComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(SoccerTeamRoutes)
  ]
})
export class SoccerTeamModule { }
