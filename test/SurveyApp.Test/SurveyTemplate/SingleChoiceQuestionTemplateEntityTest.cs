// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Test;

[TestClass]
public sealed class SingleChoiceQuestionTemplateEntityTest
{
  [TestMethod]
  public void New_FullListOfParameters_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();

    // Act
    SingleChoiceQuestionTemplateEntity? singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : text,
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    );

    // Assert
    Assert.AreEqual(text, singleChoiceQuestionTemplateEntity!.Text);
  }

  [TestMethod]
  public void New_FullListOfParameters_ChoicesFilled()
  {
    // Arrange
    string[] choices = new[]
    {
      Guid.NewGuid().ToString(),
      Guid.NewGuid().ToString(),
      Guid.NewGuid().ToString(),
    };

    // Act
    SingleChoiceQuestionTemplateEntity? singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: choices,
      context: new ExecutingContext()
    );

    // Assert
    Assert.AreEqual(choices, singleChoiceQuestionTemplateEntity!.Choices);
  }

  [TestMethod]
  public void New_FullListOfParameters_QuestionTypeIsSingleChoice()
  {
    // Act
    SingleChoiceQuestionTemplateEntity? singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    );

    // Assert
    Assert.AreEqual(QuestionType.SingleChoice, singleChoiceQuestionTemplateEntity!.QuestionType);
  }

  [TestMethod]
  public void New_NoText_NullReturned()
  {
    // Act
    SingleChoiceQuestionTemplateEntity? singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : string.Empty,
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    );

    // Assert
    Assert.IsNull(singleChoiceQuestionTemplateEntity);
  }

  [TestMethod]
  public void New_NoText_ContextHasError()
  {
    // Arrange
    ExecutingContext context = new();

    // Act
    SingleChoiceQuestionTemplateEntity? singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : string.Empty,
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: context
    );

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void New_NoChoices_NullReturned()
  {
    // Act
    SingleChoiceQuestionTemplateEntity? singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : string.Empty,
      choices: Array.Empty<string>(),
      context: new ExecutingContext()
    );

    // Assert
    Assert.IsNull(singleChoiceQuestionTemplateEntity);
  }

  [TestMethod]
  public void New_NoChoices_ContextHasError()
  {
    // Arrange
    ExecutingContext context = new();

    // Act
    SingleChoiceQuestionTemplateEntity? singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : string.Empty,
      choices: Array.Empty<string>(),
      context: context
    );

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void New_EmptyChoice_NullReturned()
  {
    // Act
    SingleChoiceQuestionTemplateEntity? singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : string.Empty,
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        string.Empty,
      },
      context: new ExecutingContext()
    );

    // Assert
    Assert.IsNull(singleChoiceQuestionTemplateEntity);
  }

  [TestMethod]
  public void New_EmptyChoice_ContextHasError()
  {
    // Arrange
    ExecutingContext context = new();

    // Act
    SingleChoiceQuestionTemplateEntity? singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : string.Empty,
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        string.Empty,
      },
      context: context
    );

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Constructor_SingleChoiceQuestionTemplateEntity_TextFilled()
  {
    // Arrange
    SingleChoiceQuestionTemplateEntity originalSingleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    )!;

    // Act
    SingleChoiceQuestionTemplateEntity newSingleChoiceQuestionTemplateEntity = new(originalSingleChoiceQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(originalSingleChoiceQuestionTemplateEntity.Text, newSingleChoiceQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void Constructor_SingleChoiceQuestionTemplateEntity_ChoicesFilled()
  {
    // Arrange
    SingleChoiceQuestionTemplateEntity originalSingleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    )!;

    // Act
    SingleChoiceQuestionTemplateEntity newSingleChoiceQuestionTemplateEntity = new(originalSingleChoiceQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(originalSingleChoiceQuestionTemplateEntity.Choices, newSingleChoiceQuestionTemplateEntity.Choices);
  }

  [TestMethod]
  public void Constructor_SingleChoiceQuestionTemplateEntity_QuestionTypeIsMultipleChoice()
  {
    // Arrange
    SingleChoiceQuestionTemplateEntity originalSingleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    )!;

    // Act
    SingleChoiceQuestionTemplateEntity newSingleChoiceQuestionTemplateEntity = new(originalSingleChoiceQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(QuestionType.SingleChoice, newSingleChoiceQuestionTemplateEntity.QuestionType);
  }
}
