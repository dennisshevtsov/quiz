// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Patchable;

namespace SurveyApp.Survey.Web;

public sealed class AddSurveyRequestDto : IComposable
{
  public string Title { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  public string CandidateName { get; set; } = string.Empty;

  public SurveyQuestionDtoBase[] Questions { get; set; } = Array.Empty<SurveyQuestionDtoBase>();

  public SurveyEntity ToSurveyEntity() => new()
  {
    Title         = Title,
    Description   = Description,
    CandidateName = CandidateName,
    Questions     = SurveyQuestionDtoBase.ToQuestionTemplateEntityCollection(Questions),
  };
}
