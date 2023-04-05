import { Injectable } from '@angular/core';

import { map        } from 'rxjs';
import { Observable } from 'rxjs';

import { SurveyEntity  } from 'src/app/entities';
import { SurveyService } from 'src/app/services';

@Injectable()
export class UpdateSurveyViewModel {
  private surveyValue: undefined | SurveyEntity;

  public constructor(private readonly service: SurveyService) {}

  public get survey(): SurveyEntity {
    if (!this.surveyValue) {
      this.surveyValue = {
        surveyId   : '',
        name       : '',
        description: '',
      };
    }

    return this.surveyValue;
  }

  public initialize(): Observable<void> {
    return this.service.getSurvey(this.survey)
                       .pipe(map(survey => {
                         this.surveyValue = survey;
                       }))
  }

  public update(): Observable<void> {
    return this.service.updateSurvey(this.survey)
                       .pipe(map(() => {}));
  }
}
