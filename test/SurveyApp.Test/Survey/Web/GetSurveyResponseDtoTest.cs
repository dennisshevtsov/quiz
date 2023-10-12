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

  [TestMethod]
  public void Constructor_SurveyEntity_CandidateNameFilled()
  {
    // Arrange
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey();

    // Act
    GetSurveyResponseDto getSurveyResponseDto = new(surveyEntity);

    // Assert
    Assert.AreEqual(surveyEntity.IntervieweeName, getSurveyResponseDto.IntervieweeName);
  }

  [TestMethod]
  public void Constructor_SurveyEntity_QuestionFilledFilled()
  {
    // Arrange
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey
    (
      questions: new QuestionEntityBase[]
      {
        new YesNoQuestionEntity
        (
          text  : Guid.NewGuid().ToString(),
          answer: YesNo.None
        ),
        new TextQuestionEntity
        (
          text  : Guid.NewGuid().ToString(),
          answer: null
        ),
        new MultipleChoiceQuestionEntity
        (
          text   : Guid.NewGuid().ToString(),
          choices: new string[]
          {
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
          },
          answers: new string[]
          {
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
          }
        ),
        new SingleChoiceQuestionEntity
        (
          text   : Guid.NewGuid().ToString(),
          choices: new string[]
          {
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
          },
          answer : Guid.NewGuid().ToString()
        ),
      }
    );

    // Act
    GetSurveyResponseDto getSurveyResponseDto = new(surveyEntity);

    // Assert
    Assert.AreEqual(surveyEntity.Questions.Length, getSurveyResponseDto.Questions.Length);
  }
}
