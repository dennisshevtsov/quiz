﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web;

public abstract class SurveyTemplateQuestionDtoBase
{
  public string Text { get; set; } = string.Empty;

  public abstract SurveyQuestionType QuestionType { get; }
}
