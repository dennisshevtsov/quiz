// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class TextQuestionDto : QuestionDtoBase
{
  public TextQuestionDto() { }

  public TextQuestionDto(TextQuestionEntity textQuestionEntity)
  {
    Text = textQuestionEntity.Text;
  }

  public override QuestionEntityBase ToQuestionEntity() => new TextQuestionEntity
  {
    Text = Text,
  };
}
