import { Component } from '@angular/core';
import { OnDestroy } from '@angular/core';
import { OnInit    } from '@angular/core';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Subscription } from 'rxjs';

import { SurveyEntity           } from '../../entities';
import { SearchSurveysViewModel } from './search-surveys.view-model';

@Component({
  templateUrl: './search-surveys.component.html',
  providers: [
    SearchSurveysViewModel,
    { provide: Subscription, useFactory: () => new Subscription() },
  ],
})
export class SearchSurveysComponent implements OnInit, OnDestroy {
  public constructor(
    private readonly vm : SearchSurveysViewModel,
    private readonly sub: Subscription,
    private readonly sb : MatSnackBar,
  ) {}

  public ngOnInit(): void {
    this.sub.add(this.vm.initialize().subscribe());
  }

  public ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  public get surveys() : SurveyEntity[] {
    return this.vm.surveys;
  }

  public delete(survey: SurveyEntity): void {
    this.sub.add(this.vm.delete(survey).subscribe({
      complete: () => this.sb.open(`Survey ${survey.name}`, 'Close'),
      error   : () => this.sb.open('An error occured.', 'Close'),
    }));
  }
}
