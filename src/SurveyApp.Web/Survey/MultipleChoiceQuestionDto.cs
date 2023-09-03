// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class MultipleChoiceQuestionDto : QuestionDtoBase
{
  public MultipleChoiceQuestionDto() { }

  public MultipleChoiceQuestionDto(MultipleChoiceQuestionEntity multipleChoiceQuestionEntity)
  {
    Text    = multipleChoiceQuestionEntity.Text;
    Choices = multipleChoiceQuestionEntity.Choices;
  }

  public string[] Choices { get; set; } = Array.Empty<string>();

  public override QuestionEntityBase ToQuestionEntity() => new MultipleChoiceQuestionEntity
  {
    Text    = Text,
    Choices = Choices,
  };
}
