import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Patient } from '../../../services/patient';
import { inject } from '@angular/core';

@Component({
  selector: 'app-overview',
  imports: [CommonModule],
  templateUrl: './overview.html',
  styleUrl: './overview.css',
})

export class Overview {
  //variables
  appointments: any[] = [];

  //DI
  private patientService=inject(Patient);

  ngOnInit(): void {
    this.loadPatientData();
  }

  //get appointments of logged in patient
  loadPatientData() {
    this.patientService.getMyAppointments().subscribe({
      next: (res) => this.appointments = res,
      error: (err) => console.error('Error loading patient data', err)
    });
  }
}
