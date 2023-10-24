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

  public static void Validate(string text, string[] choices, ExecutingContext context)
  {
    if (string.IsNullOrEmpty(text))
    {
      context.AddError("Text is required.");
    }

    if (choices == null || choices.Length == 0)
    {
      context.AddError("Choices are required.");
    }
    else
    {
      for (int i = 0; i < choices.Length; i++)
      {
        if (string.IsNullOrEmpty(choices[i]))
        {
          context.AddError("Choices cannot contain an empty choice.");
        }
      }
    }
  }

  public static MultipleChoiceQuestionTemplateEntity? New(string text, string[] choices, ExecutingContext context)
  {
    Validate(text, choices, context);

    if (context.HasErrors)
    {
      return null;
    }

    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = new
    (
      text   : text,
      choices: choices
    );

    return multipleChoiceQuestionTemplateEntity;
  }
}
