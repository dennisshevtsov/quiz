// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;
using System.Text.Json.Serialization;

namespace SurveyApp.Survey;

public sealed class YesNoQuestionEntity : QuestionEntityBase
{
  [JsonConstructor]
  public YesNoQuestionEntity(string text, YesNo answer) : base(text)
  {
    Answer = answer;
  }

  public YesNoQuestionEntity(YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity)
    : this(yesNoQuestionTemplateEntity.Text, YesNo.None)
  { }

  public override QuestionType QuestionType => QuestionType.YesNo;

  public YesNo Answer { get; private set; }

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

    if (other is not YesNoQuestionEntity entity)
    {
      return false;
    }

    return Text == entity.Text && Answer == entity.Answer;
  }

  public void SetAnswer(YesNo answer, ExecutingContext context)
  {
    if (answer < YesNo.None || answer > YesNo.No)
    {
      context.AddError("Unknown answer type.");
      return;
    }

    Answer = answer;
  }
}
