import { TestBed } from '@angular/core/testing';

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
});
