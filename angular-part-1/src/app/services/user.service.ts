import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  endpointURL: string = 'https://jsonplaceholder.typicode.com/users' ;

  constructor(protected http: HttpClient) { }

  public getUsers(): Observable<User[]> {
    return this.http
    .get(this.endpointURL)
    .pipe(map(res => <User[]>res));
  }
}
