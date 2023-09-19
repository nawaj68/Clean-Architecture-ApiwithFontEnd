import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeelistComponent } from './components/employees/employeelist/employeelist.component';
import { EmploycreateUpdateComponent } from './components/employees/employcreate-update/employcreate-update.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './shared/material/material.module';
import { AvatarPipe } from './configs/pipe/avatar.pipe';
import { DatalistComponent } from './components/datalist/datalist.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeelistComponent,
    EmploycreateUpdateComponent,
    AvatarPipe,
    DatalistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
