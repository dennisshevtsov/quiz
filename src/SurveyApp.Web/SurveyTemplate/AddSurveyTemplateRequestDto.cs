// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Patchable;
using SurveyApp.SurveyQuestion.Web;

namespace SurveyApp.SurveyTemplate.Web;

public sealed class AddSurveyTemplateRequestDto : IComposable
{
  public string Title { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  public SurveyQuestionDtoBase[] Questions { get; set; } = Array.Empty<SurveyQuestionDtoBase>();

  public SurveyTemplateEntity ToSurveyTemplateEntity() => new()
  {
    Title       = Title,
    Description = Description,
    Questions   = SurveyQuestionDtoBase.ToQuestionTemplateEntityCollection(Questions),
  };
}
