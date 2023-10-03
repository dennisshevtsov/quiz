// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class YesNoQuestionTemplateEntity : QuestionTemplateEntityBase
{
  private YesNoQuestionTemplateEntity(string text) : base(text) { }

  public YesNoQuestionTemplateEntity(YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity)
    : this(yesNoQuestionTemplateEntity.Text)
  { }

  public override QuestionType QuestionType => QuestionType.YesNo;

  public static string[] Validate(string text)
  {
    List<string> errors = new();

    if (string.IsNullOrEmpty(text))
    {
      errors.Add("Text is required.");
    }

    return errors.ToArray();
  }

  public static ExecutedContext<QuestionTemplateEntityBase> New(string text)
  {
    string[] errors = Validate(text);

    if (errors.Length > 0)
    {
      return ExecutedContext<QuestionTemplateEntityBase>.Fail(errors);
    }

    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = new
    (
      text: text
    );

    return ExecutedContext<QuestionTemplateEntityBase>.Ok(yesNoQuestionTemplateEntity);
  }
}
