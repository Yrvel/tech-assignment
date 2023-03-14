import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { UsersComponent } from './components/users/users.component';
import { AddressFormattedPipe } from './pipes/address-formatted.pipe';
import { CompanyFormattedPipe } from './pipes/company-formatted.pipe';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    AddressFormattedPipe,
    CompanyFormattedPipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
