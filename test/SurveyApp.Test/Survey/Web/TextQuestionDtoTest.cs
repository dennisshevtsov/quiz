// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class TextQuestionDtoTest
{
  [TestMethod]
  public void Constructor_TextQuestionEntity_TextFilled()
  {
    // Arrange
    TextQuestionEntity textQuestionEntity = new
    (
      text: Guid.NewGuid().ToString(),
      answer: null
    );

    // Act
    TextQuestionDto textQuestionDto = new(textQuestionEntity);

    // Assert
    Assert.AreEqual(textQuestionEntity.Text, textQuestionDto.Text);
  }

  [TestMethod]
  public void ToQuestionEntity_TextQuestionDto_TextQuestionEntityReturned()
  {
    // Arrange
    TextQuestionDto TextQuestionDto = new()
    {
      Text = Guid.NewGuid().ToString(),
    };

    // Act
    QuestionEntityBase questionEntity = TextQuestionDto.ToQuestionEntity();

    // Assert
    Assert.IsInstanceOfType<TextQuestionEntity>(questionEntity);
  }

  [TestMethod]
  public void ToQuestionEntity_TextQuestionDto_TextFilled()
  {
    // Arrange
    TextQuestionDto textQuestionDto = new()
    {
      Text = Guid.NewGuid().ToString(),
    };

    // Act
    QuestionEntityBase questionEntity = textQuestionDto.ToQuestionEntity();

    // Assert
    Assert.AreEqual(textQuestionDto.Text, questionEntity.Text);
  }
}
