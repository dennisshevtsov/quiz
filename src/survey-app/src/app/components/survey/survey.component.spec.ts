import { TestBed             } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';

import { SurveyComponent } from './survey.component';

describe('SurveyComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
                   imports: [ReactiveFormsModule],
                   declarations: [SurveyComponent]
                 })
                 .compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(SurveyComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });
});
