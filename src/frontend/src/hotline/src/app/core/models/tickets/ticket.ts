export interface Ticket {
  externalId: string;
  title: string;
  description: string;
  createdAt: Date;
  updatedAt: Date;
  resolvedAt: Date;
  status: number;
}
