// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class YesNoQuestionTemplateDto : SurveyQuestionDtoBase
{
  public YesNoQuestionTemplateDto() { }

  public YesNoQuestionTemplateDto(YesNoSurveyQuestionEntity yesNoQuestionTemplateEntity)
  {
    Text = yesNoQuestionTemplateEntity.Text;
  }

  public override SurveyQuestionEntityBase ToSurveyQuestionEntity() => new YesNoSurveyQuestionEntity
  {
    Text = Text,
  };
}
