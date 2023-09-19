import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { ActivatedRoute, Router } from '@angular/router';
import { FileUploader } from 'ng2-file-upload';
import { distinctUntilChanged, map, filter } from 'rxjs';
import { FormExtension } from 'src/app/configs/form-extension';
import { City } from 'src/app/models/city.model';
import { Country } from 'src/app/models/country.model';
import { Department } from 'src/app/models/department.model';
import { Employee } from 'src/app/models/employee.model';
import { State } from 'src/app/models/state.model';
import { CityService } from 'src/app/services/city.service';
import { CountryService } from 'src/app/services/country.service';
import { DepartmentService } from 'src/app/services/department.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { StateService } from 'src/app/services/state.service';
import { environment } from 'src/enviroments/enviroment';

@Component({
  selector: 'app-employcreate-update',
  templateUrl: './employcreate-update.component.html',
  styleUrls: ['./employcreate-update.component.scss']
})
export class EmploycreateUpdateComponent implements OnInit {

  errors: any;
  formData: any;

  employeeId: number;
  employeeForm: FormGroup;
  employeeFormValue: any;
  isEdit = false;

  today = new Date();

  picture: any;
  avaterPreview: any;
  employee: Employee;
  
  countryId: number;
  countries: Country[];
  filteredCountries: Country[];

  departmentId: number;
  departments: Department[];
  filteredDepartments: Department[];

  stateId: number;
  states: State[];
  filteredStates: State[];

  cityId: number;
  cities: City[];
  filteredCities: City[];

  public uploader: FileUploader;
  uploadUrl: string;

  genders = [
    {value: "Male", text: "Male"},
    {value: "Female", text: "Female"},
    {value: "Other", text: "Other"},
  ];

  constructor(
    public http: HttpClient,
    public fb: FormBuilder,
    public employeeService: EmployeeService,
    public countryService: CountryService,
    public stateService: StateService,
    public cityService: CityService,
    public departmentservice : DepartmentService,
    private router: Router,
    private cd: ChangeDetectorRef,
    private acRoute: ActivatedRoute  ) {   }

  ngOnInit(): void {
    this.acRoute.params.subscribe((params) => (this.employeeId = params["id"] ? Number(params["id"]) : 0));
    this.isEdit = !!this.employeeId;
    this.employeeForm = this.form;
    this.employeeForm.patchValue({ id: this.employeeId });
    this.getEmployeeDetail(this.employeeId);
    this.uploader = new FileUploader({});
    this.getCountry();
    //this.getdepartment();
    this.employeeForm
      .get("countryId")
      ?.valueChanges.pipe(distinctUntilChanged())
      .subscribe({
        next: (countryId: number) => {
          this.countryId = countryId;
          this.getState(countryId);
          //console.log(countryId);
          
        },
      });
    this.employeeForm
      .get("stateId")
      ?.valueChanges.pipe(distinctUntilChanged())
      .subscribe({
        next: (stateId: number) => {
          this.stateId = stateId;
          this.getCity(stateId);
          //console.log(stateId);
          
        },
      });
  }

  getEmployeeDetail(employeeId: any) {
    if (!this.employeeId) return;
    this.employeeService.getEmployeeDetail(employeeId).subscribe({
      next: (res: any) => {
        if (res) {
          this.employee = res;
          this.form = res;
        }
      },
      error: (error: any) => {
        //console.error(error);
      },
    });
  }

  getCountry() {
    this.countryService.getAllCountryDetail().subscribe({
      next: (res: any) => {
        console.log(res)
        if (res) {
          this.countries = res;
          this.filteredCountries = res;
        }
      }
    });
  }

  getState(countryId?: number) {
    this.stateService.getAllStateDetail().subscribe((data: any[]) => {
      // console.log('state',data);
      
      if (countryId !== undefined) {
        const filteredData = data.filter(state => state.countryId === countryId);
        this.states = filteredData;
          this.filteredStates = filteredData;
        console.log(filteredData); // Do something with the filtered data
      }
    });
  }


  getCity(stateId?: number) {
    this.cityService.getAllCityDetail().subscribe((data: any[]) => {
      if (stateId !== undefined) {
        const filteredData = data.filter(state => state.stateId === stateId);
        this.cities = filteredData;
          this.filteredCities = filteredData;
         //console.log(filteredData); // Do something with the filtered data
      }
    });
  }

 
  get form(): any {
    return this.fb.group({
      id: [0],
      firstName:["", Validators.required],
      lastName:["", Validators.required],
      email:["",Validators.required],
      phone:["",Validators.required],
      dateOfBirth:["",Validators.required],
      address: ["", Validators.required],
      gender: ["Male", [Validators.required]],
      ssc: [true],
      hsc: [true],
      bsc: [true],
      msc: [false],
      countryId: [],
      stateId: [],
      cityId: [],
      zipCode:[],
      picture: [""],
      pictureFile: []
    });
  }

  set form(data: any) {
    if (data !== null) {
      this.employeeForm.patchValue({
        id: data.id,
        firstName: data.firstName,
        lastName: data.lastName,
        email:data.email,
        phone:data.phone,
        dateOfBirth:data.dateOfBirth,
        address: data.address,
        gender: data.gender,
        ssc: data.ssc,
        hsc: data.hsc,
        bsc: data.bsc,
        msc: data.msc,
        countryId: data.countryId,
        stateId: data.stateId,
        cityId: data.cityId,
        zipCode:data.zipCode,
        picture: data.picture
      });

      this.avaterPreview = data.picture ? `${environment.baseUrl}/${data.picture}` : "";
      this.picture = data.picture;

    }
  }
  dateChange(type: string, event: MatDatepickerInputEvent<Date>) {
    console.log(`${type}: ${event.value}`);
  }

  save(): void {
    this.errors = (this.employeeForm);
    if (this.employeeForm.invalid) {
      this.employeeForm.markAllAsTouched();
      return;
    }

    this.employeeFormValue = this.employeeForm.getRawValue();
    this.employeeForm.patchValue({ picture: this.picture });
    this.formData = FormExtension.toFormData(this.employeeForm);
    console.log(this.formData);

    if (this.employeeFormValue.id > 0) {
      this.employeeService.updateEmployee(this.employeeFormValue.id, this.formData).subscribe({
        next: (n: any) => {
          // this.messageService.success(this.message.updateSuccess);
          this.router.navigate(['employeeList']);
        },
      });
    } else {
      console.log(this.formData)
      this.employeeService.addEmployee(this.formData).subscribe({
        next: (n: any) => {
          // this.messageService.success(this.message.saveSucess);
          this.router.navigate(['employeeList']);
        },
      });
    }
  }

  reset(): void {
    this.employeeForm.reset(this.form.value);
  }

  clearEmployee(): void {
    this.employeeForm.reset();
    this.employeeForm.markAsUntouched();
    // FormExtension.markAllAsUntoched(this.employeeForm);
  }

  uploadFileAttach($event: any) {
    const reader = new FileReader();
    const file = $event.target.files[0];
    console.log(file);
    this.employeeForm.get("image")?.updateValueAndValidity();
    // this.cd.markForCheck();
    if ($event.target.files && $event.target.files.length) {
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.employeeForm.patchValue({
          pictureFile: file,
        });
        this.picture = file;
        this.avaterPreview = reader.result as string;
        // need to run CD since file load runs outside of zone
        this.cd.markForCheck();
      };
      reader.onerror = () => { };
    }

    console.log(this.employeeForm);
    // reader.readAsDataURL(file)
  }

}
