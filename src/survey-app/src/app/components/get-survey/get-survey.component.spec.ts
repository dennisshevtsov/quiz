import { TestBed } from '@angular/core/testing';

import { GetSurveyComponent } from './get-survey.component';

describe('GetSurveyComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
                   declarations: [GetSurveyComponent]
                 })
                 .compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(GetSurveyComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });
});
