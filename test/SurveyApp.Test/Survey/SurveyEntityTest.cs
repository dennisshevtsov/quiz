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
  public void MoveTo_UnknownState_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    SurveyState newState = Enum.GetValues<SurveyState>().Max() + 1;

    ExecutingContext context = new();

    // Act
    surveyEntity.MoveTo(newState, context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void MoveTo_UnknownState_StateNotChanged()
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
  public void MoveTo_FromDraftToDone_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Draft,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.MoveTo(SurveyState.Done, context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void MoveTo_FromDraftToDone_StateNotChanged()
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
    Assert.AreEqual(SurveyState.Draft, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromReadyToDone_ContextHasNoErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Ready,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.MoveTo(SurveyState.Done, context);

    // Assert
    Assert.IsFalse(context.HasErrors);
  }

  [TestMethod]
  public void MoveTo_FromReadyToDone_StateChanged()
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
  public void MoveTo_FromDoneToDone_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Done,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.MoveTo(SurveyState.Done, context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void MoveTo_FromCancelledToDone_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Cancelled,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.MoveTo(SurveyState.Done, context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void MoveTo_FromCancelledToDone_StateNotChanged()
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
  public void MoveTo_FromDraftToCancelled_ContextHasNoErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Draft,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, context);

    // Assert
    Assert.IsFalse(context.HasErrors);
  }

  [TestMethod]
  public void MoveTo_FromDraftToCancelled_StateChanged()
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
  public void MoveTo_FromReadyToCancelled_ContextHasNoErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Ready,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, context);

    // Assert
    Assert.IsFalse(context.HasErrors);
  }

  [TestMethod]
  public void MoveTo_FromReadyToCancelled_StateChanged()
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
  public void MoveTo_FromDoneToCancelled_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Done,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void MoveTo_FromDoneToCancelled_StateNotChanged()
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
  public void MoveTo_FromCancelledToCancelled_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Cancelled,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, context);

    // Assert
    Assert.IsTrue(context.HasErrors);
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
      description  : Guid.NewGuid().ToString(),
      candidateName: Guid.NewGuid().ToString(),
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : new ExecutingContext());

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
      title        : Guid.NewGuid().ToString(),
      description  : newDescription,
      candidateName: Guid.NewGuid().ToString(),
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : new ExecutingContext());

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
      title        : Guid.NewGuid().ToString(),
      description  : Guid.NewGuid().ToString(),
      candidateName: newCandidateName,
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : new ExecutingContext());

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
      title        : Guid.NewGuid().ToString(),
      description  : Guid.NewGuid().ToString(),
      candidateName: Guid.NewGuid().ToString(),
      questions    : newQuestions,
      context      : new ExecutingContext());

    // Assert
    Assert.AreEqual(newQuestions, surveyEntity.Questions);
  }

  [TestMethod]
  public void Update_NoTitle_TitleNotUpdated()
  {
    // Assert
    string originalTitle = Guid.NewGuid().ToString();

    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : default,
      title        : originalTitle,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.Update(
      title        : string.Empty,
      description  : Guid.NewGuid().ToString(),
      candidateName: Guid.NewGuid().ToString(),
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : new ExecutingContext());

    // Assert
    Assert.AreEqual(originalTitle, surveyEntity.Title);
  }

  [TestMethod]
  public void Update_NoTitle_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : default,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.Update(
      title        : string.Empty,
      description  : Guid.NewGuid().ToString(),
      candidateName: Guid.NewGuid().ToString(),
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_NoDescription_DescriptionNotUpdated()
  {
    // Assert
    string originalDescription = Guid.NewGuid().ToString();

    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : default,
      title        : string.Empty,
      description  : originalDescription,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.Update(
      title        : Guid.NewGuid().ToString(),
      description  : string.Empty,
      candidateName: Guid.NewGuid().ToString(),
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : new ExecutingContext());

    // Assert
    Assert.AreEqual(originalDescription, surveyEntity.Description);
  }

  [TestMethod]
  public void Update_NoDescription_ContextHasErrors()
  {
    // Assert
    string originalDescription = Guid.NewGuid().ToString();

    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : default,
      title        : string.Empty,
      description  : originalDescription,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.Update(
      title        : Guid.NewGuid().ToString(),
      description  : string.Empty,
      candidateName: Guid.NewGuid().ToString(),
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_NoCandidateName_CandidateNameNotUpdated()
  {
    // Assert
    string originalCandidateName = Guid.NewGuid().ToString();

    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : default,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: originalCandidateName,
      questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.Update(
      title        : Guid.NewGuid().ToString(),
      description  : Guid.NewGuid().ToString(),
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : new ExecutingContext());

    // Assert
    Assert.AreEqual(originalCandidateName, surveyEntity.CandidateName);
  }

  [TestMethod]
  public void Update_NoCandidateName_ContextHasErrors()
  {
    // Assert
    string originalCandidateName = Guid.NewGuid().ToString();

    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : default,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: originalCandidateName,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.Update(
      title        : Guid.NewGuid().ToString(),
      description  : Guid.NewGuid().ToString(),
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_SateIsReady_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Ready,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.Update(
      title        : Guid.NewGuid().ToString(),
      description  : Guid.NewGuid().ToString(),
      candidateName: Guid.NewGuid().ToString(),
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_SateIsDone_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Done,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.Update(
      title        : Guid.NewGuid().ToString(),
      description  : Guid.NewGuid().ToString(),
      candidateName: Guid.NewGuid().ToString(),
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_SateIsCancelled_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = new(
      surveyId     : default,
      state        : SurveyState.Cancelled,
      title        : string.Empty,
      description  : string.Empty,
      candidateName: string.Empty,
      questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.Update(
      title        : Guid.NewGuid().ToString(),
      description  : Guid.NewGuid().ToString(),
      candidateName: Guid.NewGuid().ToString(),
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }
}
