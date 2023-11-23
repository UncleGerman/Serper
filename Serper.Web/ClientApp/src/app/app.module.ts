import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing/app-routing.module';

import { AppComponent } from './components/base/app/app.component';

import { HomeComponent } from './components/base/home/home.component';
import { HeaderComponent } from './components/base/header/header.component';
import { FooterComponent } from './components/base/footer/footer.component';
import { NotFoundComponent } from './components/base/not-found/not-found.component';

import { SearchService } from './service/search.service';

@NgModule({
  declarations: [
    AppComponent,

    HomeComponent,

    HeaderComponent,
    FooterComponent,
    NotFoundComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],

  providers: [SearchService],

  bootstrap: [AppComponent]
})

export class AppModule { }
