import { HttpClientModule    } from '@angular/common/http';
import { NgModule            } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms'
import { BrowserModule       } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent     } from './app.component';

import { AddSurveyComponent } from './components';
import { SurveyComponent    } from './components';
import { GetSurveyComponent } from './components/get-survey/get-survey.component';

@NgModule({
  declarations: [
    AppComponent,
    AddSurveyComponent,
    SurveyComponent,
    GetSurveyComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
