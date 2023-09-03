// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class SingleChoiceQuestionTemplateDto : SurveyQuestionDtoBase
{
  public SingleChoiceQuestionTemplateDto() { }

  public SingleChoiceQuestionTemplateDto(SingleChoiceSurveyQuestionEntity singleChoiceSurveyQuestionEntity)
  {
    Text    = singleChoiceSurveyQuestionEntity.Text;
    Choices = singleChoiceSurveyQuestionEntity.Choices;
  }

  public string[] Choices { get; set; } = Array.Empty<string>();

  public override SurveyQuestionEntityBase ToSurveyQuestionEntity() => new SingleChoiceSurveyQuestionEntity
  {
    Text    = Text,
    Choices = Choices,
  };
}
