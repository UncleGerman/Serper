import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from '../../components/base/home/home.component';
import { NotFoundComponent } from '../../components/base/not-found/not-found.component';

const appRoutes: Routes = [
  { path: "", component: HomeComponent },

  {
    path: "auntification",
    loadChildren: () => import('./auntification-routing/auntification-routing.module').then(a => a.AuntificationRoutingModule)
  },

  {
    path: "account",
    loadChildren: () => import('./account/account-routing.module').then(a => a.AccountRoutingModule)
  },

  { path: "**", component: NotFoundComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],

  exports: [
    RouterModule
  ]
})

export class AppRoutingModule { }
