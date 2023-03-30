import { Injectable } from '@angular/core';

import { map        } from 'rxjs';
import { Observable } from 'rxjs';

import { SurveyService } from '../../services';
import { SurveyEntity  } from '../../entities';

@Injectable()
export class SearchSurveysViewModel {
  private surveysValue: undefined | SurveyEntity[];

  public constructor(private readonly service: SurveyService) {}

  public get surveys(): SurveyEntity[] {
    return this.surveysValue ?? [];
  }

  public initialize(): Observable<void> {
    return this.service.searchSurveys()
                       .pipe(map(surveys => {
                         this.surveysValue = surveys;
                       }));
  }
}
