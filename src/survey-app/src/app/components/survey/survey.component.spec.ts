import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed                 } from '@angular/core/testing';
import { ReactiveFormsModule     } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatInputModule } from '@angular/material/input';

import { SurveyComponent } from './survey.component';

describe('SurveyComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
                   imports: [
                    BrowserAnimationsModule,
                    HttpClientTestingModule,
                    MatInputModule,
                    ReactiveFormsModule,
                  ],
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
