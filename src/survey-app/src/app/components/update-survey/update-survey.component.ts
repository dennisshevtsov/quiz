import { Component } from '@angular/core';
import { OnDestroy } from '@angular/core';

import { Subscription } from 'rxjs';

import { SurveyData            } from 'src/app/entities';
import { UpdateSurveyViewModel } from './update-survey.view-model';

@Component({
  templateUrl: './update-survey.component.html',
  providers: [
    UpdateSurveyViewModel,
    { provide: Subscription, useFactory: () => new Subscription(), },
  ],
})
export class UpdateSurveyComponent implements OnDestroy {
  public constructor(
    private readonly vm : UpdateSurveyViewModel,
    private readonly sub: Subscription,
  ) {}

  public ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  public get survey(): SurveyData {
    return this.vm.survey();
  }

  public ok(): void {
    this.sub.add(this.vm.update().subscribe());
  }
}
