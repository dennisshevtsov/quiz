// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class YesNoSurveyQuestionEntity : SurveyQuestionEntityBase
{
  public YesNoSurveyQuestionEntity() { }

  public YesNoSurveyQuestionEntity(YesNoSurveyTemplateQuestionEntity yesNoSurveyTemplateQuestionEntity)
  {
    Text = yesNoSurveyTemplateQuestionEntity.Text;
  }

  public override QuestionType QuestionType => QuestionType.YesNo;
}
