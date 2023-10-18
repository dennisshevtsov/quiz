// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.SurveyTemplate.Web;

public sealed class MultipleChoiceQuestionTemplateDto : QuestionTemplateDtoBase
{
  public MultipleChoiceQuestionTemplateDto() { }

  public MultipleChoiceQuestionTemplateDto(MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity)
  {
    Text         = multipleChoiceQuestionTemplateEntity.Text;
    Choices      = multipleChoiceQuestionTemplateEntity.Choices;
    QuestionType = QuestionType.MultipleChoice;
  }

  [JsonPropertyName("choices")]
  public string[] Choices { get; set; } = Array.Empty<string>();

  public override QuestionTemplateEntityBase? ToTemplateQuestionEntity(ExecutingContext context) => MultipleChoiceQuestionTemplateEntity.New
  (
    text   : Text,
    choices: Choices,
    context: context
  );
}
