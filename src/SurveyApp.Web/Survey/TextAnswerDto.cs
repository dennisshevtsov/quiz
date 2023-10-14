﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class TextAnswerDto : AnswerDtoBase
{
  public string? Answer { get; set; }

  public override void SetAnswer(QuestionEntityBase questionEntity, ExecutingContext context)
  {
    if (questionEntity is TextQuestionEntity textQuestionEntity)
    {
      textQuestionEntity.SetAnswer(Answer);
    }
  }
}
