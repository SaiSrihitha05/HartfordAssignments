import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterModule, RouterOutlet } from '@angular/router';
import { Auth } from '../../../services/auth';
import { Router } from '@angular/router';
import { inject } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  imports: [CommonModule,RouterModule,RouterOutlet],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})

export class Dashboard {
  //DI
  public authService=inject(Auth);
  private router=inject(Router);

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
