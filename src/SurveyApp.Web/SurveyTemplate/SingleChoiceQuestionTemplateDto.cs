// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.SurveyTemplate.Web;

public sealed class SingleChoiceQuestionTemplateDto : QuestionTemplateDtoBase
{
  public SingleChoiceQuestionTemplateDto() { }

  public SingleChoiceQuestionTemplateDto(SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity)
  {
    Text         = singleChoiceQuestionTemplateEntity.Text;
    Choices      = singleChoiceQuestionTemplateEntity.Choices;
    QuestionType = QuestionType.SingleChoice;
  }

  [JsonPropertyName("choices")]
  public string[] Choices { get; set; } = Array.Empty<string>();

  public override QuestionTemplateEntityBase? ToTemplateQuestionEntity(ExecutingContext context) => SingleChoiceQuestionTemplateEntity.New
  (
    text   : Text,
    choices: Choices,
    context: context
  );
}
