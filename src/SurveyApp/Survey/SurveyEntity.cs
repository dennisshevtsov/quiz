// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyQuestion;
using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class SurveyEntity
{
  public SurveyEntity(SurveyTemplateEntity surveyTemplateEntity)
  {
    Title       = surveyTemplateEntity.Title;
    Description = surveyTemplateEntity.Description;
    Questions   = surveyTemplateEntity.Questions.Select(entity => entity.Clone()).ToList();
  }

  public Guid SurveyId { get;}

  public string Title { get; }

  public string Description { get; }

  public List<SurveyQuestionTemplateEntityBase> Questions { get; }
}
