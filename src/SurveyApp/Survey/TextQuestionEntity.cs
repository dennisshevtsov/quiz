// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;
using System.Text.Json.Serialization;

namespace SurveyApp.Survey;

public sealed class TextQuestionEntity : QuestionEntityBase
{
  [JsonConstructor]
  public TextQuestionEntity(string text, string? answer) : base(text)
  {
    Answer = answer;
  }

  public TextQuestionEntity(TextQuestionTemplateEntity template)
    : this(template.Text, null)
  { }

  public override QuestionType QuestionType => QuestionType.Text;

  public string? Answer { get; private set; }

  public override bool Equals(QuestionEntityBase? other)
  {
    if (other == null)
    {
      return false;
    }

    if (object.ReferenceEquals(other, this))
    {
      return true;
    }

    if (other is not TextQuestionEntity entity)
    {
      return false;
    }

    return Text == entity.Text && Answer == entity.Answer;
  }

  public void SetAnswer(string? answer)
  {
    Answer = answer;
  }
}
