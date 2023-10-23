import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { devEnvironment } from 'src/environments/devEnvironment.dev';
import { getQueryString } from '../utils/queryString';

export abstract class BaseService<T> {
  protected constructor(
    protected http: HttpClient,
    protected endpoint: string
  ) {}
  url = `${devEnvironment.baseUrl}/api`;

  getAll(search = {}): Observable<T[]> {
    const queryString = getQueryString(search);
    const url = `${this.url}/${this.endpoint}`;
    const uri = `${url}?${queryString}`;

    return this.http.get<T[]>(`${uri}`);
  }

  getById(id: number): Observable<T> {
    return this.http.get<T>(`${this.url}/${this.endpoint}/${id}`);
  }

  create(entity: T): Observable<T> {
    return this.http.post<T>(`${this.url}/${this.endpoint}`, entity);
  }

  update(id: number, entity: T): Observable<T> {
    return this.http.put<T>(`${this.url}/${this.endpoint}/${id}`, entity);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${this.endpoint}/${id}`);
  }

  changeStatus(id: number, status: any): Observable<T> {
    return this.http.put<T>(`${this.url}/${this.endpoint}/${id}/status`, { status });
  }
}
