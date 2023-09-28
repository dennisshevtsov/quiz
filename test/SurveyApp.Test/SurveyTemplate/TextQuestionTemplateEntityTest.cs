// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Test;

[TestClass]
public sealed class TextQuestionTemplateEntityTest
{
  [TestMethod]
  public void Constructor_Text_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();

    // Act
    TextQuestionTemplateEntity textQuestionTemplateEntity = new
    (
      text: text
    );

    // Assert
    Assert.AreEqual(text, textQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void Constructor_Text_QuestionTypeIsText()
  {
    // Act
    TextQuestionTemplateEntity textQuestionTemplateEntity = new
    (
      text: Guid.NewGuid().ToString()
    );

    // Assert
    Assert.AreEqual(QuestionType.Text, textQuestionTemplateEntity.QuestionType);
  }
}
