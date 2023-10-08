import { HttpHeaders } from '@angular/common/http';

export function createHttpHeaders() {
  let headers = new HttpHeaders();
  headers = headers.set('Authorization', `Basic ${btoa('x:x')}`);
  headers = headers.set('Content-Type', 'application/json');
  return headers;
}
