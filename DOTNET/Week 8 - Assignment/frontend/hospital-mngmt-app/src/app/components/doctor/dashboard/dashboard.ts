import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterModule } from '@angular/router';
import { Auth } from '../../../services/auth';
import { Router } from '@angular/router';
import { inject } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  imports: [CommonModule,RouterLink,RouterModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class Dashboard {
  
  public authService=inject(Auth);
  private router=inject(Router);

  //logout doctor
  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
