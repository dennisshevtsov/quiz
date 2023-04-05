import { inject  } from '@angular/core/testing';
import { TestBed } from '@angular/core/testing';

import { of } from 'rxjs';

import { SearchSurveysViewModel } from './search-surveys.view-model';
import { SurveyService          } from '../../services';

describe('SearchSurveysViewModel', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        SearchSurveysViewModel,
        {
          provide : SurveyService,
          useValue: jasmine.createSpyObj(SurveyService, ['searchSurveys']),
        },
      ],
    });
  });
});
