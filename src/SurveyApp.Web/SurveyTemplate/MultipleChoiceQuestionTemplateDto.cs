// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyQuestion;

namespace SurveyApp.SurveyTemplate.Web;

public sealed class MultipleChoiceQuestionTemplateDto : SurveyTemplateQuestionDtoBase
{
  public MultipleChoiceQuestionTemplateDto() { }

  public MultipleChoiceQuestionTemplateDto(MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity)
  {
    Text = multipleChoiceQuestionTemplateEntity.Text;
    Choices = multipleChoiceQuestionTemplateEntity.Choices;
  }

  public string[] Choices { get; set; } = Array.Empty<string>();

  public override SurveyQuestionTemplateEntityBase ToQuestionTemplateEntity() => new MultipleChoiceQuestionTemplateEntity
  {
    Text = Text,
    Choices = Choices,
  };
}
