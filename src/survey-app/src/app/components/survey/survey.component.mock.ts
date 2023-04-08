import { Component    } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Input        } from '@angular/core';
import { Output       } from '@angular/core';

import { SurveyData } from '../../entities';

@Component({
  selector: 'app-survey',
  template: '',
})
export class SurveyComponentMock {
  private okValue: EventEmitter<void>;

  public constructor() {
    this.okValue = new EventEmitter<void>();
  }

  @Input()
  public set survey(value: SurveyData) {}

  @Output()
  public get ok(): EventEmitter<void> {
    return this.okValue;
  }
}
