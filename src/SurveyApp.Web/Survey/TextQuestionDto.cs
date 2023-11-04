// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class TextQuestionDto : QuestionDtoBase
{
  public TextQuestionDto() : base()
  {
    Answer = string.Empty;
  }

  public TextQuestionDto(TextQuestionEntity question)
  {
    Text         = question.Text;
    Answer       = question.Answer;
    QuestionType = question.QuestionType;
  }

  public string? Answer { get; set; }

  public override QuestionEntityBase ToQuestionEntity() => new TextQuestionEntity
  (
    text  : Text,
    answer: null
  );
}
