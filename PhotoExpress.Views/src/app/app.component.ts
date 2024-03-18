import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EventoComponent } from './Components/evento/evento.component';
import { LayoutComponent } from './Components/layout/layout.component';
import { ModificacionesEventoComponent } from './Components/modificaciones-evento/modificaciones-evento.component';
import { SharedModule } from './Modules/shared/shared.module';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, EventoComponent, LayoutComponent, ModificacionesEventoComponent, SharedModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'PhotoExpress.Views';
}
