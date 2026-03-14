import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService, User } from '../../services/user-service';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-add-users',
  imports: [CommonModule, FormsModule],
  templateUrl: './add-users.html',
  styleUrls: ['./add-users.css'],
})
export class AddUsers {

  private userService = inject(UserService);

  user: User = {
    username: '',
    emailId: '',
    dateOfBirth: '',
    address: ''
  };

onSubmit(form: NgForm) { 
    this.userService.addUser(this.user).subscribe({
      next: () => {
        alert('User added successfully');
        form.resetForm();
      },
      error: (err) => {
        console.error(err);
        alert('Error adding user');
      }
    });
  }
}
