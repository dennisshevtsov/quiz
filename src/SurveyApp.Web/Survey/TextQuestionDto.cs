// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class TextQuestionDto : QuestionDtoBase
{
  public TextQuestionDto()
  {
    Answer = string.Empty;
  }

  public TextQuestionDto(TextQuestionEntity textQuestionEntity) : this()
  {
    Text = textQuestionEntity.Text;
  }

  public string Answer { get; set; }

  public override QuestionEntityBase ToQuestionEntity() => new TextQuestionEntity
  (
    text  : Text,
    answer: null
  );
}
