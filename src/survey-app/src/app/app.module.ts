import { HttpClientModule    } from '@angular/common/http';
import { NgModule            } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms'
import { BrowserModule       } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent     } from './app.component';

import { AddSurveyComponent     } from './components';
import { SearchSurveysComponent } from './components';
import { SurveyComponent        } from './components';
import { UpdateSurveyComponent  } from './components';

@NgModule({
  declarations: [
    AppComponent,
    AddSurveyComponent,
    SearchSurveysComponent,
    SurveyComponent,
    UpdateSurveyComponent,
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
