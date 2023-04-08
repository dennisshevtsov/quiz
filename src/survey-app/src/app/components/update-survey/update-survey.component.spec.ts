import { fakeAsync } from '@angular/core/testing';
import { inject    } from '@angular/core/testing';
import { TestBed   } from '@angular/core/testing';
import { tick      } from '@angular/core/testing';

import { ActivatedRoute      } from '@angular/router';
import { ParamMap            } from '@angular/router';
import { Router              } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';

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

    TestBed.overrideProvider('ParamMap', { useValue: paramMap });
    TestBed.overrideProvider(ActivatedRoute, { useValue: { paramMap: of(paramMap) }});

    const vm: jasmine.SpyObj<UpdateSurveyViewModel> = jasmine.createSpyObj('UpdateSurveyViewModel', ['initialize'], ['survey']);
    vm.initialize.and.returnValue(of(void 0));

    const descs = Object.getOwnPropertyDescriptors(vm)!;

    const taskSpy = descs.survey.get as jasmine.Spy<() => SurveyEntity>;
    const survey = {
      surveyId   : 'test-id',
      name       : 'test-name',
      description: 'test-description',
    };

    taskSpy.and.returnValue(survey);

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
    [Subscription, UpdateSurveyViewModel, 'ParamMap'],
    (sub     : jasmine.SpyObj<Subscription>,
     vm      : jasmine.SpyObj<UpdateSurveyViewModel>,
     paramMap: jasmine.SpyObj<ParamMap>) => {
    vm.initialize.and.returnValue(of(void 0));
    paramMap.get.and.returnValue('test-id');

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
    [Subscription, 'ParamMap'],
    (sub     : jasmine.SpyObj<Subscription>,
     paramMap: jasmine.SpyObj<ParamMap>) => {
    paramMap.get.and.returnValue('test-id');

    const fixture = TestBed.createComponent(UpdateSurveyComponent);

    fixture.detectChanges();

    tick();

    fixture.componentInstance.ngOnDestroy();

    expect(sub.unsubscribe.calls.count())
      .withContext('sub.unsubscribe should be called')
      .toBe(1);
  })));
});
