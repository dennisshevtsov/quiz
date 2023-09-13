// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Test;

[TestClass]
public sealed class SurveyEntityTest
{
  [TestMethod]
  public void Constructor_FullListOfParameters_SurveyIdFilled()
  {
    // Arrange
    Guid surveyId = Guid.NewGuid();

    // Act
    SurveyEntity surveyEntity = new(
      surveyId     : surveyId,
      state        : default,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Assert
    Assert.AreEqual(surveyId, surveyEntity.SurveyId);
  }

  [TestMethod]
  public void Constructor_FullListOfParameters_StateFilled()
  {
    // Arrange
    SurveyState state = SurveyState.Ready;

    // Act
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : state,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Assert
    Assert.AreEqual(state, surveyEntity.State);
  }

  [TestMethod]
  public void Constructor_FullListOfParameters_TitleFilled()
  {
    // Arrange
    string title = Guid.NewGuid().ToString();

    // Act
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : default,
      title        : title,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Assert
    Assert.AreEqual(title, surveyEntity.Title);
  }

  [TestMethod]
  public void Constructor_FullListOfParameters_DescriptionFilled()
  {
    // Arrange
    string description = Guid.NewGuid().ToString();

    // Act
    SurveyEntity surveyEntity = new(
      surveyId: default,
      state: default,
      title: string.Empty,
      description: description,
      candidateName: string.Empty,
      questions: Array.Empty<QuestionEntityBase>());

    // Assert
    Assert.AreEqual(description, surveyEntity.Description);
  }

  [TestMethod]
  public void Constructor_FullListOfParameters_CandidateNameFilled()
  {
    // Arrange
    string candidateName = Guid.NewGuid().ToString();

    // Act
    SurveyEntity surveyEntity = new(
      surveyId: default,
      state: default,
      title: string.Empty,
      description: string.Empty,
      candidateName: candidateName,
      questions: Array.Empty<QuestionEntityBase>());

    // Assert
    Assert.AreEqual(candidateName, surveyEntity.CandidateName);
  }
}
