// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class TextQuestionTemplateDtoTest
{
  [TestMethod]
  public void ToQuestionTemplateEntity_TextQuestionTemplateDto_TextQuestionTemplateEntityReturned()
  {
    // Arrange
    TextQuestionTemplateDto textQuestionTemplateDto = new();

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = textQuestionTemplateDto.ToTemplateQuestionEntity();

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(TextQuestionTemplateEntity));
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_TextQuestionTemplateDto_PropertiesFilled()
  {
    // Arrange
    TextQuestionTemplateDto textQuestionTemplateDto = new()
    {
      QuestionType = QuestionType.Text,
      Text = "test",
    };

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = textQuestionTemplateDto.ToTemplateQuestionEntity();

    // Assert
    Assert.AreEqual(textQuestionTemplateDto.Text, questionTemplateEntityBase.Text);
  }
}
