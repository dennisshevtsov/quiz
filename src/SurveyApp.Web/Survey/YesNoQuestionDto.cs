// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class YesNoQuestionDto : QuestionDtoBase
{
  public YesNoQuestionDto() { }

  public YesNoQuestionDto(YesNoQuestionEntity yesNoQuestionEntity)
  {
    Text = yesNoQuestionEntity.Text;
  }

  public override QuestionEntityBase ToQuestionEntity() => new YesNoQuestionEntity
  {
    Text = Text,
  };
}
