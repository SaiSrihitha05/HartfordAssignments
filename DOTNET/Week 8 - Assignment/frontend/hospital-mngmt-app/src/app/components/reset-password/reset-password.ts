import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Auth } from '../../services/auth';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { inject } from '@angular/core';

@Component({
  selector: 'app-reset-password',
  imports: [FormsModule,CommonModule],
  templateUrl: './reset-password.html',
  styleUrl: './reset-password.css',
})

export class ResetPassword {
  //variables
  token: string = '';
  newPassword: string = '';
  isLoading: boolean = false;
  
  // DI
  private route=inject(ActivatedRoute);
  private authService=inject(Auth);
  private router=inject(Router);

  // token will be sent as query parameter hence using queryParams to use it
  ngOnInit() {
    this.token = this.route.snapshot.queryParams['token'];
  }

  // calling auth service to use reset password method where user can update their new password
  onReset() {
    this.isLoading = true;
    const data = { token: this.token, newPassword: this.newPassword };
    this.authService.resetPassword(data).subscribe({
      next: () => {
        alert("Password updated! Log in now.");
        this.router.navigate(['/login']); //
      },
      error: () => {
        alert("Invalid or expired token.");
        this.isLoading = false;
      }
    });
  }
}
