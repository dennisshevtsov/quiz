// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;
using System.Reflection;

namespace SurveyApp.Survey.Test;

[TestClass]
public sealed class SurveyEntityTest
{
  [TestMethod]
  public void New_IntervieweeName_SurveyEntityCreated()
  {
    // Assert
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : new ExecutingContext()
    )!;

    ExecutingContext context = new();

    // Act
    SurveyEntity? surveyEntity = SurveyEntity.New
    (
      intervieweeName: Guid.NewGuid().ToString(),
      template       : surveyTemplateEntity,
      context        : context
    );

    // Assert
    Assert.IsNotNull(surveyEntity);
  }

  [TestMethod]
  public void New_IntervieweeName_ContextHasNoErrors()
  {
    // Assert
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : new ExecutingContext()
    )!;

    ExecutingContext context = new();

    // Act
    SurveyEntity.New
    (
      intervieweeName: Guid.NewGuid().ToString(),
      template       : surveyTemplateEntity,
      context        : context
    );

    // Assert
    Assert.IsFalse(context.HasErrors);
  }

  [TestMethod]
  public void New_NoIntervieweeName_ContextHasErrors()
  {
    // Assert
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : new ExecutingContext()
    )!;

    ExecutingContext context = new();

    // Act
    SurveyEntity.New
    (
      intervieweeName: string.Empty,
      template       : surveyTemplateEntity,
      context        : context
    );

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void MoveTo_UnknownState_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Draft,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

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

    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : state,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Draft,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Draft,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Draft, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromReadyToDone_ContextHasNoErrors()
  {
    // Assert
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Ready,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Ready,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Done, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromDoneToDone_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Done,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Cancelled,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Cancelled,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Done, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Cancelled, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromDraftToCancelled_ContextHasNoErrors()
  {
    // Assert
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Draft,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Draft,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Cancelled, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromReadyToCancelled_ContextHasNoErrors()
  {
    // Assert
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Ready,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Ready,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Cancelled, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromDoneToCancelled_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Done,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

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
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Done,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, new ExecutingContext());

    // Assert
    Assert.AreEqual(SurveyState.Done, surveyEntity.State);
  }

  [TestMethod]
  public void MoveTo_FromCancelledToCancelled_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Cancelled,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.MoveTo(SurveyState.Cancelled, context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_NewIntervieweeName_IntervieweeNameUpdated()
  {
    // Assert
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : default,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

    string newInervieweeName = Guid.NewGuid().ToString();

    // Act
    surveyEntity.Update(newInervieweeName, new ExecutingContext());

    // Assert
    Assert.AreEqual(newInervieweeName, surveyEntity.IntervieweeName);
  }

  [TestMethod]
  public void Update_NoIntervieweeName_CandidateNameNotUpdated()
  {
    // Assert
    string originalIntervieweeName = Guid.NewGuid().ToString();

    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : default,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: originalIntervieweeName,
      questions      : Array.Empty<QuestionEntityBase>());

    // Act
    surveyEntity.Update(string.Empty, new ExecutingContext());

    // Assert
    Assert.AreEqual(originalIntervieweeName, surveyEntity.IntervieweeName);
  }

  [TestMethod]
  public void Update_NoIntervieweeName_ContextHasErrors()
  {
    // Assert
    string originalIntervieweeName = Guid.NewGuid().ToString();

    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : default,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: originalIntervieweeName,
      questions      : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.Update(string.Empty, context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_StateIsReady_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Ready,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.Update(Guid.NewGuid().ToString(), context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_StateIsDone_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Done,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.Update(Guid.NewGuid().ToString(), context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_StateIsCancelled_ContextHasErrors()
  {
    // Assert
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : default,
      state          : SurveyState.Cancelled,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.Update(Guid.NewGuid().ToString(), context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_StateIsDraft_ContextHasNoErrors()
  {
    // Assert
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey(
      surveyId       : default,
      state          : SurveyState.Draft,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>());

    ExecutingContext context = new();

    // Act
    surveyEntity.Update(Guid.NewGuid().ToString(), context);

    // Assert
    Assert.IsFalse(context.HasErrors);
  }

  [TestMethod]
  public void Answer_ContextWithErrors_StateNotUpdated()
  {
    // Assert
    SurveyState originalState = SurveyState.Ready;
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey
    (
      surveyId       : default,
      state          : originalState,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>()
    );

    ExecutingContext context = new();
    context.AddError(Guid.NewGuid().ToString());

    // Act
    surveyEntity.Answer(context);

    // Assert
    Assert.AreEqual(originalState, surveyEntity.State);
  }

  [TestMethod]
  public void Answer_DraftSurvey_StateNotUpdated()
  {
    // Assert
    SurveyState originalState = SurveyState.Draft;
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey
    (
      surveyId       : default,
      state          : originalState,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>()
    );

    ExecutingContext context = new();

    // Act
    surveyEntity.Answer(context);

    // Assert
    Assert.AreEqual(originalState, surveyEntity.State);
  }

  [TestMethod]
  public void Answer_DraftSurvey_ContextHasErrors()
  {
    // Assert
    SurveyState originalState = SurveyState.Draft;
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey
    (
      surveyId       : default,
      state          : originalState,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>()
    );

    ExecutingContext context = new();

    // Act
    surveyEntity.Answer(context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Answer_CancelledSurvey_StateNotUpdated()
  {
    // Assert
    SurveyState originalState = SurveyState.Cancelled;
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey
    (
      surveyId       : default,
      state          : originalState,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>()
    );

    ExecutingContext context = new();

    // Act
    surveyEntity.Answer(context);

    // Assert
    Assert.AreEqual(originalState, surveyEntity.State);
  }

  [TestMethod]
  public void Answer_CancelledSurvey_ContextHasErrors()
  {
    // Assert
    SurveyState originalState = SurveyState.Cancelled;
    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey
    (
      surveyId       : default,
      state          : originalState,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>()
    );

    ExecutingContext context = new();

    // Act
    surveyEntity.Answer(context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  private static ConstructorInfo? _surveyEntityConstructor;

  private static ConstructorInfo SurveyEntityConstructor => _surveyEntityConstructor ?? (_surveyEntityConstructor = GetSurveyEntityConstructor());

  private static ConstructorInfo GetSurveyEntityConstructor()
  {
    Type[] constructorParameterTypes = new[]
    {
      typeof(Guid),
      typeof(SurveyState),
      typeof(string),
      typeof(string),
      typeof(string),
      typeof(QuestionEntityBase[])
    };

    ConstructorInfo? constructorInfo = typeof(SurveyEntity).GetConstructor
    (
      bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic,
      types: constructorParameterTypes
    );

    return constructorInfo ?? throw new Exception("No proper constructor.");
  }

  public static SurveyEntity CreateTestSurvey(
    Guid surveyId = default,
    SurveyState state = default,
    string title = "",
    string description = "",
    string intervieweeName = "",
    QuestionEntityBase[] questions = null!)
  {
    object[] parameters = new object[]
    {
      surveyId,
      state,
      title,
      description,
      intervieweeName,
      questions ?? Array.Empty<QuestionEntityBase>(),
    };

    object newInstance = SurveyEntityTest.SurveyEntityConstructor.Invoke(parameters);

    if (newInstance != null && newInstance is SurveyEntity surveyEntity)
    {
      return surveyEntity;
    }

    throw new AssertFailedException("An error occured while creating an survey entity.");
  }
}
