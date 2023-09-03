// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class TextQuestionTemplateDto : SurveyQuestionDtoBase
{
  public TextQuestionTemplateDto() { }

  public TextQuestionTemplateDto(TextSurveyQuestionEntity textQuestionTemplateEntity)
  {
    Text = textQuestionTemplateEntity.Text;
  }

  public override SurveyQuestionEntityBase ToSurveyQuestionEntity() => new TextSurveyQuestionEntity
  {
    Text = Text,
  };
}
