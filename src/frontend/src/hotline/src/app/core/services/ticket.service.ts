import { inject, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {API_URL} from '../../app.config';
import {Ticket} from '../models/tickets/ticket';
import {CreateTicketRequest} from '../models/tickets/forms/create-ticket-request';

@Injectable({  providedIn: 'root' })

export class TicketService {

  private http = inject(HttpClient);
  private apiUrl = inject(API_URL);

  #tickets = signal<Ticket[]>([]); // # make it private
  tickets = this.#tickets.asReadonly();

  loadAllTickets() {
    this.http.get<Ticket[]>(`${this.apiUrl}/v1/tickets`).subscribe({
      next: (data) => this.#tickets.set(data),
      error: (err) => console.error('Error loading tickets', err)
    });
  }

  createTicket(ticket: CreateTicketRequest) {
    return this.http.post<CreateTicketRequest>(`${this.apiUrl}/v1/tickets`, ticket);
  }


}
