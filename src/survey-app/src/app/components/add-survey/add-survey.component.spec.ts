import { Component    } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Input        } from '@angular/core';
import { Output       } from '@angular/core';

import { fakeAsync } from '@angular/core/testing';
import { inject    } from '@angular/core/testing';
import { TestBed   } from '@angular/core/testing';
import { tick      } from '@angular/core/testing';

import { RouterTestingModule } from '@angular/router/testing';

import { Subscription } from 'rxjs';
import { of           } from 'rxjs';

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
      imports: [RouterTestingModule],
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
    [Subscription, AddSurveyViewModel],
    (sub: jasmine.SpyObj<Subscription>,
     vm: jasmine.SpyObj<AddSurveyViewModel>) => {
    const fixture = TestBed.createComponent(AddSurveyComponent);

    fixture.detectChanges();

    tick();

    fixture.componentInstance.ngOnDestroy();

    expect(sub.unsubscribe.calls.count())
      .withContext('sub.unsubscribe should be called')
      .toBe(1);
  })));
});
