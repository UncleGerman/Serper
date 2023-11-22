import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing/app-routing.module';

import { AppComponent } from '../components/base/app/app.component';
import { HomeComponent } from '../components/base/home/home.component';
import { HeaderComponent } from '../components/base/header/header.component';
import { FooterComponent } from '../components/base/footer/footer.component';
import { NotFoundComponent } from '../components/base/not-found/not-found.component';

import { RequestComponent } from '../components/account/base/request/request.component';

import {MatFormFieldModule} from '@angular/material/form-field';

import { AccountComponent } from '../components/account/base/account/account.component';
import { AccountNavigationComponent } from '../components/account/base/account-navigation/account-navigation.component';

import { SignupComponent } from '../components/auntification/signup/signup.component';
import { SigninComponent } from '../components/auntification/signin/signin.component';
import { ForgotPasswordComponent } from '../components/auntification/forgot-password/forgot-password.component';
import { UserListComponent } from '../components/account/admin-panel/user/user-list/user-list.component';
import { UserEditComponent } from '../components/account/admin-panel/user/user-edit/user-edit.component';
import { UserInsertComponent } from '../components/account/admin-panel/user/user-insert/user-insert.component';
import { ReqestListComponent } from '../components/account/admin-panel/reqest/reqest-list/reqest-list.component';
import { ReqestInfoComponent } from '../components/account/admin-panel/reqest/reqest-info/reqest-info.component';
import { AdminPanelComponent } from '../components/account/admin-panel/base/admin-panel/admin-panel.component';
import { AdminPanelNavigationComponent } from '../components/account/admin-panel/base/admin-panel-navigation/admin-panel-navigation.component';
import { RoleListComponent } from '../components/account/admin-panel/role/role-list/role-list.component';
import { RoleEditComponent } from '../components/account/admin-panel/role/role-edit/role-edit.component';
import { RoleInsertComponent } from '../components/account/admin-panel/role/role-insert/role-insert.component';
import { RoleInfoComponent } from '../components/account/admin-panel/role/role-info/role-info.component';
import { JwtModule } from '@auth0/angular-jwt';
import { ACCESS_TOKEN_KEY } from '../service/auntification/auntification.service';
import { AppAccountComponent } from '../components/account/base/app-account/app-account.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';

export function tokenGetter() {
  return localStorage.getItem(ACCESS_TOKEN_KEY);
}

@NgModule({
  declarations: [
    //Base Components
    AppComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    NotFoundComponent,

    RequestComponent,

    //Account
    AppAccountComponent,
    AccountComponent,
    AccountNavigationComponent,

    //Admin Panel Base 
    AdminPanelComponent,
    AdminPanelNavigationComponent,

    //Admin Panel User
    UserListComponent,
    UserEditComponent,
    UserInsertComponent,

    //Admin Panel Reqest
    ReqestListComponent,
    ReqestInfoComponent,

    //Admin Panel Role
    RoleListComponent,
    RoleEditComponent,
    RoleInsertComponent,
    RoleInfoComponent,

    //Auntificated
    SignupComponent,
    SigninComponent,
    ForgotPasswordComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule, 
    MatButtonModule, 
    MatIconModule,
    MatSelectModule,
    MatSlideToggleModule,

    JwtModule.forRoot({
      config: {
        tokenGetter
      }
    }),
      BrowserAnimationsModule
  ],

  providers: [
  ],

  bootstrap: [AppComponent]
})

export class AppModule { }
