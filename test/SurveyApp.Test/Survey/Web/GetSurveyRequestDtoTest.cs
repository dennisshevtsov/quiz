// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.Survey.Test;

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class GetSurveyRequestDtoTest
{
  [TestMethod]
  public void Constructor_SurveyEntity_SurveyIdFilled()
  {
    // Arrange
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey();

    // Act
    GetSurveyRequestDto getSurveyRequestDto = new(surveyEntity);

    // Assert
    Assert.AreEqual(surveyEntity.SurveyId, getSurveyRequestDto.SurveyId);
  }
}
