// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web;

public sealed class AddSurveyTemplateRequestDto
{
  public string Title { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  public SurveyTemplateQuestionDtoBase[] Questions { get; set; } = Array.Empty<SurveyTemplateQuestionDtoBase>();
}
