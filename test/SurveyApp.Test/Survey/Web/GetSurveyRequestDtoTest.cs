// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class GetSurveyRequestDtoTest
{
  [TestMethod]
  public void Constructor_SurveyEntity_SurveyIdFilled()
  {
    // Arrange
    Guid surveyId = Guid.NewGuid();
    SurveyEntity surveyEntity = new(surveyId, SurveyState.Draft, string.Empty, string.Empty, string.Empty, Array.Empty<QuestionEntityBase>());

    // Act
    GetSurveyRequestDto getSurveyRequestDto = new(surveyEntity);

    // Assert
    Assert.AreEqual(surveyId, getSurveyRequestDto.SurveyId);
  }
}
