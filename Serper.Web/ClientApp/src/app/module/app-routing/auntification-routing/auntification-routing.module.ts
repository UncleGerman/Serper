import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { SignupComponent } from '../../../components/auntification/signup/signup.component';
import { SigninComponent } from '../../../components/auntification/signin/signin.component';
import { ForgotPasswordComponent } from 'src/app/components/auntification/forgot-password/forgot-password.component';

const routes: Routes = [
  { path: "signup", component: SignupComponent },
  { path: "signin", component: SigninComponent },
  { path: "forgotpassword", component: ForgotPasswordComponent}
];

@NgModule({
  declarations: [],

  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class AuntificationRoutingModule { }
