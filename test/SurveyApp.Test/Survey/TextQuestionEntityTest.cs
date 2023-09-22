// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey.Test;

[TestClass]
public sealed class TextQuestionEntityTest
{
  [TestMethod]
  public void Constructor_Text_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();

    // Act
    TextQuestionEntity textQuestionEntity = new
    (
      text  : text,
      answer: default
    );

    // Assert
    Assert.AreEqual(text, textQuestionEntity.Text);
  }

  [TestMethod]
  public void Constructor_Answer_AnswerFilled()
  {
    // Arrange
    string answer = Guid.NewGuid().ToString();

    // Act
    TextQuestionEntity textQuestionEntity = new
    (
      text  : string.Empty,
      answer: answer
    );

    // Assert
    Assert.AreEqual(answer, textQuestionEntity.Answer);
  }

  [TestMethod]
  public void Constructor_TextQuestionTemplateEntity_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();
    TextQuestionTemplateEntity textQuestionTemplateEntity = new(text);

    // Act
    TextQuestionEntity textQuestionEntity = new(textQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(text, textQuestionEntity.Text);
  }

  [TestMethod]
  public void Constructor_TextQuestionTemplateEntity_AnswerIsNull()
  {
    // Arrange
    TextQuestionTemplateEntity textQuestionTemplateEntity = new(text: Guid.NewGuid().ToString());

    // Act
    TextQuestionEntity textQuestionEntity = new(textQuestionTemplateEntity);

    // Assert
    Assert.IsNull(textQuestionEntity.Answer);
  }

  [TestMethod]
  public void SetAnswer_Answer_AnswerUpdated()
  {
    // Arrange
    TextQuestionEntity textQuestionEntity = new
    (
      text  : Guid.NewGuid().ToString(),
      answer: null
    );

    string answer = Guid.NewGuid().ToString();

    // Act
    textQuestionEntity.SetAnswer(answer);

    // Assert
    Assert.AreEqual(answer, textQuestionEntity.Answer);
  }
}
