export interface ErrorDetail {
  message: string;
}

export interface Result<T> {
  value: T | null;
  isSuccess: boolean;
  error?: ErrorDetail;
}
