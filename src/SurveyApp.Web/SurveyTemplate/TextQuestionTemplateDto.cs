// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web;

public sealed class TextQuestionTemplateDto : SurveyTemplateQuestionDtoBase
{
  public TextQuestionTemplateDto() { }

  public TextQuestionTemplateDto(TextSurveyTemplateQuestionEntity textQuestionTemplateEntity)
  {
    Text = textQuestionTemplateEntity.Text;
  }

  public override SurveyTemplateQuestionEntityBase ToSurveyTemplateQuestionEntity() => new TextSurveyTemplateQuestionEntity
  {
    Text = Text,
  };
}
