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
    TestSurveyEntity controlSurveyEntity = new();
    SurveyEntity     actualSurveyEntity  = new(controlSurveyEntity);

    TestSurveyEntity.AreEqual(controlSurveyEntity, actualSurveyEntity);
  }

  [TestMethod]
  public void Constructor_SurveyIdentityPassed_SurveyEntityCreated()
  {
    TestSurveyIdentity controlSurveyIdentity = new();
    SurveyEntity       actualSurveyEntity    = new(controlSurveyIdentity);

    Assert.AreEqual(controlSurveyIdentity.SurveyId, actualSurveyEntity.SurveyId);
  }

  [TestMethod]
  public void Update_SurveyEntityPassed_SurveyIdNotUpdated()
  {
    TestSurveyIdentity originalSurveyIdentity = new();
    TestSurveyEntity   newSurveyEntity        = new();

    SurveyEntity actualSurveyEntity = new(originalSurveyIdentity);
    actualSurveyEntity.Update(newSurveyEntity);

    Assert.AreEqual(originalSurveyIdentity.SurveyId, actualSurveyEntity.SurveyId);
  }

  [TestMethod]
  public void Update_SurveyEntityPassed_UpdatablePropertiesUpdated()
  {
    TestSurveyIdentity originalSurveyIdentity = new();
    TestSurveyEntity   newSurveyEntity        = new();

    SurveyEntity actualSurveyEntity = new(originalSurveyIdentity);
    actualSurveyEntity.Update(newSurveyEntity);

    TestSurveyEntity.ArePartiallyEqual(newSurveyEntity, actualSurveyEntity);
  }
}
