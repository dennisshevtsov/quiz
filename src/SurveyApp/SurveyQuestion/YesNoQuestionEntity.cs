// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyQuestion;

public sealed class YesNoQuestionEntity : SurveyQuestionEntityBase
{
  public YesNoQuestionEntity() { }

  public YesNoQuestionEntity(YesNoQuestionEntity yesNoQuestionTemplateEntity)
  {
    Text = yesNoQuestionTemplateEntity.Text;
  }

  public override SurveyQuestionType QuestionType => SurveyQuestionType.YesNo;

  public override SurveyQuestionEntityBase Clone() => new YesNoQuestionEntity(this);
}
