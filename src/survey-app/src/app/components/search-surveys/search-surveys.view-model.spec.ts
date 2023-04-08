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

  it('should load surveys', inject([SearchSurveysViewModel, SurveyService], (vm: SearchSurveysViewModel, srv: jasmine.SpyObj<SurveyService>) => {
    const surveyId          = 'test id';
    const surveyName        = 'test name';
    const surveyDescription = 'test description';

    const controlSurveyCollection = [{
      surveyId   : surveyId,
      name       : surveyName,
      description: surveyDescription,
    }];

    srv.searchSurveys.and.returnValue(of({
      surveys: controlSurveyCollection,
    }));

    vm.initialize().subscribe(() => {
      expect(srv.searchSurveys.calls.count())
        .withContext('searchSurveys should be called once')
        .toBe(1);

      expect(vm.surveys)
        .withContext('surveys should be populated')
        .toEqual(controlSurveyCollection);
    });
  }));
});
