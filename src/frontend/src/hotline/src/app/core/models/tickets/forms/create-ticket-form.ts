import {FormControl} from '@angular/forms';

export interface CreateTicketForm {
  title: FormControl<string>
  description: FormControl<string>
}
