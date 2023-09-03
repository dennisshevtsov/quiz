// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class MultipleChoiceQuestionTemplateDto : SurveyQuestionDtoBase
{
  public MultipleChoiceQuestionTemplateDto() { }

  public MultipleChoiceQuestionTemplateDto(MultipleChoiceSurveyQuestionEntity multipleChoiceSurveyQuestionEntity)
  {
    Text    = multipleChoiceSurveyQuestionEntity.Text;
    Choices = multipleChoiceSurveyQuestionEntity.Choices;
  }

  public string[] Choices { get; set; } = Array.Empty<string>();

  public override SurveyQuestionEntityBase ToSurveyQuestionEntity() => new MultipleChoiceSurveyQuestionEntity
  {
    Text    = Text,
    Choices = Choices,
  };
}
