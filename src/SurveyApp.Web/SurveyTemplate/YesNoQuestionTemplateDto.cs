// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web;

public sealed class YesNoQuestionTemplateDto : SurveyTemplateQuestionDtoBase
{
  public YesNoQuestionTemplateDto() { }

  public YesNoQuestionTemplateDto(YesNoSurveyTemplateQuestionEntity yesNoQuestionTemplateEntity)
  {
    Text = yesNoQuestionTemplateEntity.Text;
  }

  public override SurveyTemplateQuestionEntityBase ToSurveyTemplateQuestionEntity() => new YesNoSurveyTemplateQuestionEntity
  {
    Text = Text,
  };
}
