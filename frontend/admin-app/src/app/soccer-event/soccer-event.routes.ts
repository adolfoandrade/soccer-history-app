import { Route } from "@angular/router";
import { AddComponent } from "./add/add.component";
import { SoccerEventComponent } from "./soccer-event.component";
import { UpdateComponent } from "./update/update.component";

export const SoccerEventRoutes: Route[] = [
  {
    path: '',
    component: SoccerEventComponent,
  },
  {
    path: 'add',
    component: AddComponent,
  },
  {
    path: 'update',
    component: UpdateComponent,
  },
];
