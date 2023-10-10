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
      Title         = Guid.NewGuid().ToString(),
      Description   = Guid.NewGuid().ToString(),
      CandidateName = Guid.NewGuid().ToString(),
    };

    SurveyEntity surveyEntity = null!;//new(
    //  title        : string.Empty,
    //  description  : string.Empty,
    //  candidateName: string.Empty,
    //  questions    : Array.Empty<QuestionEntityBase>());

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, new ExecutingContext());

    // Assert
    Assert.AreEqual(updateSurveyRequestDto.Title, surveyEntity.Title);
  }

  [TestMethod]
  public void UpdateSurvey_NoTitle_TitleNotUpdated()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      Title         = string.Empty,
      Description   = Guid.NewGuid().ToString(),
      CandidateName = Guid.NewGuid().ToString(),
    };

    string originalTitle = Guid.NewGuid().ToString();

    SurveyEntity surveyEntity = null!;//new(
      //title        : originalTitle,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, new ExecutingContext());

    // Assert
    Assert.AreEqual(originalTitle, surveyEntity.Title);
  }

  [TestMethod]
  public void UpdateSurvey_NoTitle_ContextHasErrors()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      Title         = string.Empty,
      Description   = Guid.NewGuid().ToString(),
      CandidateName = Guid.NewGuid().ToString(),
    };

    SurveyEntity surveyEntity = null!;// new(
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void UpdateSurvey_SurveyEntity_DescriptionUpdated()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      Title         = Guid.NewGuid().ToString(),
      Description   = Guid.NewGuid().ToString(),
      CandidateName = Guid.NewGuid().ToString(),
    };

    SurveyEntity surveyEntity = null!;// new(
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, new ExecutingContext());

    // Assert
    Assert.AreEqual(updateSurveyRequestDto.Description, surveyEntity.Description);
  }

  [TestMethod]
  public void UpdateSurvey_NoDescription_TitleNotUpdated()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      Title         = Guid.NewGuid().ToString(),
      Description   = string.Empty,
      CandidateName = Guid.NewGuid().ToString(),
    };

    string originalDescription = Guid.NewGuid().ToString();

    SurveyEntity surveyEntity = null!;// new(
      //title        : string.Empty,
      //description  : originalDescription,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, new ExecutingContext());

    // Assert
    Assert.AreEqual(originalDescription, surveyEntity.Description);
  }

  [TestMethod]
  public void UpdateSurvey_NoDescription_ContextHasErrors()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      Title         = Guid.NewGuid().ToString(),
      Description   = string.Empty,
      CandidateName = Guid.NewGuid().ToString(),
    };

    SurveyEntity surveyEntity = null!;// new(
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void UpdateSurvey_SurveyEntity_CandidateNameUpdated()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      Title         = Guid.NewGuid().ToString(),
      Description   = Guid.NewGuid().ToString(),
      CandidateName = Guid.NewGuid().ToString(),
    };

    SurveyEntity surveyEntity = null!;// new(
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, new ExecutingContext());

    // Assert
    Assert.AreEqual(updateSurveyRequestDto.CandidateName, surveyEntity.CandidateName);
  }

  [TestMethod]
  public void UpdateSurvey_NoCandidateName_TitleNotUpdated()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      Title         = Guid.NewGuid().ToString(),
      Description   = Guid.NewGuid().ToString(),
      CandidateName = string.Empty,
    };

    string originalCandidateName = Guid.NewGuid().ToString();

    SurveyEntity surveyEntity = null!;// new(
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: originalCandidateName,
      //questions    : Array.Empty<QuestionEntityBase>());

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, new ExecutingContext());

    // Assert
    Assert.AreEqual(originalCandidateName, surveyEntity.CandidateName);
  }

  [TestMethod]
  public void UpdateSurvey_NoCandidateName_ContextHasErrors()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      Title         = Guid.NewGuid().ToString(),
      Description   = Guid.NewGuid().ToString(),
      CandidateName = string.Empty,
    };

    SurveyEntity surveyEntity = null!;// new(
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void UpdateSurvey_SurveyEntity_QuestionsUpdated()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      Title         = Guid.NewGuid().ToString(),
      Description   = Guid.NewGuid().ToString(),
      CandidateName = Guid.NewGuid().ToString(),
      Questions     = new QuestionDtoBase[]
      {
        new YesNoQuestionDto(),
        new TextQuestionDto(),
      },
    };

    SurveyEntity surveyEntity = null!;// new(
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, new ExecutingContext());

    // Assert
    Assert.AreEqual(updateSurveyRequestDto.Questions.Length, surveyEntity.Questions.Length);
  }
}
