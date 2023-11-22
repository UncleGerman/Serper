import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { AuntificationUserParameters } from '../../entity/user/AuntificationParameters';

@Injectable()
export class AccountService {

  constructor(private http: HttpClient) { }

  private url = "api/account";

  SignIn(auntificationUserParameters: AuntificationUserParameters) {
    return this.http.post(this.url+"/SignIn", auntificationUserParameters);
  }

  SignUp(auntificationUserParameters: AuntificationUserParameters) {
    return this.http.post(this.url+"/SignUp", auntificationUserParameters);
  }
}
