import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeelistComponent } from './components/employees/employeelist/employeelist.component';
import { EmploycreateUpdateComponent } from './components/employees/employcreate-update/employcreate-update.component';
import { DatalistComponent } from './components/datalist/datalist.component';

const routes: Routes = [{
  path:'',
  component:EmployeelistComponent
},
{
  path:'employeeList',
  component:EmployeelistComponent
},
{
  path:'employee/create',
  component:EmploycreateUpdateComponent
},
{
  path:'employee/edit/:id',
  component:EmploycreateUpdateComponent
},
{
  path:'list',
  component:DatalistComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
