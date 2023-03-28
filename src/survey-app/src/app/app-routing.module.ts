import { NgModule     } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Routes       } from '@angular/router';

import { AddSurveyComponent } from './components';

const routes: Routes = [
  {
    path: 'survey/new',
    component: AddSurveyComponent,
  },
  {
    path: '**',
    pathMatch: 'full',
    redirectTo: 'survey/new',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
