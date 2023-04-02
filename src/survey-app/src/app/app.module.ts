import { HttpClientModule    } from '@angular/common/http';
import { NgModule            } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms'

import { BrowserModule           } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatButtonModule    } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule      } from '@angular/material/icon';
import { MatInputModule     } from '@angular/material/input';
import { MatListModule      } from '@angular/material/list';
import { MatSidenavModule   } from '@angular/material/sidenav';
import { MatTableModule     } from '@angular/material/table';
import { MatToolbarModule   } from '@angular/material/toolbar';

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
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,

    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatSidenavModule,
    MatTableModule,
    MatToolbarModule,

    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
