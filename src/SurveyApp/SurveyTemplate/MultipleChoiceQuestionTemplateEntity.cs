// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class MultipleChoiceQuestionTemplateEntity : QuestionTemplateEntityBase
{
  public MultipleChoiceQuestionTemplateEntity(string text, string[] choices) : base(text)
  {
    Choices = choices;
  }

  public MultipleChoiceQuestionTemplateEntity(MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity)
    : this(multipleChoiceQuestionTemplateEntity.Text, multipleChoiceQuestionTemplateEntity.Choices)
  { }

  public override QuestionType QuestionType => QuestionType.MultipleChoice;

  public string[] Choices { get; private set; }

  public static void Validate(string text, string[] choices, IList<string> errors)
  {
    if (string.IsNullOrEmpty(text))
    {
      errors.Add("Text is required.");
    }

    if (choices == null || choices.Length == 0)
    {
      errors.Add("Choices are required.");
    }
    else
    {
      for (int i = 0; i < choices.Length; i++)
      {
        if (string.IsNullOrEmpty(choices[i]))
        {
          errors.Add("Choices cannot contain an empty choice.");
        }
      }
    }
  }
}
