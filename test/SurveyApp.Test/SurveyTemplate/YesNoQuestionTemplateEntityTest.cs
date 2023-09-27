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
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = new
    (
      text: text
    );

    // Assert
    Assert.AreEqual(text, yesNoQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void Constructor_Text_QuestionTypeIsYesNo()
  {
    // Act
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = new
    (
      text: Guid.NewGuid().ToString()
    );

    // Assert
    Assert.AreEqual(QuestionType.YesNo, yesNoQuestionTemplateEntity.QuestionType);
  }
}
