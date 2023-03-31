import { TestBed } from '@angular/core/testing';

import { SearchSurveysComponent } from './search-surveys.component';

describe('SearchSurveysComponent', () => {
  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [SearchSurveysComponent],
    });

    await TestBed.compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(SearchSurveysComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });
});
