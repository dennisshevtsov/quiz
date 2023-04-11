import { inject  } from '@angular/core/testing';
import { TestBed } from '@angular/core/testing';

import { of } from 'rxjs';

import { SearchSurveysViewModel } from './search-surveys.view-model';
import { SurveyService          } from '../../services';
import { SurveyEntity           } from '../../entities';

describe('SearchSurveysViewModel', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        SearchSurveysViewModel,
        {
          provide : SurveyService,
          useValue: jasmine.createSpyObj(SurveyService, ['searchSurveys', 'deleteSurvey']),
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

    srv.searchSurveys.and.returnValue(of(controlSurveyCollection));

    vm.initialize().subscribe(() => {
      expect(srv.searchSurveys.calls.count())
        .withContext('searchSurveys should be called once')
        .toBe(1);

      expect(vm.surveys)
        .withContext('surveys should be populated')
        .toEqual(controlSurveyCollection);
    });
  }));

  it('should delete survey', inject(
    [SearchSurveysViewModel, SurveyService],
    (vm: SearchSurveysViewModel, srv: jasmine.SpyObj<SurveyService>) => {
    srv.deleteSurvey.and.returnValue(of(void 0));
    srv.searchSurveys.and.returnValue(of([]));

    const survey: SurveyEntity = {
      name       : 'test name',
      description: 'test description',
      surveyId   : 'test id',
    };

    vm.delete(survey).subscribe(() => {
      expect(srv.deleteSurvey.calls.count())
        .withContext('deleteSurvey should be called once')
        .toBe(1);

      expect(srv.deleteSurvey.calls.first().args[0])
        .withContext('surveys should be populated')
        .toEqual(survey);

        expect(srv.searchSurveys.calls.count())
        .withContext('searchSurveys should be called once')
        .toBe(1);
    });
  }));
});
