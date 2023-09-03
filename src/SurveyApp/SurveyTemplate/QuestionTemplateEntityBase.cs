// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public abstract class QuestionTemplateEntityBase
{
  public string Text { get; set; } = string.Empty;

  public abstract QuestionType QuestionType { get; }
}
