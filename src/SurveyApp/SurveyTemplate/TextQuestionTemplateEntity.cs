// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class TextQuestionTemplateEntity : QuestionTemplateEntityBase
{
  public TextQuestionTemplateEntity(string text) : base(text) { }

  public TextQuestionTemplateEntity(TextQuestionTemplateEntity textQuestionTemplateEntity)
    : this(textQuestionTemplateEntity.Text)
  { }

  public override QuestionType QuestionType => QuestionType.Text;
}
