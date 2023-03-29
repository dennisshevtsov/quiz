import { Component    } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Input        } from '@angular/core';
import { Output       } from '@angular/core';

import { FormBuilder } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { FormGroup   } from '@angular/forms';
import { Validators  } from '@angular/forms';

import { SurveyData } from '../../entities';

type SurveyFormScheme = {
  [K in keyof SurveyData]: FormControl<SurveyData[K] | null>;
};

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
})
export class SurveyComponent {
  private surveyValue: undefined | SurveyData;
  private formValue  : undefined | FormGroup<SurveyFormScheme>;

  private okValue : EventEmitter<void>;

  public constructor(private readonly fb: FormBuilder) {
    this.okValue = new EventEmitter<void>();
  }

  public get survey(): SurveyData {
    return this.surveyValue ?? (this.surveyValue = this.buildSurvey());
  }

  @Input()
  public set survey(value: SurveyData) {
    this.surveyValue = value;

    this.form.setValue({
      name       : value.name,
      description: value.description,
    });

    this.form.valueChanges.subscribe(value => {
      this.survey.name        = value.name        ?? '';
      this.survey.description = value.description ?? '';
    });
  }

  @Output()
  public get ok(): EventEmitter<void> {
    return this.okValue;
  }

  public get form(): FormGroup<SurveyFormScheme> {
    return this.formValue ?? (this.formValue = this.buildForm());
  }

  public okPressed(): void {
    if (this.form.valid) {
      this.okValue.emit();
    }
  }

  private buildSurvey(): SurveyData {
    return {
      name       : '',
      description: '',
    };
  }

  private buildForm(): FormGroup<SurveyFormScheme> {
    return this.fb.group({
      name: this.fb.control('', [Validators.required]),
      description: this.fb.control(''),
    });
  }
}
