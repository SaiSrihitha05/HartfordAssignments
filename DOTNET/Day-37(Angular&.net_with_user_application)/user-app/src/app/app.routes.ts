import { Routes } from '@angular/router';
import { AddUsers } from '../components/add-users/add-users';
import { DisplayUsers } from '../components/display-users/display-users';
import { UserDashboard } from '../components/user-dashboard/user-dashboard';
export const routes: Routes = [
    {
    path: '',
    component: UserDashboard,
    children: [
        { path: '', redirectTo: 'add-user', pathMatch: 'full' },
        { path: 'add-user', component: AddUsers },
        { path: 'display-users', component: DisplayUsers }
    ]
  }
];
