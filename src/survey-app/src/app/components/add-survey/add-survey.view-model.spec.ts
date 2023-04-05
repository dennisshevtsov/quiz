import { inject  } from '@angular/core/testing';
import { TestBed } from '@angular/core/testing';

import { of } from 'rxjs';

import { AddSurveyViewModel } from './add-survey.view-model';
import { SurveyService      } from '../../services';

describe('AddSurveyViewModel', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        AddSurveyViewModel,
        {
          provide: SurveyService,
          useValue: jasmine.createSpyObj(SurveyService, ['addSurvey']),
        },
      ],
    });
  });

  it('should add survey', inject([AddSurveyViewModel, SurveyService], (vm: AddSurveyViewModel, srv: jasmine.SpyObj<SurveyService>) => {
    const surveyName        = 'test name';
    const surveyDescription = 'test description';

    const controlSurvey = {
      surveyId   : 'test id',
      name       : surveyName,
      description: surveyDescription,
    };

    srv.addSurvey.and.returnValue(of(controlSurvey));

    vm.survey.name = surveyName;
    vm.survey.description = surveyDescription;

    vm.add().subscribe(() => {
      expect(srv.addSurvey.calls.count())
        .withContext('addSurvey should be called once')
        .toBe(1);

      expect(srv.addSurvey.calls.first().args[0].name)
        .withContext('addSurvey should receive name')
        .toEqual(surveyName);

      expect(srv.addSurvey.calls.first().args[0].description)
        .withContext('addSurvey should receive description')
        .toEqual(surveyDescription);

      expect(vm.survey.surveyId)
        .withContext('surveyId should be populated')
        .toBe(controlSurvey.surveyId);
    });
  }));
});
