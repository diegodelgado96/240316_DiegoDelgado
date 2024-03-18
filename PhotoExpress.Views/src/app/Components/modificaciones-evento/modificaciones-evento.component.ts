import { Component, OnInit, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { SharedModule } from '../../Modules/shared/shared.module';

import { ModificacionEventoService } from '../../Services/modificacionEvento.service';
import { ModificacionEventoInterface } from '../../Interfaces/modificacionEventoInterface';
import { UtilityService } from '../../Services/utility.service';

@Component({
  selector: 'app-modificaciones-evento',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './modificaciones-evento.component.html',
  styleUrl: './modificaciones-evento.component.css',
  providers: [
    ModificacionEventoService
  ]
})
export class ModificacionesEventoComponent implements OnInit{
  columnsTable: string[] = [
    "FechaModificacion",
    "DetalleAnterior",
    "DetalleActual"
  ]

  dataInicio: ModificacionEventoInterface[] = [];
  dataListEventos = new MatTableDataSource(this.dataInicio);

  @ViewChild(MatPaginator)paginationTable!: MatPaginator;

  constructor(private evento: ModificacionEventoService, private utility: UtilityService)
  {
  }

  getModificaciones() {
    this.evento.list().subscribe({
      next: (response) => {
        if(response.success) {
          this.dataListEventos.data = response.value;
        }
        else {
          this.utility.alertView("No se encontraron eventos", "Ooops");
        }
      },
      error: (e) => {
        console.error(e)
      }
    })
  }

  ngOnInit(): void {
    this.getModificaciones();
  }

  formatFecha(fecha: string): string {
    const date = new Date(fecha);
    const formattedDate = date.toLocaleString('es-ES', {
      year: '2-digit',
      month: '2-digit',
      day: '2-digit'
    });
    return formattedDate;
  }

}
