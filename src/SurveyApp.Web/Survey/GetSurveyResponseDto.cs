// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyQuestion.Web;

namespace SurveyApp.Survey.Web;

public sealed class GetSurveyResponseDto
{
  public GetSurveyResponseDto(SurveyEntity surveyEntity)
  {
    SurveyId    = surveyEntity.SurveyId;
    Title       = surveyEntity.Title;
    Description = surveyEntity.Description;
    Questions   = Questions = surveyEntity.Questions.Select(SurveyQuestionDtoBase.FromQuestionTemplateEntity)
                                                    .ToArray();
  }

  public Guid SurveyId { get; }

  public string Title { get; }

  public string Description { get; }

  public SurveyQuestionDtoBase[] Questions { get; }
}
