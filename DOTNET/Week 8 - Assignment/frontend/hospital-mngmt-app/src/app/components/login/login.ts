import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router,RouterLink } from '@angular/router';
import { Auth } from '../../services/auth';
import { ChangeDetectorRef } from '@angular/core';
import { inject } from '@angular/core';

@Component({
  selector: 'app-login',
  imports: [CommonModule,FormsModule,RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css',
})

export class Login {
  loginData = {
    email: '',
    password: ''
  };
  errorMessage = '';
  isLoading = false;
  captchaCode: string = '';
  userInput: string = '';

  //DI
  private authService=inject(Auth);
  private router=inject(Router);
  private cdr=inject(ChangeDetectorRef);

  ngOnInit() {
    this.generateCaptcha();
  }

  //login based redirection - along with captcha funcitonality 
  onLogin() {
    //Capture the input and the current code
    const enteredValue = this.userInput.toUpperCase();
    const actualCode = this.captchaCode.toUpperCase();
    // Perform the comparison
    if (enteredValue !== actualCode) {
      this.errorMessage = 'Incorrect CAPTCHA code. Please try again.';
      this.generateCaptcha(); // Refresh ONLY on failure
      this.userInput = '';    
      return;
    }
    
    this.isLoading = true;
    this.errorMessage = '';
    this.authService.login(this.loginData).subscribe({
      next: (res) => {
        this.isLoading = false;
        // Redirect based on role
        if (res.role === 'Admin') {
          this.router.navigate(['/admin/dashboard']);
        } else if (res.role === 'Doctor') {
          this.router.navigate(['/doctor/dashboard']);
        } else {
          this.router.navigate(['/patient/dashboard']);
        }
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = err.error?.message || 'Invalid email or password';
      }
    });
  }
  // method to call service for generating captcha
  generateCaptcha() {
    this.authService.getCaptcha().subscribe({
      next: (res) => {
        this.captchaCode = res.captchaCode;
        this.cdr.detectChanges();
        console.log("New Captcha:", this.captchaCode);
      },
      error: (err) => console.error("Captcha failed to load", err)
    });
  }

}



