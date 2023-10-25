// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Test;

[TestClass]
public sealed class SurveyTemplateEntityTest
{
  [TestMethod]
  public void New_FullListOfParameters_SurveyTemplateIdFilled()
  {
    // Act
    SurveyTemplateEntity? surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : new ExecutingContext()
    );

    // Assert
    Assert.AreNotEqual(default, surveyTemplateEntity!.SurveyTemplateId);
  }

  [TestMethod]
  public void New_FullListOfParameters_TitleFilled()
  {
    // Arrange
    string title = Guid.NewGuid().ToString();

    // Act
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title      : title,
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : new ExecutingContext()
    )!;

    // Assert
    Assert.AreEqual(title, surveyTemplateEntity.Title);
  }

  [TestMethod]
  public void New_FullListOfParameters_DescriptionFilled()
  {
    // Arrange
    string description = Guid.NewGuid().ToString();

    // Act
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: description,
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : new ExecutingContext()
    )!;

    // Assert
    Assert.AreEqual(description, surveyTemplateEntity.Description);
  }

  [TestMethod]
  public void New_FullListOfParameters_QuestionsFilled()
  {
    // Arrange
    QuestionTemplateEntityBase[] questions = new QuestionTemplateEntityBase[0];

    // Act
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : questions,
      context    : new ExecutingContext()
    )!;

    // Assert
    Assert.AreEqual(questions, surveyTemplateEntity.Questions);
  }

  [TestMethod]
  public void New_NoTitle_ErrorsReturned()
  {
    // Arrange
    ExecutingContext context = new();

    // Act
    SurveyTemplateEntity.New
    (
      title      : string.Empty,
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : context
    );

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void New_NoDescription_ErrorsReturned()
  {
    // Arrange
    ExecutingContext context = new();

    // Act
    SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: string.Empty,
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : context
    );

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void New_FullListOfParameters_NoErrors()
  {
    // Arrange
    ExecutingContext context = new();

    // Act
    SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : context
    );

    // Assert
    Assert.IsFalse(context.HasErrors);
  }

  [TestMethod]
  public void New_InvalidQuestion_NullReturned()
  {
    // Arrange
    ExecutingContext context = new();

    // Act
    SurveyTemplateEntity? surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : new QuestionTemplateEntityBase[]
      {
        YesNoQuestionTemplateEntity.New
        (
          text   : string.Empty,
          context: context
        )!,
      },
      context    : context
    );

    // Assert
    Assert.IsNull(surveyTemplateEntity);
  }

  [TestMethod]
  public void New_InvalidQuestion_ContextHasErrors()
  {
    // Arrange
    ExecutingContext context = new();

    // Act
    SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : new QuestionTemplateEntityBase[]
      {
        YesNoQuestionTemplateEntity.New
        (
          text   : string.Empty,
          context: context
        )!,
      },
      context    : context
    );

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_FullListOfParameters_TitleFilled()
  {
    // Arrange
    string title = Guid.NewGuid().ToString();

    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: Guid.NewGuid(),
      title           : Guid.NewGuid().ToString(),
      description     : Guid.NewGuid().ToString(),
      questions       : Array.Empty<QuestionTemplateEntityBase>()
    );

    // Act
    surveyTemplateEntity.Update(
      title      : title,
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : new ExecutingContext());

    // Assert
    Assert.AreEqual(title, surveyTemplateEntity.Title);
  }

  [TestMethod]
  public void Update_FullListOfParameters_DescriptionFilled()
  {
    // Arrange
    string description = Guid.NewGuid().ToString();

    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: Guid.NewGuid(),
      title           : Guid.NewGuid().ToString(),
      description     : Guid.NewGuid().ToString(),
      questions       : Array.Empty<QuestionTemplateEntityBase>()
    );

    // Act
    surveyTemplateEntity.Update(
      title      : Guid.NewGuid().ToString(),
      description: description,
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : new ExecutingContext());

    // Assert
    Assert.AreEqual(description, surveyTemplateEntity.Description);
  }

  [TestMethod]
  public void Update_FullListOfParameters_QuestionsFilled()
  {
    // Arrange
    QuestionTemplateEntityBase[] questions = new QuestionTemplateEntityBase[0];

    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: Guid.NewGuid(),
      title           : Guid.NewGuid().ToString(),
      description     : Guid.NewGuid().ToString(),
      questions       : Array.Empty<QuestionTemplateEntityBase>()
    );

    // Act
    surveyTemplateEntity.Update(
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : questions,
      context    : new ExecutingContext());

    // Assert
    Assert.AreEqual(questions, surveyTemplateEntity.Questions);
  }

  [TestMethod]
  public void Update_NoTitle_ErrorsReturned()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: Guid.NewGuid(),
      title           : Guid.NewGuid().ToString(),
      description     : Guid.NewGuid().ToString(),
      questions       : Array.Empty<QuestionTemplateEntityBase>()
    );

    ExecutingContext context = new();

    // Act
    surveyTemplateEntity.Update
    (
      title      : string.Empty,
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : context
    );

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_NoTitle_EntityNotUpdated()
  {
    // Arrange
    SurveyTemplateEntity expectedSurveyTemplateEntity = new
    (
      surveyTemplateId: Guid.NewGuid(),
      title           : Guid.NewGuid().ToString(),
      description     : Guid.NewGuid().ToString(),
      questions       : Array.Empty<QuestionTemplateEntityBase>()
    );

    SurveyTemplateEntity surveyTemplateEntity = new(expectedSurveyTemplateEntity);

    ExecutingContext context = new();

    // Act
    surveyTemplateEntity.Update
    (
      title      : string.Empty,
      description: Guid.NewGuid().ToString(),
      questions  : new QuestionTemplateEntityBase[0],
      context    : context
    );

    // Assert
    Assert.AreEqual(expectedSurveyTemplateEntity, surveyTemplateEntity);
  }

  [TestMethod]
  public void Update_NoDescription_ErrorsReturned()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: Guid.NewGuid(),
      title           : Guid.NewGuid().ToString(),
      description     : Guid.NewGuid().ToString(),
      questions       : Array.Empty<QuestionTemplateEntityBase>()
    );

    ExecutingContext context = new();

    // Act
    surveyTemplateEntity.Update
    (
      title      : Guid.NewGuid().ToString(),
      description: string.Empty,
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : context
    );

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Update_NoDescription_EntityNotUpdated()
  {
    // Arrange
    SurveyTemplateEntity expectedSurveyTemplateEntity = new
    (
      surveyTemplateId: Guid.NewGuid(),
      title           : Guid.NewGuid().ToString(),
      description     : Guid.NewGuid().ToString(),
      questions       : new QuestionTemplateEntityBase[0]
    );

    SurveyTemplateEntity surveyTemplateEntity = new(expectedSurveyTemplateEntity);

    ExecutingContext context = new();

    // Act
    surveyTemplateEntity.Update
    (
      title      : Guid.NewGuid().ToString(), 
      description: string.Empty,
      questions  : new QuestionTemplateEntityBase[0],
      context    : context
    );

    // Assert
    Assert.AreEqual(expectedSurveyTemplateEntity, surveyTemplateEntity);
  }

  [TestMethod]
  public void Update_FullListOfParameters_NoError()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: Guid.NewGuid(),
      title           : Guid.NewGuid().ToString(),
      description     : Guid.NewGuid().ToString(),
      questions       : Array.Empty<QuestionTemplateEntityBase>()
    );

    ExecutingContext context = new();

    // Act
    surveyTemplateEntity.Update
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : context
    );

    // Assert
    Assert.IsFalse(context.HasErrors);
  }
}
