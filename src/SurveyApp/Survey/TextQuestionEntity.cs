// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class TextQuestionEntity : QuestionEntityBase
{
  public TextQuestionEntity() { }

  public TextQuestionEntity(TextQuestionTemplateEntity textQuestionTemplateEntity)
  {
    Text = textQuestionTemplateEntity.Text;
  }

  public override QuestionType QuestionType => QuestionType.Text;

  public string? Answer { get; set; }
}
