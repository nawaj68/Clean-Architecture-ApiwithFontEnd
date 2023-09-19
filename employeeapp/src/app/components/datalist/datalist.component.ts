import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subject, debounceTime, distinctUntilChanged, map, pipe, share, startWith, switchMap,merge } from 'rxjs';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-datalist',
  templateUrl: './datalist.component.html',
  styleUrls: ['./datalist.component.scss']
})
export class DatalistComponent implements OnInit {
  employeeId: number;
  employee: Employee;
  employees: Employee[];

  displayedColumns: string[] = [
    'picture',
    'name',
    'address',
    'gender',
    'country',
    'state',
    'city',
    'action',
  ];

    dataSource: MatTableDataSource<Employee> = new MatTableDataSource();

    isLoadingResults = true;
    pageSizeOptions: number[] = [5, 10, 25, 100];
    pageIndex = 0;
    pageSize = 5;
    length = 0;
  
    selection = new SelectionModel<Employee>(true, []);
    filterInput: Subject<string> = new Subject<string>();
    filterValue: string = "";
    
    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;
  
    constructor(private employeeService: EmployeeService) {}
  

  ngOnInit(): void {
console.log(this.employee);
this.getData();
  }

  ngAfterViewInit(): void {
    this.sort.sortChange.subscribe(() => (this.paginator.pageIndex = 0));
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.getData();
  }

   customPipe = pipe(
    share(),
    debounceTime(1000),
    distinctUntilChanged(),
    startWith({}),
    switchMap(() => {
      this.isLoadingResults = true;
      return this.load();
    }),
    map((data: any) => {
      this.isLoadingResults = false;

      if (data === null) {
        return [];
      }

      return data;
    })
  );

  customSubscribe = (data: any) => {
    this.employees = data.data.data;
    this.dataSource = new MatTableDataSource(data.data.data);
    this.paginator.pageIndex = data.data.pageIndex;
    this.paginator.length = data.data.total;
  };

    load(): any {
    return this.employeeService.getAllEmployeeDetail(     
       this.paginator.pageIndex,
      this.paginator.pageSize,);


  }

  getData(): void {
    merge(this.sort.sortChange, this.paginator.page, this.filterInput)
      .subscribe((data: any) => {
        console.log(data);
        this.dataSource=data;
       
        
      });
    }

    reload(reloadType: boolean): void {
      if (reloadType) {
        this.paginator.pageIndex = 0;
        this.filterValue = "";
      }
  
      this.getData();
    }
    
    pageChanged(event: PageEvent) {
      this.paginator.pageSize = event.pageSize;
      this.paginator.pageIndex = event.pageIndex;
    }

    remove(employeeId: number): void {
      if (employeeId) {
        var ans = confirm('Do you delete this Id: ' + employeeId);
        if (ans) {
          debugger
          this.employeeService.delete(employeeId).subscribe((e) => {});
          window.location.reload();
        }
      }
  
    }
}
