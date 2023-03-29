import { Component } from '@angular/core';

import { SurveyData } from 'src/app/entities';

@Component({
  templateUrl: './update-survey.component.html',
})
export class UpdateSurveyComponent {
  public get survey(): SurveyData {
    return {
      name       : 'test',
      description: 'test',
    };
  }

  public ok(): void {}
}
