// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class UpdateSurveyRequestDtoTest
{
  [TestMethod]
  public void UpdateSurvey_SurveyEntity_TitleUpdated()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      Title = Guid.NewGuid().ToString(),
    };

    SurveyEntity surveyEntity = new(
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity);

    // Assert
    Assert.AreEqual(updateSurveyRequestDto.Title, surveyEntity.Title);
  }

  [TestMethod]
  public void UpdateSurvey_SurveyEntity_DescriptionUpdated()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      Description = Guid.NewGuid().ToString(),
    };

    SurveyEntity surveyEntity = new(
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity);

    // Assert
    Assert.AreEqual(updateSurveyRequestDto.Description, surveyEntity.Description);
  }

  [TestMethod]
  public void UpdateSurvey_SurveyEntity_CandidateNameUpdated()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      CandidateName = Guid.NewGuid().ToString(),
    };

    SurveyEntity surveyEntity = new(
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity);

    // Assert
    Assert.AreEqual(updateSurveyRequestDto.CandidateName, surveyEntity.CandidateName);
  }

  [TestMethod]
  public void UpdateSurvey_SurveyEntity_QuestionsUpdated()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      Questions = new QuestionDtoBase[]
      {
        new YesNoQuestionDto(),
        new TextQuestionDto(),
      },
    };

    SurveyEntity surveyEntity = new(
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity);

    // Assert
    Assert.AreEqual(updateSurveyRequestDto.Questions.Length, surveyEntity.Questions.Length);
  }
}
