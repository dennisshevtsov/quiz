import { Injectable } from '@angular/core';

import { SurveyEntity } from '../../entities';

@Injectable()
export class SearchSurveysViewModel {
  public get surveys(): SurveyEntity[] {
    return [];
  }
}
