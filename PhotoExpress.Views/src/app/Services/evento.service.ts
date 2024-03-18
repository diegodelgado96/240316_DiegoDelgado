import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment";
import { ResponseApi } from "../Interfaces/responseApiInterface";
import { EventoInterface } from "../Interfaces/eventoInterface";

@Injectable({
    providedIn:"root"
})

export class EventoService {

    private urlApi:string = `${environment.endpoint}Evento/`; 

    constructor(private http:HttpClient) {        
    }

    list():Observable<ResponseApi>{
        return this.http.get<ResponseApi>(`${this.urlApi}List`)
    }

    create(request: EventoInterface):Observable<ResponseApi>{
        return this.http.post<ResponseApi>(`${this.urlApi}Create`, request)
    }

    update(request: EventoInterface):Observable<ResponseApi>{
        return this.http.put<ResponseApi>(`${this.urlApi}Update`, request)
    }

    delete(requestId: string):Observable<ResponseApi>{
        return this.http.delete<ResponseApi>(`${this.urlApi}Delete/${requestId}`)
    }
}