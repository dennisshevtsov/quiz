// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public abstract class AnswerDtoBase
{
  public abstract void SetAnswer(QuestionEntityBase questionEntity, ExecutingContext context);
}
