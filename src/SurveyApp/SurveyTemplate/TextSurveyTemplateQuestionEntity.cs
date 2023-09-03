// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class TextSurveyTemplateQuestionEntity : SurveyTemplateQuestionEntityBase
{
  public TextSurveyTemplateQuestionEntity() { }

  public TextSurveyTemplateQuestionEntity(TextSurveyTemplateQuestionEntity textQuestionTemplateEntity)
  {
    Text = textQuestionTemplateEntity.Text;
  }

  public override SurveyQuestionType QuestionType => SurveyQuestionType.Text;
}
