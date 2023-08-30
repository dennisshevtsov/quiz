// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyQuestion;

public sealed class TextQuestionEntity : SurveyQuestionEntityBase
{
  public TextQuestionEntity() { }

  public TextQuestionEntity(TextQuestionEntity textQuestionTemplateEntity)
  {
    Text = textQuestionTemplateEntity.Text;
  }

  public override SurveyQuestionType QuestionType => SurveyQuestionType.Text;

  public override SurveyQuestionEntityBase Clone() => new TextQuestionEntity(this);
}
