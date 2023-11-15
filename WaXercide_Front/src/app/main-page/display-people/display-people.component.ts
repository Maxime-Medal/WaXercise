import { Component } from '@angular/core';
import { PeopleDTO } from '../../models/peopleDTO';
import { PeopleService } from '../../services/people.service';

@Component({
  selector: 'app-display-people',
  templateUrl: './display-people.component.html',
  styleUrl: './display-people.component.css'
})
export class DisplayPeopleComponent {
  public peoples: PeopleDTO[] = [];

  constructor(
    private _peopleSercice: PeopleService
  ) { }
  ngOnInit(): void {
    this._peopleSercice.peoples$.subscribe(p => this.peoples = p);
  }


}
