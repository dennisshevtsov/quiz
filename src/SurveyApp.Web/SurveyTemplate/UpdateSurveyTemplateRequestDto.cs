// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Patchable;

namespace SurveyApp.SurveyTemplate.Web;

public sealed class UpdateSurveyTemplateRequestDto : IComposable
{
  public Guid SurveyTemplateId { get; set; }

  public string Title { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  public SurveyTemplateQuestionDtoBase[] Questions { get; set; } = Array.Empty<SurveyTemplateQuestionDtoBase>();

  public SurveyTemplateEntity UpdateSurveyTemplate(SurveyTemplateEntity surveyTemplateEntity)
  {
    surveyTemplateEntity.Title = Title;
    surveyTemplateEntity.Description = Description;
    surveyTemplateEntity.Questions = SurveyTemplateQuestionDtoBase.ToQuestionTemplateEntityCollection(Questions);

    return surveyTemplateEntity;
  }
}
