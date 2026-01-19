import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {Customers} from '../components/customers/customers'
import { Header } from "../components/header/header";
import { FormsModule } from '@angular/forms';
import { Navbar } from '../components/navbar/navbar';
import { Description } from '../components/description/description';
import { WelcomeBanner } from '../components/welcome-banner/welcome-banner';
import {InsuranceCards} from '../components/insurance-cards/insurance-cards';
import { Footer } from '../components/footer/footer';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Customers, Header,FormsModule,Navbar,Description,WelcomeBanner,InsuranceCards,Footer],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('first-app');
 
}
