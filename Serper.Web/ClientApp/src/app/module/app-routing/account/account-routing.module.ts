import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { AccountComponent } from '../../../components/account/base/account/account.component';
import { RequestComponent } from '../../../components/account/base/request/request.component';
import { UserReqestListComponent } from 'src/app/components/account/user/user-reqest-list/user-reqest-list.component';
import { AppAccountComponent } from 'src/app/components/account/base/app-account/app-account.component';

const routes: Routes = [
  { path: "", component: AppAccountComponent, children: [
    { path: "", component: AccountComponent },

    { path: "send-reqest", component: RequestComponent},

    { path: "user-reqest-list", component: UserReqestListComponent},
  ]},

  

  {
    path: "admin-panel",
    loadChildren: () => import('./admin-panel-routing.module').then(m => m.AdminPanelRoutingModule)
  },

];

@NgModule({
  declarations: [],

  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})

export class AccountRoutingModule { }
