import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

<<<<<<< HEAD
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from './core/core.module';
import { ShopModule } from './shop/shop.module';

=======
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
>>>>>>> 1355107d207ef4aab3d353c4f74cba355b53c810

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
<<<<<<< HEAD
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    ShopModule
=======
    BrowserAnimationsModule
>>>>>>> 1355107d207ef4aab3d353c4f74cba355b53c810
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
