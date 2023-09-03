// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class YesNoSurveyTemplateQuestionEntity : SurveyTemplateQuestionEntityBase
{
  public YesNoSurveyTemplateQuestionEntity() { }

  public YesNoSurveyTemplateQuestionEntity(YesNoSurveyTemplateQuestionEntity yesNoQuestionTemplateEntity)
  {
    Text = yesNoQuestionTemplateEntity.Text;
  }

  public override QuestionType QuestionType => QuestionType.YesNo;
}
