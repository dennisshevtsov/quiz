// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Test;

[TestClass]
public sealed class SurveyEntityTest
{
  [TestMethod]
  public void MoveTo_UnknownState_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = null!;//new(
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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

    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : state,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Draft,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Draft,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Draft, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromReadyToDone_ContextHasNoErrors()
  {
    // Assert
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Ready,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;//new(
      //surveyId     : default,
      //state        : SurveyState.Ready,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Done, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromDoneToDone_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Done,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Cancelled,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Cancelled,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Cancelled, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromDraftToCancelled_ContextHasNoErrors()
  {
    // Assert
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Draft,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Draft,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Cancelled, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromReadyToCancelled_ContextHasNoErrors()
  {
    // Assert
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Ready,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Ready,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Cancelled, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromDoneToCancelled_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Done,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Done,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Done, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromCancelledToCancelled_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = null!;//new(
      //surveyId     : default,
      //state        : SurveyState.Cancelled,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : default,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : default,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : default,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : default,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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

    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : default,
      //title        : originalTitle,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : default,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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

    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : default,
      //title        : string.Empty,
      //description  : originalDescription,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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

    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : default,
      //title        : string.Empty,
      //description  : originalDescription,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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

    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : default,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: originalCandidateName,
      //questions    : Array.Empty<QuestionEntityBase>());

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

    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : default,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: originalCandidateName,
      //questions    : Array.Empty<QuestionEntityBase>());

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
  public void Update_StateIsReady_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Ready,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
  public void Update_StateIsDone_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Done,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
  public void Update_StateIsCancelled_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Cancelled,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

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
  public void Update_StateIsDraft_ContextHasNoErrors()
  {
    // Assert
    SurveyEntity surveyEntity = null!;// new(
      //surveyId     : default,
      //state        : SurveyState.Draft,
      //title        : string.Empty,
      //description  : string.Empty,
      //candidateName: string.Empty,
      //questions    : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.Update(
      title        : Guid.NewGuid().ToString(),
      description  : Guid.NewGuid().ToString(),
      candidateName: Guid.NewGuid().ToString(),
      questions    : Array.Empty<QuestionEntityBase>(),
      context      : context);

    // Assert
    Assert.IsFalse(context.HasErrors);
  }
}
