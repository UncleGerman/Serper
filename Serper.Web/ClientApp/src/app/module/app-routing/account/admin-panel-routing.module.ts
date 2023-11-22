import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { AdminPanelComponent } from 'src/app/components/account/admin-panel/base/admin-panel/admin-panel.component';

import { ReqestInfoComponent } from 'src/app/components/account/admin-panel/reqest/reqest-info/reqest-info.component';
import { ReqestListComponent } from 'src/app/components/account/admin-panel/reqest/reqest-list/reqest-list.component';

import { UserListComponent } from 'src/app/components/account/admin-panel/user/user-list/user-list.component';
import { UserEditComponent } from 'src/app/components/account/admin-panel/user/user-edit/user-edit.component';
import { UserInsertComponent } from 'src/app/components/account/admin-panel/user/user-insert/user-insert.component';
import { RoleListComponent } from 'src/app/components/account/admin-panel/role/role-list/role-list.component';
import { RoleInsertComponent } from 'src/app/components/account/admin-panel/role/role-insert/role-insert.component';
import { RoleEditComponent } from 'src/app/components/account/admin-panel/role/role-edit/role-edit.component';

const routes: Routes = [
  { path: "", component: AdminPanelComponent },

  { path: "reqest-list", component: ReqestListComponent },
  { path: "reqest-info/:id", component: ReqestInfoComponent },

  { path: "user-list", component: UserListComponent },
  { path: "user-edit/:id", component: UserEditComponent },
  { path: "user-insert", component: UserInsertComponent },

  { path: "role-list", component: RoleListComponent },
  { path: "role-edit/:id", component: RoleEditComponent },
  { path: "role-insert", component: RoleInsertComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class AdminPanelRoutingModule { }
