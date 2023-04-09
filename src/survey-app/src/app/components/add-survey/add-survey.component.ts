import { Component } from '@angular/core';
import { OnDestroy } from '@angular/core';

import { Router } from '@angular/router';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Subscription } from 'rxjs';

import { SurveyData         } from '../../entities';
import { AddSurveyViewModel } from './add-survey.view-model';

@Component({
  templateUrl: './add-survey.component.html',
  providers: [
    AddSurveyViewModel,
    { provide: Subscription, useFactory: () => new Subscription(), },
  ],
})
export class AddSurveyComponent implements OnDestroy {
  public constructor(
    private readonly vm    : AddSurveyViewModel,
    private readonly sub   : Subscription,
    private readonly router: Router,
    private readonly sb    : MatSnackBar,
  ) {}

  public ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  public get survey(): SurveyData {
    return this.vm.survey;
  }

  public ok(): void {
    this.sub.add(this.vm.add().subscribe({
      complete: () => {
        this.sb.open('The new survey is created.', 'Undo');
        this.router.navigate(['survey', this.vm.survey.surveyId]);
      },
      error   : () => this.sb.open('An error occured.', 'Undo'),
    }));
  }
}
