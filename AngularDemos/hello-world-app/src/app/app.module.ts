import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AppCalculatorComponent } from './components/app-calculator/app-calculator.component';
import { NgForOfComponent } from './components/ng-for-of/ng-for-of.component';
import { Ngfordemo2Component } from './components/ngfordemo2/ngfordemo2.component';

@NgModule({
  declarations: [
    AppComponent,
    AppCalculatorComponent,
    NgForOfComponent,
    Ngfordemo2Component
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
