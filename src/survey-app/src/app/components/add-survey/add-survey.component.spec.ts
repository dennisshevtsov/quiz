import { Component    } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Input        } from '@angular/core';
import { Output       } from '@angular/core';
import { TestBed      } from '@angular/core/testing';

import { SurveyData         } from '../../entities';
import { AddSurveyComponent } from './add-survey.component';
import { AddSurveyViewModel } from './add-survey.view-model';

@Component({
  selector: 'app-survey',
})
class TestSurveyComponent {
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

describe('AddSurveyComponent', () => {
  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [
        TestSurveyComponent,
        AddSurveyComponent,
      ],
    });

    TestBed.overrideProvider(
      AddSurveyViewModel,
      {useValue: jasmine.createSpyObj(AddSurveyViewModel,['addSurvey'])});

    await TestBed.compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(AddSurveyComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });
});
