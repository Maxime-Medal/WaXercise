import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of, concatWith, tap } from 'rxjs';
import { People } from '../models/people';
import { PeopleDTO } from '../models/peopleDTO';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  public peoples: PeopleDTO[] = [];
  public peoples$ = new BehaviorSubject<PeopleDTO[]>([]);
  private peopleUrl = `${environment.apiUrl}/People`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(
    private _http: HttpClient
  ) {
    this.getPeoples().subscribe();
  }

  public getPeoples(): Observable<PeopleDTO[]> {
    return of(this.peoples)
      .pipe(
        concatWith(this._http.get<PeopleDTO[]>(this.peopleUrl)),
        tap((p) => {
          this.peoples = p;
          this.peoples$.next(p);
        })
      );
  }

  public sendSalarie(people: People): Observable<People> {
    return this._http.post<People>(this.peopleUrl, people);
  }

}
