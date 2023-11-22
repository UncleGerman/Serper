import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { AuntificationUserParameters } from 'src/app/entity/user/AuntificationParameters';
import { AuntificationService } from '../../../service/auntification/auntification.service';
import { FormValidatorService } from 'src/app/service/formValidator/form-validator.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['../auntification.scss'],
  providers: [
    AuntificationService,
    FormValidatorService,
  ]
})
export class SigninComponent {
  constructor(
    private auntificationService: AuntificationService,
    private router: Router,
    private formValidatorService: FormValidatorService) { }

  ngOnInit() {
    this.SignInForm = new FormGroup({
      Email: new FormControl("", 
      [
        Validators.required,
        Validators.email
      ]),
      Password: new FormControl("", 
      [
        Validators.required,
        Validators.pattern(/(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*#?&^_-])/),
        Validators.minLength(8),
      ]),
      RememberMe: new FormControl("")
    });
  }

  public hide: boolean = true;

  public SignInForm: FormGroup;

  public signIn(SignInForm: FormGroup) {
    let auntificationUserParameters: AuntificationUserParameters = {
      UserName: SignInForm.value.Email,
      Email: SignInForm.value.Email,
      Password: SignInForm.value.Password,
      RememberMe: SignInForm.value.RememberMe
    };

    this.auntificationService.SignIn(auntificationUserParameters).subscribe();
  }

  public GetEmailErrors() {
    return this.formValidatorService.GetEmailErrors(this.SignInForm);
  }

  public GetPasswordErrors() {
    return this.formValidatorService.GetPasswordErrors(this.SignInForm);
  }
}
