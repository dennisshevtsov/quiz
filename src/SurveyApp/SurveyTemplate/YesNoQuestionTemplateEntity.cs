// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.SurveyTemplate;

public sealed class YesNoQuestionTemplateEntity : QuestionTemplateEntityBase
{
  [JsonConstructor]
  public YesNoQuestionTemplateEntity(string text) : base(text) { }

  public YesNoQuestionTemplateEntity(YesNoQuestionTemplateEntity template)
    : this(template.Text)
  { }

  public override QuestionType QuestionType => QuestionType.YesNo;

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

    if (other is not YesNoQuestionTemplateEntity entity)
    {
      return false;
    }

    return Text == entity.Text;
  }

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
