// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.App.Test;

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
  public void Compare_SurveyEntityPassed_SurveyIdNotReturned()
  {
    // Arrange
    TestSurveyIdentity originalSurveyIdentity = new();
    SurveyEntity originalSurveyEntity = new(originalSurveyIdentity);

    TestSurveyEntity newSurveyEntity = new();

    // Act
    IEnumerable<string> differentProperties = originalSurveyEntity.Compare(newSurveyEntity);

    // Assert
    Assert.IsFalse(differentProperties.Contains(nameof(ISurveyEntity.SurveyId)));
  }

  [TestMethod]
  public void Compare_SurveyEntityPassed_NameReturned()
  {
    // Arrange
    TestSurveyIdentity originalSurveyIdentity = new();
    SurveyEntity originalSurveyEntity = new(originalSurveyIdentity);

    TestSurveyEntity newSurveyEntity = new();

    // Act
    IEnumerable<string> differentProperties = originalSurveyEntity.Compare(newSurveyEntity);

    // Assert
    Assert.IsTrue(differentProperties.Contains(nameof(ISurveyEntity.Name)));
  }

  [TestMethod]
  public void Compare_SurveyEntityPassed_DescriptionReturned()
  {
    // Arrange
    TestSurveyIdentity originalSurveyIdentity = new();
    SurveyEntity originalSurveyEntity = new(originalSurveyIdentity);

    TestSurveyEntity newSurveyEntity = new();

    // Act
    IEnumerable<string> differentProperties = originalSurveyEntity.Compare(newSurveyEntity);

    // Assert
    Assert.IsTrue(differentProperties.Contains(nameof(ISurveyEntity.Description)));
  }
}
