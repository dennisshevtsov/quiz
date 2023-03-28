import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { of         } from 'rxjs';

import { SurveyData   } from '../entities';
import { SurveyEntity } from '../entities';

@Injectable()
export class SurveyService {
  public addSurvey(survey: SurveyData): Observable<SurveyEntity> {
    return of({
      surveyId   : 'test',
      name       : 'test',
      description: 'test',
    });
  }
}
