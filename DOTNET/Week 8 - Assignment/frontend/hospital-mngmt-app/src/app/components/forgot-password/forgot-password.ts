import { Component } from '@angular/core';
import { Auth } from '../../services/auth';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { inject } from '@angular/core';

@Component({
  selector: 'app-forgot-password',
  imports: [FormsModule],
  templateUrl: './forgot-password.html',
  styleUrl: './forgot-password.css',
})

export class ForgotPassword {

  email: string = '';
  message: string = '';
  isLoading: boolean = false;

  //DI
  private authService=inject(Auth);
  private router=inject(Router);

  //sending a request to reset password
  onSendRequest() {
    this.isLoading = true;
    this.authService.forgotPassword(this.email).subscribe({
      next: (res: any) => {
        // res.token contains the token from the C# backend
        const token = res.token;
        // Automatically redirect to the reset page with the token as a query parameter
        this.router.navigate(['/reset-password'], { queryParams: { token: token } });
      },
      error: (err) => {
        this.message = "User not found or error occurred.";
        this.isLoading = false;
      }
    });
  }
}
