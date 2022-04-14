import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AddComponent } from "./add/add.component";
import { SoccerEventRoutes } from "./soccer-event.routes";
import { UpdateComponent } from "./update/update.component";

@NgModule({
  declarations: [
    AddComponent,
    UpdateComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(SoccerEventRoutes)
  ]
})
export class SoccerEventModule { }
