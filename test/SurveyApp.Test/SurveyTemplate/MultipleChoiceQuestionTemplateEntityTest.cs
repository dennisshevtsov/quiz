// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Test;

[TestClass]
public sealed class MultipleChoiceQuestionTemplateEntityTest
{
  [TestMethod]
  public void Constructor_FullListOfParameters_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();

    // Act
    MultipleChoiceQuestionTemplateEntity? multipleChoiceQuestionTemplateEntity = MultipleChoiceQuestionTemplateEntity.New
    (
      text   : text,
      choices: Array.Empty<string>(),
      context: new ExecutingContext()
    );

    // Assert
    Assert.AreEqual(text, multipleChoiceQuestionTemplateEntity!.Text);
  }

  [TestMethod]
  public void Constructor_FullListOfParameters_ChoicesFilled()
  {
    // Arrange
    string[] choices = new[]
    {
      Guid.NewGuid().ToString(),
      Guid.NewGuid().ToString(),
      Guid.NewGuid().ToString(),
    };

    // Act
    MultipleChoiceQuestionTemplateEntity? multipleChoiceQuestionTemplateEntity = MultipleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: choices,
      context: new ExecutingContext()
    );

    // Assert
    Assert.AreEqual(choices, multipleChoiceQuestionTemplateEntity!.Choices);
  }

  [TestMethod]
  public void Constructor_FullListOfParameters_QuestionTypeIsMultipleChoice()
  {
    // Act
    MultipleChoiceQuestionTemplateEntity? multipleChoiceQuestionTemplateEntity = MultipleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: Array.Empty<string>(),
      context: new ExecutingContext()
    );

    // Assert
    Assert.AreEqual(QuestionType.MultipleChoice, multipleChoiceQuestionTemplateEntity!.QuestionType);
  }

  [TestMethod]
  public void Constructor_MultipleChoiceQuestionTemplateEntity_TextFilled()
  {
    // Arrange
    MultipleChoiceQuestionTemplateEntity? originalMultipleChoiceQuestionTemplateEntity = MultipleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: Array.Empty<string>(),
      context: new ExecutingContext()
    );

    // Act
    MultipleChoiceQuestionTemplateEntity newMultipleChoiceQuestionTemplateEntity = new(originalMultipleChoiceQuestionTemplateEntity!);

    // Assert
    Assert.AreEqual(originalMultipleChoiceQuestionTemplateEntity!.Text, newMultipleChoiceQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void Constructor_MultipleChoiceQuestionTemplateEntity_ChoicesFilled()
  {
    // Arrange
    MultipleChoiceQuestionTemplateEntity? originalMultipleChoiceQuestionTemplateEntity = MultipleChoiceQuestionTemplateEntity.New
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

    // Act
    MultipleChoiceQuestionTemplateEntity newMultipleChoiceQuestionTemplateEntity = new(originalMultipleChoiceQuestionTemplateEntity!);

    // Assert
    Assert.AreEqual(originalMultipleChoiceQuestionTemplateEntity!.Choices, newMultipleChoiceQuestionTemplateEntity.Choices);
  }

  [TestMethod]
  public void Constructor_MultipleChoiceQuestionTemplateEntity_QuestionTypeIsMultipleChoice()
  {
    // Arrange
    MultipleChoiceQuestionTemplateEntity? originalMultipleChoiceQuestionTemplateEntity = MultipleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: Array.Empty<string>(),
      context: new ExecutingContext()
    );

    // Act
    MultipleChoiceQuestionTemplateEntity newMultipleChoiceQuestionTemplateEntity = new(originalMultipleChoiceQuestionTemplateEntity!);

    // Assert
    Assert.AreEqual(QuestionType.MultipleChoice, newMultipleChoiceQuestionTemplateEntity.QuestionType);
  }
}
