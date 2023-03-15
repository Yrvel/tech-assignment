import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../models/user.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  endpointURL: string = environment.baseUrl;

  constructor(protected http: HttpClient) { }

  public getUsers(): Observable<User[]> {
    return this.http
    .get(this.endpointURL +'/users')
    .pipe(map(res => <User[]>res));
  }
}
