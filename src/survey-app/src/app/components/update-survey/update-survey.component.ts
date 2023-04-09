import { Component } from '@angular/core';
import { OnDestroy } from '@angular/core';
import { OnInit    } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { ParamMap       } from '@angular/router';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Subscription } from 'rxjs';
import { switchMap    } from 'rxjs';

import { SurveyData            } from 'src/app/entities';
import { UpdateSurveyViewModel } from './update-survey.view-model';

@Component({
  templateUrl: './update-survey.component.html',
  providers: [
    UpdateSurveyViewModel,
    { provide: Subscription, useFactory: () => new Subscription(), },
  ],
})
export class UpdateSurveyComponent implements OnInit, OnDestroy {
  public constructor(
    private readonly vm   : UpdateSurveyViewModel,
    private readonly sub  : Subscription,
    private readonly route: ActivatedRoute,
    private readonly sb   : MatSnackBar,
  ) {}

  public ngOnInit(): void {
    const project = (params: ParamMap) => {
      this.vm.survey.surveyId = params.get('surveyId')!;

      return this.vm.initialize();
    }

    this.sub.add(
      this.route.paramMap.pipe(switchMap(project))
                         .subscribe());
  }

  public ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  public get survey(): SurveyData {
    return this.vm.survey;
  }

  public ok(): void {
    this.sub.add(this.vm.update().subscribe({
      complete: () => this.sb.open('The survey is updated.', 'Close'),
      error   : () => this.sb.open('An error occured.', 'Close'),
    }));
  }
}
