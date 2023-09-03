// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class TextSurveyQuestionEntity : SurveyQuestionEntityBase
{
  public TextSurveyQuestionEntity() { }

  public TextSurveyQuestionEntity(TextSurveyTemplateQuestionEntity textSurveyTemplateQuestionEntity)
  {
    Text = textSurveyTemplateQuestionEntity.Text;
  }

  public override SurveyQuestionType QuestionType => SurveyQuestionType.Text;
}
