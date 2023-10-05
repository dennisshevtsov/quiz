// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web;

public sealed class GetSurveyTemplateResponseDto
{
  public GetSurveyTemplateResponseDto(SurveyTemplateEntity surveyTemplateEntity)
  {
    SurveyTemplateId = surveyTemplateEntity.SurveyTemplateId;
    Title            = surveyTemplateEntity.Title;
    Description      = surveyTemplateEntity.Description;
    Questions        = surveyTemplateEntity.Questions.Select(QuestionTemplateDtoBase.FromQuestionTemplateEntity)
                                                     .ToArray();
  }

  public Guid SurveyTemplateId { get; set; }

  public string Title { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  public QuestionTemplateDtoBase[] Questions { get; set; } = Array.Empty<QuestionTemplateDtoBase>();
}
