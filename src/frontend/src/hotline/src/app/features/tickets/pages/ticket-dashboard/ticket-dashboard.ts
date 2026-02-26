import { Component } from '@angular/core';
import {Router, RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule} from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';


@Component({
  selector: 'app-ticket-dashboard',
  standalone: true,
  imports: [ RouterOutlet, RouterLink, RouterLinkActive, MatTabsModule, MatToolbarModule, MatIconModule],
  templateUrl: './ticket-dashboard.html',
  styleUrl: './ticket-dashboard.scss',
})
export class TicketDashboard {

}
