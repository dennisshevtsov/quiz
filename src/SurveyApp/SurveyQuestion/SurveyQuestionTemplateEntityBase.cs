// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyQuestion;

public abstract class SurveyQuestionTemplateEntityBase
{
  public string Text { get; protected set; } = string.Empty;

  public abstract SurveyQuestionType QuestionType { get; }

  public abstract SurveyQuestionTemplateEntityBase Clone();
}
