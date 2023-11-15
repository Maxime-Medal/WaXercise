import { Injectable } from '@angular/core';
import { Compagny } from '../models/compagny';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompagnyService {
  private compagnyUrl = `${environment.apiUrl}/People`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(
    private _http: HttpClient
  ) {
  }


  public sendSalarie(compagny: Compagny): Observable<Compagny> {
    return this._http.post<Compagny>(this.compagnyUrl, compagny);
  }
}
