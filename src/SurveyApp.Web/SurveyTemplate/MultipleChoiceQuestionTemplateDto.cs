// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web;

public sealed class MultipleChoiceQuestionTemplateDto : SurveyTemplateQuestionDtoBase
{
  public MultipleChoiceQuestionTemplateDto() { }

  public MultipleChoiceQuestionTemplateDto(MultipleChoiceSurveyTemplateQuestionEntity multipleChoiceSurveyTemplateQuestionEntity)
  {
    Text = multipleChoiceSurveyTemplateQuestionEntity.Text;
    Choices = multipleChoiceSurveyTemplateQuestionEntity.Choices;
  }

  public string[] Choices { get; set; } = Array.Empty<string>();

  public override SurveyTemplateQuestionEntityBase ToSurveyTemplateQuestionEntity() => new MultipleChoiceSurveyTemplateQuestionEntity
  {
    Text = Text,
    Choices = Choices,
  };
}
