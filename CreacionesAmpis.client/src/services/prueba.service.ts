import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IGetUsers } from '../interfaces/users';
import { environment } from '../environments/environments';

@Injectable({
  providedIn: 'root',
})
export class pruebaService {
  constructor(private httpClient: HttpClient) {}

  getUser(): Observable<IGetUsers[]> {
    return this.httpClient.get<IGetUsers[]>(`${environment.apiUrl}ControllerPrueba/GetAll`);
  }
}
