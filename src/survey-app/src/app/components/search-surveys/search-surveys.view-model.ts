import { Injectable } from '@angular/core';

import { map        } from 'rxjs';
import { Observable } from 'rxjs';
import { switchMap  } from 'rxjs';

import { SurveyEntity   } from '../../entities';
import { SurveyIdentity } from '../../entities';
import { SurveyService  } from '../../services';

@Injectable()
export class SearchSurveysViewModel {
  private surveysValue: undefined | SurveyEntity[];

  public constructor(private readonly service: SurveyService) {}

  public get surveys(): SurveyEntity[] {
    return this.surveysValue ?? [];
  }

  private setSurveys(value: SurveyEntity[]) {
    this.surveysValue = value;
  }

  public initialize(): Observable<void> {
    return this.service.searchSurveys()
                       .pipe(map(this.setSurveys));
  }

  public delete(survey: SurveyIdentity): Observable<void> {
    return this.service.deleteSurvey(survey)
                       .pipe(switchMap(this.initialize));
  }
}
