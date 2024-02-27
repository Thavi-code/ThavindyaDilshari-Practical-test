import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router'; 
import { SharedService } from '../../shared.service';


@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']  
})

export class ShowEmpComponent implements OnInit {
  filteredEmployeeList: any;
  filters: any = {
    employeeName: '',
    department: ''
  };

  EmployeeList: any  = [];

  constructor(private service: SharedService, private cdr: ChangeDetectorRef, private router: Router) {}

  ngOnInit(): void {
    this.service.getEmpList().subscribe(dataItem  => {
      this.EmployeeList = dataItem ;
      this.cdr.detectChanges();
      console.log('EmployeeList:', this.EmployeeList);
    });
  }

  applyFilters() {
    this.filteredEmployeeList = this.EmployeeList.filter((employee: any) => {
      const nameMatches =
        !this.filters.employeeName ||
        (employee.FirstName && employee.FirstName.toLowerCase().includes(this.filters.employeeName.toLowerCase())) ||
        (employee.LastName && employee.LastName.toLowerCase().includes(this.filters.employeeName.toLowerCase()));

      const departmentMatches =
        !this.filters.department ||
        (employee.Department && employee.Department.toLowerCase().includes(this.filters.department.toLowerCase()));

      return nameMatches && departmentMatches;
    });
  }

  updateEmployee(employeeId: number) {
    this.router.navigate(['/addemployee', employeeId]);
  }

  deleteEmployee(employeeId: number) {
    this.service.deleteEmployee(employeeId).subscribe(() => {
      this.applyFilters(); 
    });
  }
}
