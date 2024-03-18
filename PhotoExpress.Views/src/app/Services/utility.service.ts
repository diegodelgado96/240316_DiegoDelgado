import { Injectable } from '@angular/core';

import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {

  constructor(private snackbar: MatSnackBar) {}


  alertView(msj: string, type:string) {
    this.snackbar.open(msj, type, {
      horizontalPosition: "end",
      verticalPosition: "top",
      duration: 3000
    })
  }  

}
