// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using static System.Net.Mime.MediaTypeNames;

namespace SurveyApp.SurveyTemplate.Test;

[TestClass]
public sealed class MultipleChoiceQuestionTemplateEntityTest
{
  [TestMethod]
  public void Constructor_Text_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();

    // Act
    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = new
    (
      text   : text,
      choices: Array.Empty<string>()
    );

    // Assert
    Assert.AreEqual(text, multipleChoiceQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void Constructor_Choices_ChoicesFilled()
  {
    // Arrange
    string[] choices = new[]
    {
      Guid.NewGuid().ToString(),
      Guid.NewGuid().ToString(),
      Guid.NewGuid().ToString(),
    };

    // Act
    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: choices
    );

    // Assert
    Assert.AreEqual(choices, multipleChoiceQuestionTemplateEntity.Choices);
  }

  [TestMethod]
  public void Constructor_FullListOfParameters_QuestionTypeIsMultipleChoice()
  {
    // Act
    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: Array.Empty<string>()
    );

    // Assert
    Assert.AreEqual(QuestionType.MultipleChoice, multipleChoiceQuestionTemplateEntity.QuestionType);
  }

  [TestMethod]
  public void Constructor_MultipleChoiceQuestionTemplateEntity_TextFilled()
  {
    // Arrange
    MultipleChoiceQuestionTemplateEntity originalMultipleChoiceQuestionTemplateEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: Array.Empty<string>()
    );

    // Act
    MultipleChoiceQuestionTemplateEntity newMultipleChoiceQuestionTemplateEntity = new(originalMultipleChoiceQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(originalMultipleChoiceQuestionTemplateEntity.Text, newMultipleChoiceQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void Constructor_MultipleChoiceQuestionTemplateEntity_ChoicesFilled()
  {
    // Arrange
    MultipleChoiceQuestionTemplateEntity originalMultipleChoiceQuestionTemplateEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      }
    );

    // Act
    MultipleChoiceQuestionTemplateEntity newMultipleChoiceQuestionTemplateEntity = new(originalMultipleChoiceQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(originalMultipleChoiceQuestionTemplateEntity.Choices, newMultipleChoiceQuestionTemplateEntity.Choices);
  }
}
