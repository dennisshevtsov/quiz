// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class SingleChoiceQuestionEntity : QuestionEntityBase
{
  public SingleChoiceQuestionEntity(string text, string[] choices, string? answer) : base(text)
  {
    Choices = choices;
    Answer  = answer;
  }

  public SingleChoiceQuestionEntity(SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity)
   : this(singleChoiceQuestionTemplateEntity.Text, singleChoiceQuestionTemplateEntity.Choices.Select(choice => choice).ToArray(), null)
  { }

  public override QuestionType QuestionType => QuestionType.SingleChoice;

  public string[] Choices { get; private set; }

  public string? Answer { get; private set; }

  public void SetAnswer(string? answer, ExecutingContext context)
  {
    if (string.IsNullOrEmpty(answer))
    {
      Answer = null;
      return;
    }

    for (int i = 0; i < Choices.Length; i++)
    {
      if (string.Equals(Choices[i], answer, StringComparison.OrdinalIgnoreCase))
      {
        Answer = answer;
        return;
      }
    }

    context.AddError("Unknown choice.");
  }
}
