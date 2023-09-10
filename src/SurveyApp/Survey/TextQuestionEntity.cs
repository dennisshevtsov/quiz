// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class TextQuestionEntity : QuestionEntityBase
{
  public TextQuestionEntity(string text, string? answer) : base(text)
  {
    Answer = answer;
  }

  public TextQuestionEntity(TextQuestionTemplateEntity textQuestionTemplateEntity)
    : this(textQuestionTemplateEntity.Text, null)
  { }

  public override QuestionType QuestionType => QuestionType.Text;

  public string? Answer { get; private set; }

  public void SetAnswer(string? answer)
  {
    Answer = answer;
  }
}
