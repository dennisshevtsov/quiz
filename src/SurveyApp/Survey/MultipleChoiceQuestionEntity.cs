// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;
using System.Text.Json.Serialization;

namespace SurveyApp.Survey;

public sealed class MultipleChoiceQuestionEntity : QuestionEntityBase
{
  [JsonConstructor]
  public MultipleChoiceQuestionEntity(string text, string[] choices, string[] answers) : base(text)
  {
    Choices = choices;
    Answers = answers;
  }

  public MultipleChoiceQuestionEntity(MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity)
     : this(multipleChoiceQuestionTemplateEntity.Text, multipleChoiceQuestionTemplateEntity.Choices, Array.Empty<string>())
  { }

  public override QuestionType QuestionType => QuestionType.MultipleChoice;

  public string[] Choices { get; private set; }

  public string[] Answers { get; private set; }

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

    if (other is not MultipleChoiceQuestionEntity entity)
    {
      return false;
    }

    if (Text != entity.Text)
    {
      return false;
    }

    if (Choices == entity.Choices)
    {
      return true;
    }

    if (Choices.Length != entity.Choices.Length)
    {
      return false;
    }

    for (int i = 0; i < Choices.Length; i++)
    {
      if (Choices[i] != entity.Choices[i])
      {
        return false;
      }
    }

    if (Answers == entity.Answers)
    {
      return true;
    }

    if (Answers.Length != entity.Answers.Length)
    {
      return false;
    }

    for (int i = 0; i < Answers.Length; i++)
    {
      if (Answers[i] != entity.Answers[i])
      {
        return false;
      }
    }

    return true;
  }

  public void SetAnswers(string[] answers, ExecutingContext context)
  {
    if (answers.Length == 0)
    {
      Answers = Array.Empty<string>();
      return;
    }

    string[] temp = new string[answers.Length];
    int index = 0;

    for (int i = 0; i < answers.Length; i++)
    {
      for (int j = 0; j < Choices.Length; j++)
      {
        if (string.Equals(Choices[j], answers[i], StringComparison.OrdinalIgnoreCase))
        {
          temp[index++] = Choices[j];
        }
      }
    }

    if (index == answers.Length)
    {
      Answers = temp;
      return;
    }

    context.AddError("Unknown choice.");
  }
}
