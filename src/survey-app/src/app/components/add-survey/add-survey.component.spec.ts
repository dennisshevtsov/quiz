import { Location } from '@angular/common';

import { fakeAsync } from '@angular/core/testing';
import { inject    } from '@angular/core/testing';
import { TestBed   } from '@angular/core/testing';
import { tick      } from '@angular/core/testing';

import { RouterTestingModule } from '@angular/router/testing';

import { By } from '@angular/platform-browser';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Subscription } from 'rxjs';
import { of           } from 'rxjs';
import { throwError   } from 'rxjs';

import { SurveyEntity } from '../../entities';

import { AddSurveyComponent        } from './add-survey.component';
import { AddSurveyViewModel        } from './add-survey.view-model';
import { SurveyComponentMock       } from '../survey'
import { UpdateSurveyComponentMock } from '../update-survey';

describe('AddSurveyComponent', () => {
  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [
        SurveyComponentMock,
        AddSurveyComponent,
      ],
      imports: [
        RouterTestingModule.withRoutes([{
          path     : 'survey/:surveyId',
          component: UpdateSurveyComponentMock,
        }]),
      ],
    });

    const vm = jasmine.createSpyObj('AddSurveyViewModel', ['add'], ['survey']);
    vm.add.and.returnValue(of(void 0));

    TestBed.overrideProvider(AddSurveyViewModel, {useValue: vm});

    TestBed.overrideProvider(
      Subscription,
      { useValue: jasmine.createSpyObj(Subscription, ['add', 'unsubscribe'])},
    );

    const sb: jasmine.SpyObj<MatSnackBar> = jasmine.createSpyObj(MatSnackBar, ['open']);
    TestBed.overrideProvider(MatSnackBar, {useValue: sb});

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
    [Subscription, AddSurveyViewModel, Location, MatSnackBar],
    (sub     : jasmine.SpyObj<Subscription>,
     vm      : jasmine.SpyObj<AddSurveyViewModel>,
     location: Location,
     sb      : jasmine.SpyObj<MatSnackBar>) => {
    vm.add.and.returnValue(of(void 0));

    const descs = Object.getOwnPropertyDescriptors(vm)!;

    const surveySpy = descs.survey.get as jasmine.Spy<() => SurveyEntity>;
    const survey = {
      surveyId   : 'test-id',
      name       : 'test-name',
      description: 'test-description',
    };

    surveySpy.and.returnValue(survey);

    const fixture  = TestBed.createComponent(AddSurveyComponent);

    fixture.detectChanges();

    const surveyComponent: SurveyComponentMock = fixture.debugElement.query(By.directive(SurveyComponentMock)).componentInstance;

    surveyComponent.ok.emit();

    tick();

    expect(location.path())
      .withContext('should navigate to survey/:surveyId')
      .toBe(`/survey/${survey.surveyId}`);

    expect(sub.add.calls.count())
      .withContext('sub.add should be called once')
      .toBe(1);

    expect(sb.open.calls.count())
      .withContext('sb.open should be called once')
      .toBe(1);

    expect(sb.open.calls.first().args[0])
      .withContext('sb.open should be called with success message')
      .toBe('The new survey is created.');
  })));

  it('should not navigate if adding failed', fakeAsync(inject(
    [Subscription, AddSurveyViewModel, Location, MatSnackBar],
    (sub     : jasmine.SpyObj<Subscription>,
     vm      : jasmine.SpyObj<AddSurveyViewModel>,
     location: Location,
     sb      : jasmine.SpyObj<MatSnackBar>) => {
    vm.add.and.returnValue(throwError(() => 'error'));

    const descs = Object.getOwnPropertyDescriptors(vm)!;

    const surveySpy = descs.survey.get as jasmine.Spy<() => SurveyEntity>;
    const survey = {
      surveyId   : 'test-id',
      name       : 'test-name',
      description: 'test-description',
    };

    surveySpy.and.returnValue(survey);

    const fixture  = TestBed.createComponent(AddSurveyComponent);

    fixture.detectChanges();

    const surveyComponent: SurveyComponentMock = fixture.debugElement.query(By.directive(SurveyComponentMock)).componentInstance;

    surveyComponent.ok.emit();

    tick();

    expect(location.path())
      .withContext('should stay at original path')
      .toBe('');

    expect(sub.add.calls.count())
      .withContext('sub.add should be called once')
      .toBe(1);

    expect(sb.open.calls.count())
      .withContext('sb.open should be called once')
      .toBe(1);

    expect(sb.open.calls.first().args[0])
      .withContext('sb.open should be called with error message')
      .toBe('An error occured.');
  })));
});
