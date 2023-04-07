import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed, fakeAsync, inject, tick                 } from '@angular/core/testing';
import { RouterTestingModule     } from '@angular/router/testing';

import { MatIconModule  } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';

import { Subscription, of } from 'rxjs';

import { SearchSurveysComponent } from './search-surveys.component';
import { SearchSurveysViewModel } from './search-surveys.view-model';

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

    const vm = jasmine.createSpyObj('SearchSurveysViewModel', ['initialize'], ['surveys']);
    vm.initialize.and.returnValue(of(void 0));

    TestBed.overrideProvider(SearchSurveysViewModel, { useValue: vm });

    await TestBed.compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(SearchSurveysComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });

  it('ngOnInit should initialize component', fakeAsync(inject([Subscription, SearchSurveysViewModel], (sub: jasmine.SpyObj<Subscription>, vm: jasmine.SpyObj<SearchSurveysViewModel>) => {
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

  it('ngOnDestroy should unsubsribe', fakeAsync(inject([Subscription, SearchSurveysViewModel], (sub: jasmine.SpyObj<Subscription>, vm: jasmine.SpyObj<SearchSurveysViewModel>) => {
    const fixture = TestBed.createComponent(SearchSurveysComponent);

    fixture.detectChanges();

    tick();

    fixture.componentInstance.ngOnDestroy();

    expect(sub.unsubscribe.calls.count())
      .withContext('sub.unsubscribe should be called')
      .toBe(1);
  })));
});
