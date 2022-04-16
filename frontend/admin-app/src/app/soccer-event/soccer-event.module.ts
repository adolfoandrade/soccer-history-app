import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AddComponent } from './add/add.component';
import { SoccerEventRoutes } from './soccer-event.routes';
import { UpdateComponent } from './update/update.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { SoccerEventComponent } from './soccer-event.component';

@NgModule({
  declarations: [SoccerEventComponent,AddComponent, UpdateComponent],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    RouterModule.forChild(SoccerEventRoutes),
  ],
})
export class SoccerEventModule {}
