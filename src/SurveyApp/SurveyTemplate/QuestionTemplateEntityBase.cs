// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public abstract class QuestionTemplateEntityBase
{
  protected QuestionTemplateEntityBase(string text)
  {
    Text = text;
  }

  public string Text { get; private set; }

  public abstract QuestionType QuestionType { get; }
}
