// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.SurveyTemplate;

public sealed record class YesNoQuestionTemplateEntity : QuestionTemplateEntityBase
{
  [JsonConstructor]
  public YesNoQuestionTemplateEntity(string text) : base(text) { }

  public YesNoQuestionTemplateEntity(YesNoQuestionTemplateEntity template)
    : base(template)
  { }

  public override QuestionType QuestionType => QuestionType.YesNo;

  public static void Validate(string text, ExecutingContext context)
  {
    if (string.IsNullOrEmpty(text))
    {
      context.AddError("Text is required.");
    }
  }

  public static YesNoQuestionTemplateEntity? New(string text, ExecutingContext context)
  {
    Validate(text, context);

    if (context.HasErrors)
    {
      return null;
    }

    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = new(text);

    return yesNoQuestionTemplateEntity;
  }
}
