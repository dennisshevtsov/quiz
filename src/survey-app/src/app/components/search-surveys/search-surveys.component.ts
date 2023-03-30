import { Component } from '@angular/core';

import { SurveyEntity           } from '../../entities';
import { SearchSurveysViewModel } from './search-surveys.view-model';

@Component({
  templateUrl: './search-surveys.component.html',
  providers: [SearchSurveysViewModel],
})
export class SearchSurveysComponent {
  public constructor(private readonly vm: SearchSurveysViewModel) {}

  public get surveys() : SurveyEntity[] {
    return this.vm.surveys;
  }
}
