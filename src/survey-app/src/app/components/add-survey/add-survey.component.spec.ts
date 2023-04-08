import { Location } from '@angular/common';

import { Component    } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Input        } from '@angular/core';
import { Output       } from '@angular/core';

import { fakeAsync } from '@angular/core/testing';
import { inject    } from '@angular/core/testing';
import { TestBed   } from '@angular/core/testing';
import { tick      } from '@angular/core/testing';

import { RouterTestingModule } from '@angular/router/testing';

import { By } from '@angular/platform-browser';

import { Subscription } from 'rxjs';
import { of           } from 'rxjs';
import { throwError   } from 'rxjs';

import { SurveyData   } from '../../entities';
import { SurveyEntity } from '../../entities';

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

@Component({})
class TestUpdateSurveyComponent {}

describe('AddSurveyComponent', () => {
  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [
        TestSurveyComponent,
        AddSurveyComponent,
      ],
      imports: [RouterTestingModule.withRoutes([
        {
          path     : 'survey/:surveyId',
          component: TestUpdateSurveyComponent,
        },
      ])],
    });

    const vm = jasmine.createSpyObj('AddSurveyViewModel', ['add'], ['survey']);
    vm.add.and.returnValue(of(void 0));

    TestBed.overrideProvider(AddSurveyViewModel, {useValue: vm});

    TestBed.overrideProvider(
      Subscription,
      { useValue: jasmine.createSpyObj(Subscription, ['add', 'unsubscribe'])},
    );

    await TestBed.compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(AddSurveyComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });

  it('should unsubsribe in ngOnDestroy', fakeAsync(inject(
    [Subscription], (sub: jasmine.SpyObj<Subscription>) => {
    const fixture = TestBed.createComponent(AddSurveyComponent);

    fixture.detectChanges();

    tick();

    fixture.componentInstance.ngOnDestroy();

    expect(sub.unsubscribe.calls.count())
      .withContext('sub.unsubscribe should be called')
      .toBe(1);
  })));

  it('should navigate to survey/:surveyId if adding successed', fakeAsync(inject(
    [Subscription, AddSurveyViewModel, Location],
    (sub     : jasmine.SpyObj<Subscription>,
     vm      : jasmine.SpyObj<AddSurveyViewModel>,
     location: Location) => {
    vm.add.and.returnValue(of(void 0));

    const descs = Object.getOwnPropertyDescriptors(vm)!;

    const taskSpy = descs.survey.get as jasmine.Spy<() => SurveyEntity>;
    const survey = {
      surveyId   : 'test-id',
      name       : 'test-name',
      description: 'test-description',
    };

    taskSpy.and.returnValue(survey);

    const fixture  = TestBed.createComponent(AddSurveyComponent);

    fixture.detectChanges();

    const surveyComponent: TestSurveyComponent = fixture.debugElement.query(By.directive(TestSurveyComponent)).componentInstance;

    surveyComponent.ok.emit();

    tick();

    expect(location.path())
      .withContext('should navigate to survey/:surveyId')
      .toBe(`/survey/${survey.surveyId}`);

    expect(sub.add.calls.count())
      .withContext('sub.add should be called once')
      .toBe(1);
  })));

  it('should not navigate if adding failed', fakeAsync(inject(
    [Subscription, AddSurveyViewModel, Location],
    (sub     : jasmine.SpyObj<Subscription>,
     vm      : jasmine.SpyObj<AddSurveyViewModel>,
     location: Location) => {
    vm.add.and.returnValue(throwError(() => 'error'));

    const descs = Object.getOwnPropertyDescriptors(vm)!;

    const taskSpy = descs.survey.get as jasmine.Spy<() => SurveyEntity>;
    const survey = {
      surveyId   : 'test-id',
      name       : 'test-name',
      description: 'test-description',
    };

    taskSpy.and.returnValue(survey);

    const fixture  = TestBed.createComponent(AddSurveyComponent);

    fixture.detectChanges();

    const surveyComponent: TestSurveyComponent = fixture.debugElement.query(By.directive(TestSurveyComponent)).componentInstance;

    surveyComponent.ok.emit();

    tick();

    expect(location.path())
      .withContext('should stay at original path')
      .toBe('');

    expect(sub.add.calls.count())
      .withContext('sub.add should be called once')
      .toBe(1);
  })));
});
