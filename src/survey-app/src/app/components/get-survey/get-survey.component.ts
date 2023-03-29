import { Component } from '@angular/core';

import { SurveyData } from 'src/app/entities';

@Component({
  templateUrl: './get-survey.component.html',
})
export class GetSurveyComponent {
  public get survey(): SurveyData {
    return {
      name       : 'test',
      description: 'test',
    };
  }

  public ok(): void {}
}
