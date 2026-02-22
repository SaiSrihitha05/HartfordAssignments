import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Doctor } from '../../../services/doctor';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { inject } from '@angular/core';

@Component({
  selector: 'app-complete-profile',
  imports: [FormsModule,CommonModule],
  templateUrl: './complete-profile.html',
  styleUrl: './complete-profile.css',
})

export class CompleteProfile {

  profileData = {
    name: '',
    specialization: '',
    experienceYears: 0
  };

  isEditMode = false;
  isEditing = false;

  //DI
  private doctorService=inject(Doctor);
  private router=inject(Router);

  ngOnInit(): void {
    this.loadProfile();
  }

  //get profile of doctor
  loadProfile() {
    this.doctorService.getMyProfile().subscribe({
      next: (res) => {
        if (res) {
          this.profileData = res;
          this.isEditMode = true;
          this.isEditing = false; 
        } else {
          this.isEditMode = false;
          this.isEditing = true; 
        }
      },
      error: (err) => {
        console.error('Error fetching profile', err);
        this.isEditing = true;
      }
    });
  }

  //to change edit status
  toggleEdit() {
    this.isEditing = !this.isEditing;
  }

  //method to post complete profile data
  onSubmit() {
    this.doctorService.completeProfile(this.profileData).subscribe({
      next: (res) => {
        alert('Profile updated successfully!');
        this.isEditMode = true;
        this.isEditing = false; 
      },
      error: (err) => alert('Error updating profile')
    });
  }
}
