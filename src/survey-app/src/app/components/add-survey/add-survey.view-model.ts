import { Injectable } from '@angular/core';

import { map        } from 'rxjs';
import { Observable } from 'rxjs';

import { SurveyEntity  } from 'src/app/entities';
import { SurveyService } from 'src/app/services';

@Injectable()
export class AddSurveyViewModel {
  private surveyValue: undefined | SurveyEntity;

  public constructor(public readonly service: SurveyService) {}

  public get survey(): SurveyEntity {
    if (!this.surveyValue) {
      this.surveyValue = {
        surveyId: '',
        name: '',
        description: '',
      };
    }

    return this.surveyValue;
  }

  public add(): Observable<void> {
    return this.service.addSurvey(this.survey)
                       .pipe(map(entity => {
                         this.survey.surveyId = entity.surveyId;
                       }));
  }
}
