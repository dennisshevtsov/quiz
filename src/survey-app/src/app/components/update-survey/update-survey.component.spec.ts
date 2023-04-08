import { TestBed      } from '@angular/core/testing';

import { RouterTestingModule } from '@angular/router/testing';

import { Subscription } from 'rxjs';
import { of           } from 'rxjs';

import { UpdateSurveyComponent } from './update-survey.component';
import { UpdateSurveyViewModel } from './update-survey.view-model';
import { SurveyComponentMock   } from '../survey';

describe('UpdateSurveyComponent', () => {
  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [
        UpdateSurveyComponent,
        SurveyComponentMock,
      ],
      imports: [
        RouterTestingModule.withRoutes([{
          path     : 'survey/:surveyId',
          component: UpdateSurveyComponent,
        }]),
      ],
    })

    const vm: jasmine.SpyObj<UpdateSurveyViewModel> = jasmine.createSpyObj('UpdateSurveyViewModel', ['initialize'], ['survey']);
    vm.initialize.and.returnValue(of(void 0));

    TestBed.overrideProvider(UpdateSurveyViewModel, {useValue: vm});

    TestBed.overrideProvider(
      Subscription,
      { useValue: jasmine.createSpyObj(Subscription, ['add', 'unsubscribe'])},
    );

    await TestBed.compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(UpdateSurveyComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });
});
