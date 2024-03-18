import { Routes } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { EventoComponent } from '../evento/evento.component';
import { ModificacionesEventoComponent } from '../modificaciones-evento/modificaciones-evento.component';

export const routes: Routes = [
    {
        path: "", 
        component: LayoutComponent,
        children: [
          {
            path: "Evento", 
            component: EventoComponent
          },
          {
            path: "ModificacionesEvento", 
            component: ModificacionesEventoComponent
          },
        ]
      }
];
