import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CostAccountingComponent } from './cost-accounting/cost-accounting.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CostAccountingService } from '../services/cost-accounting.service';

@NgModule({
  declarations: [
    AppComponent,
    CostAccountingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [CostAccountingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
