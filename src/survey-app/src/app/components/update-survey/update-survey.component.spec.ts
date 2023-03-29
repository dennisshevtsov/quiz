import { Component    } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Input        } from '@angular/core';
import { Output       } from '@angular/core';
import { TestBed      } from '@angular/core/testing';

import { RouterTestingModule } from '@angular/router/testing';

import { SurveyData            } from '../../entities';
import { UpdateSurveyComponent } from './update-survey.component';
import { UpdateSurveyViewModel } from './update-survey.view-model';

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

describe('UpdateSurveyComponent', () => {
  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [
        UpdateSurveyComponent,
        TestSurveyComponent,
      ],
      imports: [RouterTestingModule],
    })

    TestBed.overrideProvider(
      UpdateSurveyViewModel,
      {useValue: jasmine.createSpyObj(UpdateSurveyViewModel,['getSurvey'])});

    await TestBed.compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(UpdateSurveyComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });
});
