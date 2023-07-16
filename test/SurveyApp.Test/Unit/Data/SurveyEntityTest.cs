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
    // Arrange
    TestSurveyEntity controlSurveyEntity = new();

    // Act
    SurveyEntity actualSurveyEntity = new(controlSurveyEntity);

    // Assert
    TestSurveyEntity.AreEqual(controlSurveyEntity, actualSurveyEntity);
  }

  [TestMethod]
  public void Constructor_SurveyIdentityPassed_SurveyEntityCreated()
  {
    // Arrange
    TestSurveyIdentity controlSurveyIdentity = new();

    // Act
    SurveyEntity actualSurveyEntity = new(controlSurveyIdentity);

    // Assert
    Assert.AreEqual(controlSurveyIdentity.SurveyId, actualSurveyEntity.SurveyId);
  }

  [TestMethod]
  public void Constructor_SurveyIdentityPassed_IdPopulated()
  {
    // Arrange
    TestSurveyIdentity controlSurveyIdentity = new();

    // Act
    SurveyEntity actualSurveyEntity = new(controlSurveyIdentity);

    // Assert
    Assert.AreEqual(controlSurveyIdentity.SurveyId, actualSurveyEntity.Id);
  }
}
