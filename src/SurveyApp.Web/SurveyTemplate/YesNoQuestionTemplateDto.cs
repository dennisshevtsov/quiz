// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyQuestion;

namespace SurveyApp.SurveyTemplate.Web;

public sealed class YesNoQuestionTemplateDto : SurveyTemplateQuestionDtoBase
{
  public YesNoQuestionTemplateDto() { }

  public YesNoQuestionTemplateDto(YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity)
  {
    Text = yesNoQuestionTemplateEntity.Text;
  }

  public override SurveyQuestionTemplateEntityBase ToQuestionTemplateEntity() => new YesNoQuestionTemplateEntity
  {
     Text = Text,
  };
}
