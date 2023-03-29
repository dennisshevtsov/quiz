import { TestBed } from '@angular/core/testing';

import { UpdateSurveyComponent } from './update-survey.component';

describe('GetSurveyComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
                   declarations: [UpdateSurveyComponent]
                 })
                 .compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(UpdateSurveyComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });
});
