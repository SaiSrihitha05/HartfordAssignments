// import { Component } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { UserService, User } from '../../services/user-service';
import { inject } from '@angular/core';
import { DatePipe } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';
@Component({
  selector: 'app-display-users',
  imports: [DatePipe],
  templateUrl:'./display-users.html',
  styleUrl: './display-users.css',
})
export class DisplayUsers {
    users: User[] = [];
    private userService=inject(UserService);
    private cdr = inject(ChangeDetectorRef);
    ngOnInit(): void {
      this.loadUsers();
    }
    loadUsers() {
      this.userService.getUsers().subscribe({
        
        next: (data) => {
          console.log("API data:", data);
          this.users = data;
          this.cdr.detectChanges();
        },
        error: (err) => console.error(err)
      });
    }
}
