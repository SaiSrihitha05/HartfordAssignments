import { Component } from '@angular/core';
import { Auth } from '../../services/auth';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router,RouterLink } from '@angular/router';
import { inject } from '@angular/core';

@Component({
  selector: 'app-register',
  imports: [CommonModule,FormsModule,RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.css',
})

export class Register {
  //variables
  registerData = {
    email: '',
    password: '',
    role: 'Patient' 
  };
  isLoading = false;
  errorMessage = '';

  // DI
  private authService=inject(Auth);
  private router=inject(Router);

  //call register service and redirect to login if registration successful
  onRegister() {
    this.isLoading = true;
    this.errorMessage = '';
    this.authService.register(this.registerData).subscribe({
      next: (response) => {
        this.isLoading = false;
        alert('Registration successful! Redirecting to login...');
        this.router.navigate(['/login']);
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = err.error?.message || 'An error occurred during registration.';
        console.error('Registration error:', err);
      }
    });
  }
}
