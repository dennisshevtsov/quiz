// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Data.Test;

public sealed class TestSurveyIdentity : ISurveyIdentity
{
  public Guid SurveyId { get; } = Guid.NewGuid();
}
