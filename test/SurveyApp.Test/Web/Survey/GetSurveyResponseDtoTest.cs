// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class GetSurveyResponseDtoTest
{
  [TestMethod]
  public void Constructor_SurveyEntity_PropertiesFilled()
  {
    // Arrange
    SurveyEntity surveyEntity = new(
      surveyId     : Guid.NewGuid(),
      state        : SurveyState.Draft,
      title        : Guid.NewGuid().ToString(),
      description  : Guid.NewGuid().ToString(),
      candidateName: Guid.NewGuid().ToString(),
      questions    : new QuestionEntityBase[]
      {
        new TextQuestionEntity(
          text  : Guid.NewGuid().ToString(),
          answer: Guid.NewGuid().ToString()),
        new YesNoQuestionEntity(
          text  : Guid.NewGuid().ToString(),
          answer: YesNo.Yes)
      });

    // Act
    GetSurveyResponseDto getSurveyResponseDto = new(surveyEntity);

    // Assert
    Assert.AreEqual(surveyEntity.SurveyId, getSurveyResponseDto.SurveyId);
    Assert.AreEqual(surveyEntity.Title, getSurveyResponseDto.Title);
    Assert.AreEqual(surveyEntity.Description, getSurveyResponseDto.Description);
    Assert.AreEqual(surveyEntity.CandidateName, getSurveyResponseDto.CandidateName);
    Assert.AreEqual(surveyEntity.Questions.Length, getSurveyResponseDto.Questions.Length);
  }
}
