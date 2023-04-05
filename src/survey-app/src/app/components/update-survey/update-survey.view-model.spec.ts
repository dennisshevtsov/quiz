import { inject  } from '@angular/core/testing';
import { TestBed } from '@angular/core/testing';

import { of } from 'rxjs';

import { UpdateSurveyViewModel } from './update-survey.view-model';
import { SurveyService         } from '../../services';

describe('UpdateSurveyViewModel', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        UpdateSurveyViewModel,
        {
          provide: SurveyService,
          useValue: jasmine.createSpyObj(SurveyService, ['getSurvey', 'updateSurvey']),
        },
      ],
    });
  });

  it('should load survey', inject([UpdateSurveyViewModel, SurveyService], (vm: UpdateSurveyViewModel, srv: jasmine.SpyObj<SurveyService>) => {
    const surveyId          = 'test id';
    const surveyName        = 'test name';
    const surveyDescription = 'test description';

    const controlSurvey = {
      surveyId   : surveyId,
      name       : surveyName,
      description: surveyDescription,
    };

    srv.getSurvey.and.returnValue(of(controlSurvey));

    vm.survey.surveyId = surveyId;

    vm.initialize().subscribe(() => {
      expect(srv.getSurvey.calls.count())
        .withContext('getSurvey should be called once')
        .toBe(1);

      expect(srv.getSurvey.calls.first().args[0].surveyId)
        .withContext('getSurvey should receive surveyId')
        .toEqual(surveyId);

      expect(vm.survey)
        .withContext('survey should be populated')
        .toEqual(controlSurvey);
    });
  }));
});
