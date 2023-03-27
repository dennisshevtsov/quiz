import { Component } from '@angular/core';

import { SurveyData         } from '../../entities';
import { AddSurveyViewModel } from './add-survey.view-model';

@Component({
  templateUrl: './add-survey.component.html',
  providers: [AddSurveyViewModel],
})
export class AddSurveyComponent {
  public constructor(private readonly vm: AddSurveyViewModel) {}

  public get survey(): SurveyData {
    return this.vm.survey;
  }

  public ok(): void {
    this.vm.add();
  }
}
