// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class YesNoQuestionDto : QuestionDtoBase
{
  public YesNoQuestionDto() : base()
  {
    Answer = YesNo.None;
  }

  public YesNoQuestionDto(YesNoQuestionEntity question) : this()
  {
    Text = question.Text;
  }

  public YesNo Answer { get; set; }

  public override QuestionEntityBase ToQuestionEntity() => new YesNoQuestionEntity
  (
    text  : Text,
    answer: Answer
  );
}
