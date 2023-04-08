import { fakeAsync } from '@angular/core/testing';
import { inject    } from '@angular/core/testing';
import { TestBed   } from '@angular/core/testing';
import { tick      } from '@angular/core/testing';

import { ActivatedRoute      } from '@angular/router';
import { ParamMap            } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';

import { By } from '@angular/platform-browser';

import { of           } from 'rxjs';
import { Subscription } from 'rxjs';

import { UpdateSurveyComponent } from './update-survey.component';
import { UpdateSurveyViewModel } from './update-survey.view-model';

import { SurveyEntity          } from '../../entities';
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
    });

    const paramMap = jasmine.createSpyObj('ParamMap', [ 'get', ]);
    paramMap.get.and.returnValue('test-id');

    TestBed.overrideProvider('ParamMap', { useValue: paramMap });
    TestBed.overrideProvider(ActivatedRoute, { useValue: { paramMap: of(paramMap) }});

    const vm: jasmine.SpyObj<UpdateSurveyViewModel> = jasmine.createSpyObj('UpdateSurveyViewModel', ['initialize', 'update'], ['survey']);
    vm.initialize.and.returnValue(of(void 0));

    const descs = Object.getOwnPropertyDescriptors(vm)!;

    const surveySpy = descs.survey.get as jasmine.Spy<() => SurveyEntity>;
    const survey = {
      surveyId   : 'test-id',
      name       : 'test-name',
      description: 'test-description',
    };

    surveySpy.and.returnValue(survey);

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

  it('should initialize in ngOnInit', fakeAsync(inject(
    [Subscription, UpdateSurveyViewModel],
    (sub     : jasmine.SpyObj<Subscription>,
     vm      : jasmine.SpyObj<UpdateSurveyViewModel>) => {
    const fixture = TestBed.createComponent(UpdateSurveyComponent);

    fixture.detectChanges();

    tick();

    expect(vm.initialize.calls.count())
      .withContext('vm.initialize should be called once')
      .toBe(1);

    expect(sub.add.calls.count())
      .withContext('sub.add should be called once')
      .toBe(1);
  })));

  it('should unsubsribe in ngOnDestroy', fakeAsync(inject(
    [Subscription], (sub: jasmine.SpyObj<Subscription>) => {
    const fixture = TestBed.createComponent(UpdateSurveyComponent);

    fixture.detectChanges();

    tick();

    fixture.componentInstance.ngOnDestroy();

    expect(sub.unsubscribe.calls.count())
      .withContext('sub.unsubscribe should be called')
      .toBe(1);
  })));

  it('should update survey', fakeAsync(inject(
    [Subscription, UpdateSurveyViewModel],
    (sub: jasmine.SpyObj<Subscription>,
     vm : jasmine.SpyObj<UpdateSurveyViewModel>) => {
    vm.update.and.returnValue(of(void 0));

    const fixture  = TestBed.createComponent(UpdateSurveyComponent);
    fixture.detectChanges();
    tick();

    sub.add.calls.reset();

    const surveyComponent: SurveyComponentMock = fixture.debugElement.query(By.directive(SurveyComponentMock)).componentInstance;
    surveyComponent.ok.emit();
    tick();

    expect(vm.update.calls.count())
      .withContext('vm.update should be called once')
      .toBe(1);

    expect(sub.add.calls.count())
      .withContext('sub.add should be called once')
      .toBe(1);
  })));
});
