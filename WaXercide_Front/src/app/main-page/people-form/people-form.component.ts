import { Component } from '@angular/core';
import { People } from '../../models/people';
import { Validators, FormBuilder } from '@angular/forms';
import { PeopleService } from '../../services/people.service';

@Component({
  selector: 'app-people-form',
  templateUrl: './people-form.component.html',
  styleUrl: './people-form.component.css'
})
export class PeopleFormComponent {
  get firstName() { return this.peopleForm.get('firstName'); }
  get lastName() { return this.peopleForm.get('lastName'); }
  get email() { return this.peopleForm.get('email'); }
  get birthDate() { return this.peopleForm.get('birthDate'); }


  peopleForm = this._fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    birthDate: ['', Validators.required]
    // company: ['', Validators.required],

  });

  constructor(
    private _fb: FormBuilder,
    private _peopleService: PeopleService) { }

  onSubmit() {
    const newSalarie: People = {
      firstName: this.firstName.value,
      lastName: this.lastName.value,
      birthDate: this.birthDate.value,
    }
    this._peopleService.sendPeople(newSalarie).subscribe(p => {
      if (p) {
        this._peopleService.getPeoples().subscribe();
      }
    })
  }


}
