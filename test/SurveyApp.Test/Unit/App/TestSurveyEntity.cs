// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.App.Test;

public sealed class TestSurveyEntity : ISurveyEntity
{
  public Guid SurveyId { get; } = Guid.NewGuid();

  public string Name { get; } = Guid.NewGuid().ToString();

  public string Description { get; } = Guid.NewGuid().ToString();

  public static void AreEqual(ISurveyEntity control, ISurveyEntity actual)
  {
    Assert.AreEqual(control.SurveyId, actual.SurveyId);
    Assert.AreEqual(control.Name, actual.Name);
    Assert.AreEqual(control.Description, actual.Description);
  }
}
