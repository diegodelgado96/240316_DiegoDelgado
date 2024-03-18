import { Component, OnInit, Inject } from '@angular/core';

import { FormBuilder, FormGroup, Validators} from '@angular/forms'
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EventoInterface } from '../../../../Interfaces/eventoInterface';
import { SharedModule } from '../../../../Modules/shared/shared.module';

import { EventoService } from '../../../../Services/evento.service';
import { UtilityService } from '../../../../Services/utility.service';
import { ModificacionEventoInterface } from '../../../../Interfaces/modificacionEventoInterface';
import { ModificacionEventoService } from '../../../../Services/modificacionEvento.service';

@Component({
  selector: 'app-modal-evento',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './modal-evento.component.html',
  styleUrl: './modal-evento.component.css',
  providers: [
    EventoService,
    ModificacionEventoService
  ]
})
export class ModalEventoComponent implements OnInit {
  ngOnInit(): void {
    if(this.datosEvento !== null) {
      this.oldEvent = this.datosEvento;
      this.formularioEvento.patchValue({
        nombreInstitucion: this.datosEvento.nombreInstitucion,
        direccionInstitucion: this.datosEvento.direccionInstitucion,
        numeroAlumnos: this.datosEvento.numeroAlumnos,
        fechaInicio: this.formatFecha(this.datosEvento.fechaInicio),
        horaInicio: this.formatHora(this.datosEvento.fechaInicio),
        costoServicio: this.datosEvento.costoServicio,
        togaBirrete: this.datosEvento.togaBirrete,
      })
    }
  }

  formularioEvento: FormGroup; 
  tittle: string = "Agregar";
  buttonAccion: string = "Guardar";
  costoTotal:number = 200;
  oldEvent?: EventoInterface;


  constructor(
    private modal: MatDialogRef<ModalEventoComponent>, 
    @Inject(MAT_DIALOG_DATA) public datosEvento: EventoInterface,
    private fb: FormBuilder,
    private evento: EventoService,
    private modificacionEvento: ModificacionEventoService,
    private utility: UtilityService) 
  {

    this.formularioEvento = this.fb.group({
      nombreInstitucion: ['', Validators.required],
      direccionInstitucion: ['', Validators.required],
      numeroAlumnos: [0, Validators.required],
      fechaInicio: [new Date(), Validators.required],
      horaInicio: [new Date(), Validators.required],
      costoServicio: [0, Validators.required],
      togaBirrete: [false, Validators.required],
    });

    if(this.datosEvento !== null){
      this.tittle = "Editar";
      this.buttonAccion = "Actualizar";
    }
  }

  calcularCostoTotal(): number {
    if(this.formularioEvento.value.togaBirrete) 
      this.costoTotal = (this.formularioEvento.value.numeroAlumnos * 20 + 200);
    else 
      this.costoTotal = 200;
    return this.costoTotal;
  }

  formatFecha(fecha: string): string {
    const date = new Date(fecha);
    const formattedDate = date.toISOString().split('T')[0]; // Obtener solo la parte de la fecha
    return formattedDate;
  }

  formatHora(fecha: string): string {
      const date = new Date(fecha);
      const formattedHora = date.toTimeString().split(' ')[0]; // Obtener solo la parte de la hora
      return formattedHora;
  }

  modificacionesObject(evento: EventoInterface, oldEdvento: any): ModificacionEventoInterface {
    var oldChange = "";
    var change = "";

    if(evento.nombreInstitucion !== oldEdvento.nombreInstitucion) {
      oldChange += " nombreInstitucion: " + oldEdvento.nombreInstitucion;
      change += " nombreInstitucion: " + evento.nombreInstitucion;
    }
    if(evento.direccionInstitucion !== oldEdvento.direccionInstitucion) {
      oldChange += " direccionInstitucion: " + oldEdvento.direccionInstitucion;
      change += " direccionInstitucion: " + evento.direccionInstitucion;
    }
    if(evento.numeroAlumnos !== oldEdvento.numeroAlumnos) {
      oldChange += " numeroAlumnos: " + oldEdvento.numeroAlumnos;
      change += " numeroAlumnos: " + evento.numeroAlumnos;
    }
    if(evento.fechaInicio !== oldEdvento.fechaInicio) {
      oldChange += " fechaInicio: " + oldEdvento.fechaInicio;
      change += " fechaInicio: " + evento.fechaInicio;
    }
    if(evento.costoServicio !== oldEdvento.costoServicio) {
      oldChange += " costoServicio: " + oldEdvento.costoServicio;
      change += " costoServicio: " + evento.costoServicio;
    }
    if(evento.togaBirrete !== oldEdvento.togaBirrete) {
      oldChange += " togaBirrete: " + oldEdvento.togaBirrete;
      change += " togaBirrete: " + evento.togaBirrete;
    }

    var modificaciones: ModificacionEventoInterface = {
      ModificacionId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
      FechaModificacion: new Date(),
      DetalleAnterior: oldChange,
      DetalleActual: change,
      EventoId: evento.eventoId
    }

    return modificaciones;
  }

  saveEditEvento(){
    const evento: EventoInterface = {
      eventoId: this.datosEvento == null? "3fa85f64-5717-4562-b3fc-2c963f66afa6": this.datosEvento.eventoId,
      nombreInstitucion: this.formularioEvento.value.nombreInstitucion,
      direccionInstitucion: this.formularioEvento.value.direccionInstitucion,
      numeroAlumnos: this.formularioEvento.value.numeroAlumnos,
      fechaInicio: new Date(this.formularioEvento.value.fechaInicio + 'T' + this.formularioEvento.value.horaInicio).toISOString(),
      costoServicio: this.costoTotal,
      togaBirrete: this.formularioEvento.value.togaBirrete,
      fechaCreacion: new Date().toISOString(),
      numeroReferencia: ""
    }

    if(this.datosEvento == null) {
      this.evento.create(evento).subscribe({
        next: (result) => {
          if(result.success) {
            this.utility.alertView("Evento Guardado Correctamente con numero de serie: " + result.value.numeroReferencia, 'Success')
            this.modal.close("true")
          }
          else {
            this.utility.alertView("No se regisstro el evento", "Error")
          }
        }
      })
    }
    else 
    {
      this.evento.update(evento).subscribe({
        next: (result) => {
          if(result.success) {
            this.modificacionEvento.create(this.modificacionesObject(evento, this.oldEvent)).subscribe({
              next: (value) => {
                if(value.success){
                  this.utility.alertView("Evento fue Editado Correctamente", 'Success')
                  this.modal.close("true")
                }
                else {
                  this.utility.alertView("No se Edito el evento", "Error")
                }
              }
            })
          }
          else {
            this.utility.alertView("No se Edito el evento", "Error")
          }
        }
      })
    }  
  }
    
}
