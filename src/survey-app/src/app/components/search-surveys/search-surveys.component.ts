import { Component } from '@angular/core';

import { SurveyEntity } from '../../entities';

@Component({
  templateUrl: './search-surveys.component.html',
})
export class SearchSurveysComponent {
  public get surveys() : SurveyEntity[] {
    return [];
  }
}
