// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web;

public sealed class MultipleChoiceQuestionTemplateDto : QuestionTemplateDtoBase
{
  public MultipleChoiceQuestionTemplateDto() { }

  public MultipleChoiceQuestionTemplateDto(MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity)
  {
    Text    = multipleChoiceQuestionTemplateEntity.Text;
    Choices = multipleChoiceQuestionTemplateEntity.Choices;
  }

  public string[] Choices { get; set; } = Array.Empty<string>();

  public override QuestionTemplateEntityBase ToTemplateQuestionEntity() => new MultipleChoiceQuestionTemplateEntity
  (
    text   : Text,
    choices: Choices
  );
}
