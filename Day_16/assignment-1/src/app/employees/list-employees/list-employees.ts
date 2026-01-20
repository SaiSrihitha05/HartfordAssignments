import { Component } from '@angular/core';
import { Employee } from '../../../models/employee';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-list-employees',
  imports: [DatePipe],
  templateUrl: './list-employees.html',
  styleUrl: './list-employees.css',
})
export class ListEmployees {
  employee:Employee[] =[
    {
      id: 1,
      name: 'Mark',
      gender: 'Male',
      contactPreference: 'Email',
      email: 'mark@pragimtech.com',
      dateOfBirth: new Date('10/25/1988'),
      department: 'IT',
      isActive: true,
      photoPath: 'download.png'
    },
    {
      id: 2,
      name: 'Mary',
      gender: 'Male',
      contactPreference: 'Phone',
      phoneNumber: 2345978640,
      dateOfBirth: new Date('11/20/1979'),
      department: 'HR',
      isActive: true,
      photoPath: 'download.jpg'
    },
    {
      id: 3,
      name: 'John',
      gender: 'Female',
      contactPreference: 'Phone',
      phoneNumber: 5432978640,
      dateOfBirth: new Date('3/25/1976'),
      department: 'IT',
      isActive: false,
      photoPath: 'download (1).jpg'
    },
        {
      id: 4,
      name: 'Mark',
      gender: 'Male',
      contactPreference: 'Email',
      email: 'mark@pragimtech.com',
      dateOfBirth: new Date('10/25/1988'),
      department: 'IT',
      isActive: true,
      photoPath: 'download.png'
    },
    {
      id: 5,
      name: 'Mary',
      gender: 'Male',
      contactPreference: 'Phone',
      phoneNumber: 2345978640,
      dateOfBirth: new Date('11/20/1979'),
      department: 'HR',
      isActive: true,
      photoPath: 'download.jpg'
    },
    {
      id: 6,
      name: 'John',
      gender: 'Female',
      contactPreference: 'Phone',
      phoneNumber: 5432978640,
      dateOfBirth: new Date('3/25/1976'),
      department: 'IT',
      isActive: false,
      photoPath: 'download (1).jpg'
    }
]

  

}
