// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

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
}
