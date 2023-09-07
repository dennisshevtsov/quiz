// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class YesNoQuestionEntity : QuestionEntityBase
{
  public YesNoQuestionEntity() { }

  public YesNoQuestionEntity(YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity)
  {
    Text = yesNoQuestionTemplateEntity.Text;
  }

  public override QuestionType QuestionType => QuestionType.YesNo;

  public YesNo Answer { get; set; }
}
