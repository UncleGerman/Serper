import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from 'src/app/entity/user/User';
import { AuntificationUserParameters } from '../../entity/user/AuntificationParameters';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  private url = "api/user";

  public Insert(user: User) {
    return this.http.post(this.url, user);
  }

  public Update () {

  }

  public GetAll() {
    return this.http.get<Array<User>>(this.url +"/GetUsers");
  }

  public GetById(id: string) {
    return this.http.get(this.url +"/GetUser" + id);
  }
}
