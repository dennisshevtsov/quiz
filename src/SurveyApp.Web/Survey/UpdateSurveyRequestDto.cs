// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Composable;

namespace SurveyApp.Survey.Web;

public sealed class UpdateSurveyRequestDto : IComposable
{
  public Guid SurveyId { get; set; }

  public string IntervieweeName { get; set; } = string.Empty;

  public void UpdateSurvey(SurveyEntity surveyEntity, ExecutingContext context) =>
    surveyEntity.Update(IntervieweeName, context);
}
