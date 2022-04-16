import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddSoccerTeamComponent } from './add-soccer-team/add-soccer-team.component';
import { UpdateSoccerTeamComponent } from './update-soccer-team/update-soccer-team.component';
import { SoccerTeamComponent } from './soccer-team.component';
import { SoccerTeamRoutes } from './soccer-team.routes';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
    SoccerTeamComponent,
    AddSoccerTeamComponent,
    UpdateSoccerTeamComponent,
  ],
  imports: [
    MatCardModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    CommonModule,
    RouterModule.forChild(SoccerTeamRoutes),
  ],
})
export class SoccerTeamModule {}
