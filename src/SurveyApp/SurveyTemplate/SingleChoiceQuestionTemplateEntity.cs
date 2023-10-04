// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class SingleChoiceQuestionTemplateEntity : QuestionTemplateEntityBase
{
  private SingleChoiceQuestionTemplateEntity(string text, string[] choices) : base(text)
  {
    Choices = choices;
  }

  public SingleChoiceQuestionTemplateEntity(SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity)
    : this(singleChoiceQuestionTemplateEntity.Text, singleChoiceQuestionTemplateEntity.Choices.Select(choice => choice).ToArray())
  { }

  public override QuestionType QuestionType => QuestionType.SingleChoice;

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

  public static SingleChoiceQuestionTemplateEntity? New(string text, string[] choices, ExecutingContext context)
  {
    Validate(text, choices, context);

    if (context.HasErrors)
    {
      return null;
    }

    SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity = new
    (
      text   : text,
      choices: choices
    );

    return singleChoiceQuestionTemplateEntity;
  }
}
