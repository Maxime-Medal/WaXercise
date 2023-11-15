import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DisplayPeopleComponent } from './main-page/display-people/display-people.component';
import { PeopleFormComponent } from './main-page/people-form/people-form.component';

@NgModule({
  declarations: [
    AppComponent,
    DisplayPeopleComponent,
    PeopleFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
