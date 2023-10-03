// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web;

public sealed class TextQuestionTemplateDto : QuestionTemplateDtoBase
{
  public TextQuestionTemplateDto() { }

  public TextQuestionTemplateDto(TextQuestionTemplateEntity textQuestionTemplateEntity)
  {
    Text = textQuestionTemplateEntity.Text;
  }

  public override ExecutedContext<QuestionTemplateEntityBase> ToTemplateQuestionEntity() => TextQuestionTemplateEntity.New(Text);
}
