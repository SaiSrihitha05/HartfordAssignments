import { Component } from '@angular/core';
import { AddUsers } from "../add-users/add-users";
import { DisplayUsers } from "../display-users/display-users";
import { RouterModule, RouterOutlet } from '@angular/router';
@Component({
  selector: 'app-user-dashboard',
  imports: [RouterOutlet,RouterModule],
  templateUrl: './user-dashboard.html',
  styleUrl: './user-dashboard.css',
})
export class UserDashboard {

}
