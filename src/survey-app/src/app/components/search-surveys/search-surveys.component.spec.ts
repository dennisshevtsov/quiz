import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed                 } from '@angular/core/testing';
import { RouterTestingModule     } from '@angular/router/testing';

import { MatIconModule  } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';

import { SearchSurveysComponent } from './search-surveys.component';

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

    await TestBed.compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(SearchSurveysComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });
});
