// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp;

public sealed class SurveyEntity
{
  public Guid SurveyId { get; set; }

  public string Title { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  public List<SurveyQuestionEntityBase> Questions { get; set; } = new();
}
