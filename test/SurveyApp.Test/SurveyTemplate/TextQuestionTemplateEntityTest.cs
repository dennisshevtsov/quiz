// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Test;

[TestClass]
public sealed class TextQuestionTemplateEntityTest
{
  [TestMethod]
  public void New_Text_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();

    // Act
    TextQuestionTemplateEntity? textQuestionTemplateEntity = TextQuestionTemplateEntity.New
    (
      text   : text,
      context: new ExecutingContext()
    );

    // Assert
    Assert.AreEqual(text, textQuestionTemplateEntity!.Text);
  }

  [TestMethod]
  public void New_Text_QuestionTypeIsText()
  {
    // Act
    TextQuestionTemplateEntity? textQuestionTemplateEntity = TextQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    );

    // Assert
    Assert.AreEqual(QuestionType.Text, textQuestionTemplateEntity!.QuestionType);
  }

  [TestMethod]
  public void New_NoText_NullReturned()
  {
    // Act
    TextQuestionTemplateEntity? textQuestionTemplateEntity = TextQuestionTemplateEntity.New
    (
      text   : string.Empty,
      context: new ExecutingContext()
    );

    // Assert
    Assert.IsNull(textQuestionTemplateEntity);
  }

  [TestMethod]
  public void New_NoText_ContextHasErrors()
  {
    // Arrange
    ExecutingContext context = new();

    // Act
    TextQuestionTemplateEntity? textQuestionTemplateEntity = TextQuestionTemplateEntity.New
    (
      text   : string.Empty,
      context: context
    );

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void Constructor_TextQuestionTemplateEntity_TextFilled()
  {
    // Arrange
    TextQuestionTemplateEntity? originalTextQuestionTemplateEntity = TextQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    );

    // Act
    TextQuestionTemplateEntity newTextQuestionTemplateEntity = new(originalTextQuestionTemplateEntity!);

    // Assert
    Assert.AreEqual(originalTextQuestionTemplateEntity!.Text, newTextQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void Constructor_TextQuestionTemplateEntity_QuestionTypeIsText()
  {
    // Arrange
    TextQuestionTemplateEntity? originalTextQuestionTemplateEntity = TextQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    );

    // Act
    TextQuestionTemplateEntity newTextQuestionTemplateEntity = new(originalTextQuestionTemplateEntity!);

    // Assert
    Assert.AreEqual(QuestionType.Text, newTextQuestionTemplateEntity.QuestionType);
  }
}
