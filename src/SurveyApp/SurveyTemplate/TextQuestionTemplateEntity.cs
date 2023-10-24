// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.SurveyTemplate;

public sealed class TextQuestionTemplateEntity : QuestionTemplateEntityBase
{
  [JsonConstructor]
  public TextQuestionTemplateEntity(string text) : base(text) { }

  public TextQuestionTemplateEntity(TextQuestionTemplateEntity textQuestionTemplateEntity)
    : this(textQuestionTemplateEntity.Text)
  { }

  public override QuestionType QuestionType => QuestionType.Text;

  public static void Validate(string text, ExecutingContext context)
  {
    if (string.IsNullOrEmpty(text))
    {
      context.AddError("Text is required.");
    }
  }

  public static TextQuestionTemplateEntity? New(string text, ExecutingContext context)
  {
    Validate(text, context);

    if (context.HasErrors)
    {
      return null;
    }

    TextQuestionTemplateEntity textQuestionTemplateEntity = new(text);

    return textQuestionTemplateEntity;
  }
}
