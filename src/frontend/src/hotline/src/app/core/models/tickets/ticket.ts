export interface Ticket {
  id: number;
  externalId: string;
  title: string;
  description: string;
  createdAt: Date;
  updatedAt: Date;
  resolvedAt: Date;
  status: number;
}
