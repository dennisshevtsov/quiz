// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Data.Test;

[TestClass]
public sealed class SurveyEntityTest
{
  [TestMethod]
  public void Constructor_Should_Copy_Data()
  {
    var controlSurveyEntity = new TestSurveyEntity();
    var actualSurveyEntity = new SurveyEntity(controlSurveyEntity);

    Assert.AreEqual(controlSurveyEntity.Name, actualSurveyEntity.Name);
    Assert.AreEqual(controlSurveyEntity.Description, actualSurveyEntity.Description);
  }

  [TestMethod]
  public void Constructor_Should_Copy_Entity()
  {
    var controlSurveyEntity = new TestSurveyEntity();
    var actualSurveyEntity = new SurveyEntity(controlSurveyEntity);

    Assert.AreEqual(controlSurveyEntity.Name, actualSurveyEntity.Name);
    Assert.AreEqual(controlSurveyEntity.Description, actualSurveyEntity.Description);
  }
}
