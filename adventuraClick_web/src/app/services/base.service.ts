import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { devEnvironment } from 'src/environments/devEnvironment.dev';

export abstract class BaseService<T> {
  protected constructor(
    protected http: HttpClient,
    protected endpoint: string
  ) {}
  url = `${devEnvironment.baseUrl}/api`;

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(`${this.url}/${this.endpoint}`);
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
}
