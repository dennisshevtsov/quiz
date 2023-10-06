// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web;

public sealed class TextQuestionTemplateDto : QuestionTemplateDtoBase
{
  public TextQuestionTemplateDto() { }

  public TextQuestionTemplateDto(TextQuestionTemplateEntity textQuestionTemplateEntity)
  {
    Text         = textQuestionTemplateEntity.Text;
    QuestionType = QuestionType.Text;
  }

  public override QuestionTemplateEntityBase? ToTemplateQuestionEntity(ExecutingContext context) =>
    TextQuestionTemplateEntity.New(Text, context);
}
