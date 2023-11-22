import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { AuntificationUserParameters } from 'src/app/entity/user/AuntificationParameters';

export const ACCESS_TOKEN_KEY = ".AspNetCore.Identity.Application";

@Injectable({
  providedIn: 'root'
})
export class AuntificationService {
  constructor(
    private http: HttpClient,
    private jwtHelper: JwtHelperService,
    private router: Router) { }


  public SignUp(auntificationUserParameters: AuntificationUserParameters) {
    return this.http.post("api/account/SignUp", auntificationUserParameters);
  }

  public SignIn(auntificationUserParameters: AuntificationUserParameters) : Observable<AuntificationUserParameters> {
    return this.http.post("api/account/SignIn", auntificationUserParameters);
  }

  public isAuntification(): boolean {
    let token = localStorage.getItem(ACCESS_TOKEN_KEY);
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  public LogOut() {
    localStorage.removeItem(ACCESS_TOKEN_KEY);
    this.router.navigate([""]);
    return this.http.post("${this.apiUrl}account/LogOut", "");
  }
}
