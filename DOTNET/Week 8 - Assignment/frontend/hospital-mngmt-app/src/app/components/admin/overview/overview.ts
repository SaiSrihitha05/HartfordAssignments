import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { User } from '../../../services/user';
import { Doctor } from '../../../services/doctor';
import { Appointment } from '../../../services/appointment';
import { inject } from '@angular/core';

@Component({
  selector: 'app-overview',
  imports: [CommonModule],
  templateUrl: './overview.html',
  styleUrl: './overview.css',
})

export class Overview {
  stats = { 
    totalUsers: 0, 
    totalDoctors: 0, 
    totalAppointments: 0 
  };

  //DI
  private user=inject(User);
  private doctor=inject(Doctor);
  private appt=inject(Appointment);

  //on init - get data
  ngOnInit() {
    this.user.getAllAsync().subscribe(res => this.stats.totalUsers = res.length);
    this.doctor.getAll().subscribe(res => this.stats.totalDoctors = res.length);
    this.appt.getAllAdmin().subscribe(res => this.stats.totalAppointments = res.length);
  }
}
