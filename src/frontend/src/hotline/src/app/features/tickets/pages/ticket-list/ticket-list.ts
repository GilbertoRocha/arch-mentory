import { Component, inject, OnInit } from '@angular/core';
import { TicketService } from '../../../../core/services/ticket.service';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-ticket-list',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, MatIconModule],
  templateUrl: './ticket-list.html',
  styleUrl: './ticket-list.scss',
})
export class TicketList implements OnInit {
  ticketService = inject(TicketService);

  ngOnInit() {
    this.ticketService.loadAllTickets();
  }

}
