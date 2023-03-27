import { Injectable } from '@angular/core';

import { SurveyEntity } from 'src/app/entities';

@Injectable()
export class AddSurveyViewModel {
  private surveyValue: undefined | SurveyEntity;

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

  public add(): void {}
}
