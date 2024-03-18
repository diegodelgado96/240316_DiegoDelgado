import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

import { ModalEventoComponent } from '../layout/Modals/modal-evento/modal-evento.component';
import { EventoInterface } from '../../Interfaces/eventoInterface';
import { EventoService } from '../../Services/evento.service';
import { UtilityService } from '../../Services/utility.service';
import { SharedModule } from '../../Modules/shared/shared.module';
import Swal from 'sweetalert2';
import { ModificacionEventoService } from '../../Services/modificacionEvento.service';

@Component({
  selector: 'app-evento',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './evento.component.html',
  styleUrl: './evento.component.css',
  providers: [
    EventoService,
    ModificacionEventoService
  ]
})
export class EventoComponent implements OnInit, AfterViewInit{

  columnsTable: string[] = [
    "NombreInstitucion",
    "DireccionInstitucion",
    "NumeroAlumnos",
    "FechaInicio",
    "CostoServicio",
    "TogaBirrete",
    "NumeroReferencia",
    "Acciones"
  ]

  dataInicio: EventoInterface[] = [];
  dataListEventos = new MatTableDataSource(this.dataInicio);

  @ViewChild(MatPaginator)paginationTable!: MatPaginator;

  constructor(private dialog:MatDialog, private evento: EventoService, private utility: UtilityService)
  {
  }

  getEventos() {
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

  ngAfterViewInit(): void {
    this.dataListEventos.paginator = this.paginationTable;
  }

  ngOnInit(): void {
    this.getEventos();
  }

  filterFunc(event:Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataListEventos.filter = filterValue.trim().toLocaleLowerCase();
  }

  formatFecha(fecha: string): string {
    const date = new Date(fecha);
    const formattedDate = date.toLocaleString('es-ES', {
      year: '2-digit',
      month: '2-digit',
      day: '2-digit',
      hour: '2-digit',
      minute: '2-digit',
      second: '2-digit'
    });
    return formattedDate;
  }

  newEvent() {
    this.dialog.open(ModalEventoComponent, {
      disableClose: true
    }).afterClosed().subscribe( value => {
      if(value === "true")
        this.getEventos();
    })
  }

  updateEvent(evento: EventoInterface) {
    this.dialog.open(ModalEventoComponent, {
      disableClose: true,
      data: evento
    }).afterClosed().subscribe( value => {
      console.log(value)
      if(value === "true")
        this.getEventos();
    })
  }

  deleteEvent(evento: EventoInterface) {
    Swal.fire({
      title: "¿Desea eliminar el evento?",
      text: evento.nombreInstitucion,
      icon: "warning",
      confirmButtonColor: "#3085d6",
      confirmButtonText: "Si, Eliminar.",
      showCancelButton: true,
      cancelButtonColor: "d33",
      cancelButtonText: "No, Volver."
    }).then((result) => {
      if(result.isConfirmed) 
      {
        this.evento.delete(evento.eventoId).subscribe({
          next: (response) => {
            if(response.success) 
            {
              this.utility.alertView("Evento Eliminado", "Listo");
              this.getEventos();
            }
            else
            {
              this.utility.alertView("No se elimino el evento.", "Error");
            }
          },
          error: (e) => {
            console.error(e);
          }
        })
      }
    })
  }

}
