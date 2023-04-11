import { HttpClientTestingModule } from '@angular/common/http/testing';

import { fakeAsync } from '@angular/core/testing';
import { inject    } from '@angular/core/testing';
import { TestBed   } from '@angular/core/testing';
import { tick      } from '@angular/core/testing';

import { RouterTestingModule } from '@angular/router/testing';

import { MatIconModule  } from '@angular/material/icon';
import { MatSnackBar    } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';

import { Subscription } from 'rxjs';
import { of           } from 'rxjs';
import { throwError   } from 'rxjs';

import { SearchSurveysComponent } from './search-surveys.component';
import { SearchSurveysViewModel } from './search-surveys.view-model';
import { SurveyEntity           } from '../../entities';

describe('SearchSurveysComponent', () => {
  beforeEach(async () => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        MatIconModule,
        MatTableModule,
        RouterTestingModule,
      ],
      declarations: [SearchSurveysComponent],
    });

    TestBed.overrideProvider(
      Subscription,
      { useValue: jasmine.createSpyObj(Subscription, ['add', 'unsubscribe'])},
    );

    const vm = jasmine.createSpyObj('SearchSurveysViewModel', ['initialize', 'delete'], ['surveys']);
    vm.initialize.and.returnValue(of(void 0));

    TestBed.overrideProvider(SearchSurveysViewModel, { useValue: vm });

    const sb: jasmine.SpyObj<MatSnackBar> = jasmine.createSpyObj(MatSnackBar, ['open']);
    TestBed.overrideProvider(MatSnackBar, {useValue: sb});

    await TestBed.compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(SearchSurveysComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });

  it('should initialize component ngOnInit', fakeAsync(inject(
    [Subscription, SearchSurveysViewModel],
    (sub: jasmine.SpyObj<Subscription>,
     vm: jasmine.SpyObj<SearchSurveysViewModel>) => {
    const fixture = TestBed.createComponent(SearchSurveysComponent);

    fixture.detectChanges();

    tick();

    expect(sub.add.calls.count())
      .withContext('sub.add should be called')
      .toBe(1);

    expect(vm.initialize.calls.count())
      .withContext('vm.initialize should be called')
      .toBe(1);
  })));

  it('should unsubsribe in ngOnDestroy', fakeAsync(inject(
    [Subscription], (sub: jasmine.SpyObj<Subscription>) => {
    const fixture = TestBed.createComponent(SearchSurveysComponent);

    fixture.detectChanges();

    tick();

    fixture.componentInstance.ngOnDestroy();

    expect(sub.unsubscribe.calls.count())
      .withContext('sub.unsubscribe should be called')
      .toBe(1);
  })));

  it('should show success message', fakeAsync(inject(
    [Subscription, SearchSurveysViewModel, MatSnackBar],
    (sub     : jasmine.SpyObj<Subscription>,
     vm      : jasmine.SpyObj<SearchSurveysViewModel>,
     sb      : jasmine.SpyObj<MatSnackBar>) => {
    vm.delete.and.returnValue(of(void 0));

    const fixture  = TestBed.createComponent(SearchSurveysComponent);

    fixture.detectChanges();
    tick();

    sub.add.calls.reset();

    const survey: SurveyEntity = {
      name       : 'test name',
      description: 'test description',
      surveyId   : 'test id',
    };

    fixture.componentInstance.delete(survey);
    tick();

    expect(vm.delete.calls.count())
      .withContext('vm.delete should be called once')
      .toBe(1);

    expect(vm.delete.calls.first().args[0])
      .withContext('vm.delete should be called for survey')
      .toEqual(survey);

    expect(sub.add.calls.count())
      .withContext('sub.add should be called once')
      .toBe(1);

    expect(sb.open.calls.count())
      .withContext('sb.open should be called once')
      .toBe(1);

    expect(sb.open.calls.first().args[0])
      .withContext('sb.open should be called with success message')
      .toBe('Survey test name is deleted.');
  })));

  it('should show error message', fakeAsync(inject(
    [Subscription, SearchSurveysViewModel, MatSnackBar],
    (sub     : jasmine.SpyObj<Subscription>,
     vm      : jasmine.SpyObj<SearchSurveysViewModel>,
     sb      : jasmine.SpyObj<MatSnackBar>) => {
    vm.delete.and.returnValue(throwError(() => 'error'));

    const fixture  = TestBed.createComponent(SearchSurveysComponent);

    fixture.detectChanges();
    tick();

    sub.add.calls.reset();

    const survey: SurveyEntity = {
      name       : 'test name',
      description: 'test description',
      surveyId   : 'test id',
    };

    fixture.componentInstance.delete(survey);
    tick();

    expect(vm.delete.calls.count())
      .withContext('vm.delete should be called once')
      .toBe(1);

    expect(vm.delete.calls.first().args[0])
      .withContext('vm.delete should be called for survey')
      .toEqual(survey);

    expect(sub.add.calls.count())
      .withContext('sub.add should be called once')
      .toBe(1);

    expect(sb.open.calls.count())
      .withContext('sb.open should be called once')
      .toBe(1);

    expect(sb.open.calls.first().args[0])
      .withContext('sb.open should be called with success message')
      .toBe('An error occured.');
  })));
});
