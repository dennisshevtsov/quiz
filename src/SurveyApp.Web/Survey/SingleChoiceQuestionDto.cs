// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class SingleChoiceQuestionDto : QuestionDtoBase
{
  public SingleChoiceQuestionDto() { }

  public SingleChoiceQuestionDto(SingleChoiceQuestionEntity singleChoiceQuestionEntity)
  {
    Text    = singleChoiceQuestionEntity.Text;
    Choices = singleChoiceQuestionEntity.Choices;
  }

  public string[] Choices { get; set; } = Array.Empty<string>();

  public override QuestionEntityBase ToQuestionEntity() => new SingleChoiceQuestionEntity
  {
    Text    = Text,
    Choices = Choices,
  };
}
