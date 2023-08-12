// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Web.SurveyTemplate;

public abstract class SurveyTemplateQuestionDtoBase
{
  public string Text { get; set; } = string.Empty;

  public abstract SurveyQuestionType QuestionType { get; }
}
