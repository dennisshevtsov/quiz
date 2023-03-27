import { NgModule      } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent     } from './app.component';
import { AddSurveyComponent } from './components/add-survey/add-survey.component';

@NgModule({
  declarations: [AppComponent, AddSurveyComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
