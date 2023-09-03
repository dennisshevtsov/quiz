// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web;

public sealed class SingleChoiceQuestionTemplateDto : SurveyTemplateQuestionDtoBase
{
  public SingleChoiceQuestionTemplateDto() { }

  public SingleChoiceQuestionTemplateDto(SingleChoiceSurveyTemplateQuestionEntity singleChoiceSurveyTemplateQuestionEntity)
  {
    Text = singleChoiceSurveyTemplateQuestionEntity.Text;
    Choices = singleChoiceSurveyTemplateQuestionEntity.Choices;
  }

  public string[] Choices { get; set; } = Array.Empty<string>();

  public override SurveyTemplateQuestionEntityBase ToSurveyTemplateQuestionEntity() => new SingleChoiceSurveyTemplateQuestionEntity
  {
    Text = Text,
    Choices = Choices,
  };
}
