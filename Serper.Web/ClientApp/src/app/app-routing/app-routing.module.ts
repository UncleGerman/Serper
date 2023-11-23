import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from '../components/base/home/home.component';
import { NotFoundComponent } from '../components/base/not-found/not-found.component';

const appRoutes: Routes = [
  { path: "", component: HomeComponent },
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
