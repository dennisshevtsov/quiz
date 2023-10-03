// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class TextQuestionTemplateEntity : QuestionTemplateEntityBase
{
  private TextQuestionTemplateEntity(string text) : base(text) { }

  public TextQuestionTemplateEntity(TextQuestionTemplateEntity textQuestionTemplateEntity)
    : this(textQuestionTemplateEntity.Text)
  { }

  public override QuestionType QuestionType => QuestionType.Text;

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

    TextQuestionTemplateEntity textQuestionTemplateEntity = new
    (
      text: text
    );

    return ExecutedContext<QuestionTemplateEntityBase>.Ok(textQuestionTemplateEntity);
  }
}
