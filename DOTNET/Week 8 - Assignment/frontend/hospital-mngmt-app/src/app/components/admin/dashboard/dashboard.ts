import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { User } from '../../../services/user';
import { Doctor } from '../../../services/doctor';
import { Appointment } from '../../../services/appointment';
import { Router } from '@angular/router';
import { RouterModule } from '@angular/router';
import { inject } from '@angular/core';
@Component({
  selector: 'app-dashboard',
  imports: [CommonModule,RouterLink,RouterModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class Dashboard {
  //variables
  stats = {
      totalUsers: 0,
      totalDoctors: 0,
      totalAppointments: 0
  };

  //DI
  private userService=inject(User);
  private doctorService=inject(Doctor);
  private appointmentService=inject(Appointment);
  private route = inject(Router);

  //on init
  ngOnInit(): void {
    this.loadStats();
  }

  // Fetch counts from your existing services
  loadStats() {
    this.userService.getAllAsync().subscribe(res => this.stats.totalUsers = res.length);
    this.doctorService.getAll().subscribe(res => this.stats.totalDoctors = res.length);
    this.appointmentService.getAllAdmin().subscribe(res => this.stats.totalAppointments = res.length);
  }
}
