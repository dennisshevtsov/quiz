import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { of         } from 'rxjs';

import { SurveyEntity } from 'src/app/entities';

@Injectable()
export class UpdateSurveyViewModel {
  public survey(): SurveyEntity {
    return {
      surveyId   : 'test',
      name       : 'test',
      description: 'test',
    };
  }

  public update(): Observable<void> {
    return of(void 0);
  }
}
