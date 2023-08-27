// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyQuestion;

namespace SurveyApp.SurveyTemplate.Web;

public sealed class TextQuestionTemplateDto : SurveyTemplateQuestionDtoBase
{
  public TextQuestionTemplateDto() { }

  public TextQuestionTemplateDto(TextQuestionTemplateEntity textQuestionTemplateEntity)
  {
    Text = textQuestionTemplateEntity.Text;
  }

  public override SurveyQuestionTemplateEntityBase ToQuestionTemplateEntity() => new TextQuestionTemplateEntity
  {
    Text = Text,
  };
}
