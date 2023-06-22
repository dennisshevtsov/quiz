// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Data.Test;

[TestClass]
public sealed class SurveyEntityTest
{
  [TestMethod]
  public void Constructor_SurveyEntityPassed_SurveyEntityCreated()
  {
    var controlSurveyEntity = new TestSurveyEntity();
    var actualSurveyEntity = new SurveyEntity(controlSurveyEntity);

    TestSurveyEntity.AreEqual(controlSurveyEntity, actualSurveyEntity);
  }
}
