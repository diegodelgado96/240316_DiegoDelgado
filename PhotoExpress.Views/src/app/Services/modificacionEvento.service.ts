import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment";
import { ResponseApi } from "../Interfaces/responseApiInterface";
import { ModificacionEventoInterface } from "../Interfaces/modificacionEventoInterface";


@Injectable({
    providedIn:"root"
})

export class ModificacionEventoService {

    private urlApi:string = environment.endpoint + 'ModificacionEvento/'; 

    constructor(private http:HttpClient) {        
    }

    list():Observable<ResponseApi>{
        return this.http.get<ResponseApi>(this.urlApi+"List")
    }

    create(request: ModificacionEventoInterface):Observable<ResponseApi>{
        return this.http.post<ResponseApi>(this.urlApi + "Create", request)
    }

}