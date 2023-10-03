// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class YesNoQuestionTemplateEntity : QuestionTemplateEntityBase
{
  public YesNoQuestionTemplateEntity(string text) : base(text) { }

  public YesNoQuestionTemplateEntity(YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity)
    : this(yesNoQuestionTemplateEntity.Text)
  { }

  public override QuestionType QuestionType => QuestionType.YesNo;

  public static void Validate(string text, IList<string> errors)
  {
    if (string.IsNullOrEmpty(text))
    {
      errors.Add("Text is required.");
    }
  }
}
