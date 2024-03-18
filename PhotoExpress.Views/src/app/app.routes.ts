import { Routes } from '@angular/router';
import { EventoComponent } from './Components/evento/evento.component';
import { ModificacionesEventoComponent } from './Components/modificaciones-evento/modificaciones-evento.component';

export const routes: Routes = [
    {
        path: "pages",
        loadChildren: () => import("./Components/layout/layout.routes").then(m=>m.routes)
    },
    {
        path: "**",
        redirectTo: "pages/Evento",
        pathMatch: "full"
    }
];
