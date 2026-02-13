import { Component, inject } from '@angular/core';
import {FormBuilder, ReactiveFormsModule, Validators} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { TicketService} from '../../../../core/services/ticket.service';
import { CreateTicketRequest } from '../../../../core/models/tickets/forms/create-ticket-request';
import { CreateTicketForm } from '../../../../core/models/tickets/forms/create-ticket-form';

@Component({
  selector: 'app-ticket-create',
  standalone: true,
  imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './ticket-create.html',
  styleUrl: './ticket-create.scss',
})
export class TicketCreate {

  private fb = inject(FormBuilder);
  private ticketService = inject(TicketService);

  ticketForm = this.fb.group<CreateTicketForm>({
    title:  this.fb.control('', { nonNullable : true,  validators: [Validators.required, Validators.minLength(3), Validators.maxLength(100)]}),
    description: this.fb.control('', { nonNullable: true, validators : [ Validators.required, Validators.minLength(3), Validators.maxLength(500)]})
  });

  onSubmit() {

    if (!this.ticketForm.valid)
      return;

    const data : CreateTicketRequest = this.ticketForm.getRawValue();

    this.ticketService.createTicket(data).subscribe({
      next: (response) => {
        console.log(response);
        this.ticketForm.reset();
      },
      error: (error) => {
        console.error('Error during ticket creation:', error);
      }
    });
  }

}
