import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Patient } from '../../../services/patient';
import { inject } from '@angular/core';

@Component({
  selector: 'app-complete-profile',
  imports: [CommonModule,FormsModule],
  templateUrl: './complete-profile.html',
  styleUrl: './complete-profile.css',
})

export class CompleteProfile implements OnInit{
  //variables
  profileData = {
    name: '',
    age: 0,
    gender: 'Male',
    phone: ''
  };
  isEditMode = false; 

  //DI
  private patientService=inject(Patient);
  private router=inject(Router);

  ngOnInit(): void {
    this.loadProfile();
  }

  //to update profile data for patient
  loadProfile() {
    this.patientService.getMyProfile().subscribe({
      next: (data) => {
        if (data) {
          // If data exists, fill the object
          this.profileData = {
            name: data.name,
            age: data.age,
            gender: data.gender,
            phone: data.phone
          };
          this.isEditMode = true;
        }
      },
      error: (err) => {
        console.log("No profile found yet, showing empty form.");
      }
    });
  }

  //post updated data to backend
  onSubmit() {
    this.patientService.completeProfile(this.profileData).subscribe({
      next: () => {
        alert(this.isEditMode ? 'Profile updated!' : 'Profile completed!');
        this.router.navigate(['/patient/dashboard']);
      },
      error: (err) => alert(err.error?.message || 'Action failed')
    });
  }
}
