import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Doctor } from '../../../services/doctor';
import { inject } from '@angular/core';

@Component({
  selector: 'app-doctor-management',
  imports: [CommonModule],
  templateUrl: './doctor-management.html',
  styleUrl: './doctor-management.css',
})
export class DoctorManagement {
  //variables
  doctors: any[] = [];
  isLoading = true;

  //DI
  private doctorService=inject(Doctor);

  //on init
  ngOnInit(): void {
    this.loadDoctors();
  }

  //get all doctors
  loadDoctors() {
    this.doctorService.getAll().subscribe({
      next: (res) => {
        this.doctors = res;
        this.isLoading = false;
      },
      error: (err) => {
        console.error(err);
        this.isLoading = false;
      }
    });
  }


  //remove doctor by sending doctor id
  removeDoctor(id: number) {
    if (confirm('Are you sure you want to remove this doctor profile?')) {
      this.doctorService.deleteAsync(id).subscribe({
        next: () => {
          this.doctors = this.doctors.filter(d => d.id !== id);
        },
        error: (err) => alert('Error deleting doctor')
      });
    }
  }
  
}
