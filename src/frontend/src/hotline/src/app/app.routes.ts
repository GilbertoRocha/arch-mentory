import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'dashboard',
    loadComponent: () => import('./features/tickets/pages/ticket-dashboard/ticket-dashboard').then(m => m.TicketDashboard),
    children: [
      { path: 'listAll', loadComponent: () => import('./features/tickets/pages/ticket-list/ticket-list').then(m => m.TicketList) },
      { path: 'new', loadComponent: () => import('./features/tickets/pages/ticket-create/ticket-create').then(m => m.TicketCreate) },
    ]
  },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full'},
];
