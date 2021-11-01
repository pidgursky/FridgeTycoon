import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

// used to create fake backend
import { FakeBackendProvider } from './shared/mocks/fake-backend-interceptor';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ConfigService } from './shared/config.service';

import { AuthCallbackComponent } from './auth-callback/auth-callback.component';

import {  ReactiveFormsModule } from '@angular/forms';

/* Module Imports */
import { CoreModule } from './core/core.module';
import { HomeModule }  from './home/home.module';
import { AccountModule }  from './account/account.module';
import { ShellModule } from './shell/shell.module';
import { FridgeTycoonModule } from './fridge-tycoon/fridge-tycoon.module';
import { SharedModule }   from './shared/shared.module';
import { AddEditComponent } from './fridge-tycoon/index/add-edit.component';
import { ProductListComponent } from './fridge-tycoon/index/product-list.component';
import { AddEditProductComponent } from './fridge-tycoon/index/add-edit-product.component';


@NgModule({
  declarations: [
    AppComponent,
    AuthCallbackComponent,
    AddEditComponent,
    ProductListComponent,
    AddEditProductComponent
  ],
  imports: [
    BrowserModule,  
    HttpClientModule, 
    CoreModule,
    HomeModule,
    AccountModule,
    FridgeTycoonModule,   
    AppRoutingModule,
    ShellModule,   
    SharedModule,
    ReactiveFormsModule 
  ],
  providers: [
    ConfigService,
    // provider used to create fake backend
    FakeBackendProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
