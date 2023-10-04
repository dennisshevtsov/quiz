// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Test;

[TestClass]
public sealed class YesNoQuestionTemplateEntityTest
{
  [TestMethod]
  public void Constructor_Text_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();

    // Act
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = YesNoQuestionTemplateEntity.New
    (
      text   : text,
      context: new ExecutingContext()
    )!;

    // Assert
    Assert.AreEqual(text, yesNoQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void Constructor_Text_QuestionTypeIsYesNo()
  {
    // Act
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = YesNoQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    )!;

    // Assert
    Assert.AreEqual(QuestionType.YesNo, yesNoQuestionTemplateEntity.QuestionType);
  }

  [TestMethod]
  public void Constructor_YesNoQuestionTemplateEntity_TextFilled()
  {
    // Arrange
    YesNoQuestionTemplateEntity originalYesNoQuestionTemplateEntity = YesNoQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    )!;

    // Act
    YesNoQuestionTemplateEntity newYesNoQuestionTemplateEntity = new(originalYesNoQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(originalYesNoQuestionTemplateEntity.Text, newYesNoQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void Constructor_YesNoQuestionTemplateEntity_QuestionTypeIsYesNo()
  {
    // Arrange
    YesNoQuestionTemplateEntity originalYesNoQuestionTemplateEntity = YesNoQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    )!;

    // Act
    YesNoQuestionTemplateEntity newYesNoQuestionTemplateEntity = new(originalYesNoQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(QuestionType.YesNo, newYesNoQuestionTemplateEntity.QuestionType);
  }
}
