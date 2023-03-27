import { TestBed } from '@angular/core/testing';

import { AddSurveyComponent } from './add-survey.component';

describe('AddSurveyComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
                   declarations: [AddSurveyComponent],
                 })
                 .compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(AddSurveyComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });
});
