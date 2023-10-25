// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.SurveyTemplate;

public sealed class MultipleChoiceQuestionTemplateEntity : QuestionTemplateEntityBase
{
  [JsonConstructor]
  public MultipleChoiceQuestionTemplateEntity(string text, string[] choices) : base(text)
  {
    Choices = choices;
  }

  public MultipleChoiceQuestionTemplateEntity(MultipleChoiceQuestionTemplateEntity template)
    : this(template.Text, template.Choices)
  { }

  public override QuestionType QuestionType => QuestionType.MultipleChoice;

  public string[] Choices { get; private set; }

  public override bool Equals(QuestionTemplateEntityBase? other)
  {
    if (other == null)
    {
      return false;
    }

    if (object.ReferenceEquals(other, this))
    {
      return true;
    }

    if (other is not MultipleChoiceQuestionTemplateEntity entity)
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

    return true;
  }

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
