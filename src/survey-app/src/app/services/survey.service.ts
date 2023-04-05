import { HttpClient  } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { SurveyData     } from '../entities';
import { SurveyEntity   } from '../entities';
import { SurveyIdentity } from '../entities';

@Injectable({
  providedIn: 'root',
})
export class SurveyService {
  public constructor(private readonly http: HttpClient) {}

  public getSurvey(survey: SurveyIdentity): Observable<SurveyEntity> {
    return this.http.get<SurveyEntity>(`api/survey/${survey.surveyId}`);
  }

  public searchSurveys(): Observable<{surveys: SurveyEntity[]}> {
    return this.http.get<{surveys: SurveyEntity[]}>('api/survey/');
  }

  public addSurvey(survey: SurveyData): Observable<SurveyEntity> {
    const url     = 'api/survey';
    const body    = JSON.stringify(survey);
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    };

    return this.http.post<SurveyEntity>(url, body, options);
  }

  public updateSurvey(survey: SurveyEntity): Observable<SurveyEntity> {
    const url     = `api/survey/${survey.surveyId}`;
    const body    = JSON.stringify(survey);
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    };

    return this.http.put<SurveyEntity>(url, body, options);
  }
}
