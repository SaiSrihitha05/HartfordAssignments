import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { User } from '../../../services/user';
import { inject } from '@angular/core';

@Component({
  selector: 'app-user-management',
  imports: [CommonModule],
  templateUrl: './user-management.html',
  styleUrl: './user-management.css',
})

export class UserManagement {
  //variables
  users: any[] = [];
  errorMessage = '';

  //DI
  private userService=inject(User);

  
  ngOnInit(): void {
    this.loadUsers();
  }

  //get all the users
  loadUsers() {
    this.userService.getAllAsync().subscribe({
      next: (res) => this.users = res,
      error: (err) => this.errorMessage = 'Failed to load users.'
    });
  }

  //delete any user
  deleteUser(id: number) {
    if (confirm('Are you sure you want to delete this user?')) {
      this.userService.deleteAsync(id).subscribe({
        next: () => {
          this.users = this.users.filter(u => u.id !== id);
          alert('User deleted successfully');
        },
        error: (err) => alert('Could not delete user.')
      });
    }
  }
}
