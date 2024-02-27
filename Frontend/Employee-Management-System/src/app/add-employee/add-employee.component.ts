import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { SharedService } from '../shared.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  addEmployeeRequest: any = {
    id: '',
    firstName: '',
    lastName: '',
    department: '',
    address: '',
    mobileNumber: 0,
    email: '',
    birthday: new Date(),
    creationDate: new Date(),
  };
  sharedService: any;

  constructor(private service: SharedService, private cdr: ChangeDetectorRef,private router: Router) {}

  ngOnInit(): void {
    
  }

  addEmployee() {
    this.sharedService.addEmployee(this.addEmployeeRequest).subscribe({
      next: () => {
        console.log('Employee added successfully'); 
        this.router.navigate(['/employee']);
      },
      error: () => {
        console.error('Error adding employee:');
      }
     
    });
    
  }
}
