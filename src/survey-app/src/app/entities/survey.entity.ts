import { SurveyData     } from './survey.data';
import { SurveyIdentity } from './survey.identity';

export interface SurveyEntity extends SurveyIdentity, SurveyData {}
