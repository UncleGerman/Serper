import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AuntificationService } from 'src/app/service/auntification/auntification.service';
import { UserService } from '../../../service/user/user.service';

import { AuntificationUserParameters } from '../../../entity/user/AuntificationParameters';

import { User } from 'src/app/entity/user/User';
import { FormValidatorService } from 'src/app/service/formValidator/form-validator.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['../auntification.scss'],
  providers: [
    AuntificationService,
    UserService,
    FormValidatorService
  ],
})
export class SignupComponent {
  constructor(
    private _auntificationService: AuntificationService,
    private _userService: UserService,
    private _router: Router,
    private _formValidatorService: FormValidatorService) { }

  ngOnInit() {
    this.SignUpForm = new FormGroup({
      email: new FormControl("",
        [
          Validators.required,
          Validators.email
        ]),

      password: new FormControl("",
        [
          Validators.required,
          Validators.pattern(/(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*#?&^_-])/),
          Validators.minLength(8),
        ])
    });
  }

  public Hide: boolean = true;

  public AuntificationParameters: AuntificationUserParameters;

  public SignUpForm!: FormGroup;

  public SignUp(SignUpForm: FormGroup) {
    this.AuntificationParameters = {
      UserName: SignUpForm.value.email,
      Email: SignUpForm.value.email,
      Password: SignUpForm.value.password
    };

    this._auntificationService.SignUp(this.AuntificationParameters)
      .subscribe((data) => { },
        (error) => {
          if (error == undefined) {
            this._router.navigate(["account"]);
          }
        });

    let user: User = {
      userName: this.AuntificationParameters.Email,
      email: this.AuntificationParameters.Email,
      password: this.AuntificationParameters.Password
    };

    this._userService.Insert(user);
  }

  public GetPasswordErrors() {
    return this._formValidatorService.GetPasswordErrors(this.SignUpForm);
  }

  public GetEmailErrors() {
    return this._formValidatorService.GetEmailErrors(this.SignUpForm);
  }
}
