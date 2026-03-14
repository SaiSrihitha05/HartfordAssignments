import { Routes } from '@angular/router';
import { Login } from './components/login/login';
import { Register } from './components/register/register';
import { Dashboard } from './components/doctor/dashboard/dashboard';
import { ForgotPassword } from './components/forgot-password/forgot-password';
import { ResetPassword } from './components/reset-password/reset-password';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: Login },
  { path: 'register', component: Register },
  { path: 'forgot-password', component: ForgotPassword },
  { path: 'reset-password', component: ResetPassword }, 
  // Admin Routes
  {
    path: 'admin',
    loadComponent: () => import('./components/admin/dashboard/dashboard').then(m => m.Dashboard),
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { 
        path: 'dashboard', 
        loadComponent: () => import('./components/admin/overview/overview').then(m => m.Overview) 
      },
      { 
        path: 'user-management', 
        loadComponent: () => import('./components/admin/user-management/user-management').then(m => m.UserManagement) 
      },
      { 
        path: 'appointment-management', 
        loadComponent: () => import('./components/admin/appointment-management/appointment-management').then(m => m.AppointmentManagement) 
      },
    ]
  },
// Doctor Routes
  {
    path: 'doctor',
    component: Dashboard, 
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { 
        path: 'dashboard', 
        loadComponent: () => import('./components/doctor/overview/overview').then(m => m.Overview) 
      },
      { 
        path: 'complete-profile', 
        loadComponent: () => import('./components/doctor/complete-profile/complete-profile').then(m => m.CompleteProfile) 
      },
      { 
        path: 'my-appointments', 
        loadComponent: () => import('./components/doctor/appointments/appointments').then(m => m.Appointments) 
      },
    ]
  },

  // Patient Routes
  {
    path: 'patient',
    loadComponent: () => import('./components/patient/dashboard/dashboard').then(m => m.Dashboard) ,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { 
        path: 'dashboard', 
        loadComponent: () => import('./components/patient/overview/overview').then(m => m.Overview) 
      },
      { 
        path: 'complete-profile', 
        loadComponent: () => import('./components/patient/complete-profile/complete-profile').then(m => m.CompleteProfile) 
      },
      { 
        path: 'book-appointment', 
        loadComponent: () => import('./components/patient/book-appointment/book-appointment').then(m => m.BookAppointment) 
      },
      {
        path:'my-appointments',
        loadComponent:() =>import('./components/patient/my-appointments/my-appointments').then(m=>m.MyAppointments)
      }
    ]
  },
  // Wildcard route for 404
  { path: '**', redirectTo: 'login' }
];