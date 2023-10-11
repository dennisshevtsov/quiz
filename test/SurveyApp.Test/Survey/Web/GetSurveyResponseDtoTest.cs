// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.Survey.Test;

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class GetSurveyResponseDtoTest
{
  [TestMethod]
  public void Constructor_SurveyEntity_SurveyIdFilled()
  {
    // Arrange
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey();

    // Act
    GetSurveyResponseDto getSurveyResponseDto = new(surveyEntity);

    // Assert
    Assert.AreEqual(surveyEntity.SurveyId, getSurveyResponseDto.SurveyId);
  }

  [TestMethod]
  public void Constructor_SurveyEntity_TitleFilled()
  {
    // Arrange
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey();

    // Act
    GetSurveyResponseDto getSurveyResponseDto = new(surveyEntity);

    // Assert
    Assert.AreEqual(surveyEntity.Title, getSurveyResponseDto.Title);
  }

  [TestMethod]
  public void Constructor_SurveyEntity_DescriptionFilled()
  {
    // Arrange
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey();

    // Act
    GetSurveyResponseDto getSurveyResponseDto = new(surveyEntity);

    // Assert
    Assert.AreEqual(surveyEntity.Description, getSurveyResponseDto.Description);
  }
}
