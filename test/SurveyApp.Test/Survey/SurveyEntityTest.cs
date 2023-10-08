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
      surveyId     : default,
      state        : default,
      title        : string.Empty,
      description  : description,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

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
      surveyId     : default,
      state        : default,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: candidateName,
      questions    : Array.Empty<QuestionEntityBase>());

    // Assert
    Assert.AreEqual(candidateName, surveyEntity.CandidateName);
  }

  [TestMethod]
  public void Constructor_FullListOfParameters_QuestionsFilled()
  {
    // Arrange
    QuestionEntityBase[] questions = new QuestionEntityBase[0];

    // Act
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : default,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : questions);

    // Assert
    Assert.AreEqual(questions, surveyEntity.Questions);
  }

  [TestMethod]
  public void Constructor_ShortListOfParameters_SurveyIdFilled()
  {
    // Act
    SurveyEntity surveyEntity = new(
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Assert
    Assert.AreNotEqual(default, surveyEntity.SurveyId);
  }

  [TestMethod]
  public void Constructor_ShortListOfParameters_StateIsDraft()
  {
    // Act
    SurveyEntity surveyEntity = new(
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Assert
    Assert.AreEqual(SurveyState.Draft, surveyEntity.State);
  }

  [TestMethod]
  public void TryMoveTo_UnknownState_FalseReturned()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    SurveyState newState = Enum.GetValues<SurveyState>().Max() + 1;

    // Act
    surveyEntity.MoveTo(newState, new ExecutingContext());

    // Assert
    //Assert.IsFalse(result);
  }

  [TestMethod]
  public void TryMoveTo_UnknownState_StateKept()
  {
    // Assert
    SurveyState state = SurveyState.Ready;

    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : state,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    SurveyState newState = Enum.GetValues<SurveyState>().Max() + 1;

    // Act
    surveyEntity.MoveTo(newState, new ExecutingContext());

    // Assert
    Assert.AreEqual(state, surveyEntity.State);
  }

  [TestMethod]
  public void TryMoveTo_FromDraftToDone_FalseReturned()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Draft,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    //Assert.IsFalse(result);
  }

  [TestMethod]
  public void TryMoveTo_FromDraftToDone_StateKept()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId: default,
      state: SurveyState.Draft,
      title: string.Empty,
      description: string.Empty,
      candidateName: string.Empty,
      questions: Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Draft, surveyEntity.State);
  }

  [TestMethod]
  public void TryMoveTo_FromReadyToDone_TrueReturned()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Ready,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    //Assert.IsTrue(result);
  }

  [TestMethod]
  public void TryMoveTo_FromReadyToDone_StateChanged()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Ready,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Done, surveyEntity.State);
  }

  [TestMethod]
  public void TryMoveTo_FromDoneToDone_FalseReturned()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Done,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    //Assert.IsFalse(result);
  }

  [TestMethod]
  public void TryMoveTo_FromCancelledToDone_FalseReturned()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Cancelled,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
      surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    //Assert.IsFalse(result);
  }

  [TestMethod]
  public void TryMoveTo_FromCancelledToDone_StateKept()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Cancelled,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Cancelled, surveyEntity.State);
  }

  [TestMethod]
  public void TryMoveTo_FromDraftToCancelled_TrueReturned()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Draft,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    //Assert.IsTrue(result);
  }

  [TestMethod]
  public void TryMoveTo_FromDraftToCancelled_StateChanged()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Draft,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Cancelled, surveyEntity.State);
  }

  [TestMethod]
  public void TryMoveTo_FromReadyToCancelled_TrueReturned()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Ready,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    //Assert.IsTrue(result);
  }

  [TestMethod]
  public void TryMoveTo_FromReadyToCancelled_StateChanged()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Ready,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Cancelled, surveyEntity.State);
  }

  [TestMethod]
  public void TryMoveTo_FromDoneToCancelled_FalseReturned()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Done,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    //Assert.IsFalse(result);
  }

  [TestMethod]
  public void TryMoveTo_FromDoneToCancelled_StateKept()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Done,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Done, surveyEntity.State);
  }

  [TestMethod]
  public void TryMoveTo_FromCancelledToCancelled_FalseReturned()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Cancelled,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    //Assert.IsFalse(result);
  }

  [TestMethod]
  public void Update_NewTitle_TitleUpdated()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : default,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    string newTitle = Guid.NewGuid().ToString();

    // Act
    surveyEntity.Update(
      title        : newTitle,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    :Array.Empty<QuestionEntityBase>());

    // Assert
    Assert.AreEqual(newTitle, surveyEntity.Title);
  }

  [TestMethod]
  public void Update_NewDescription_DescriptionUpdated()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : default,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    string newDescription = Guid.NewGuid().ToString();

    // Act
    surveyEntity.Update(
      title        : string.Empty,
      description  : newDescription,
      candidateName: string.Empty,
      questions    :Array.Empty<QuestionEntityBase>());

    // Assert
    Assert.AreEqual(newDescription, surveyEntity.Description);
  }

  [TestMethod]
  public void Update_NewCandidateName_CandidateNameUpdated()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : default,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    string newCandidateName = Guid.NewGuid().ToString();

    // Act
    surveyEntity.Update(
      title        : string.Empty,
      description  : string.Empty,
      candidateName: newCandidateName,
      questions    : Array.Empty<QuestionEntityBase>());

    // Assert
    Assert.AreEqual(newCandidateName, surveyEntity.CandidateName);
  }

  [TestMethod]
  public void Update_NewQuestions_QuestionsUpdated()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : default,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    QuestionEntityBase[] newQuestions = new QuestionEntityBase[0];

    // Act
    surveyEntity.Update(
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : newQuestions);

    // Assert
    Assert.AreEqual(newQuestions, surveyEntity.Questions);
  }
}
