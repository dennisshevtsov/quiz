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
    SurveyTemplateQuestionEntityBase questionTemplateEntityBase = textQuestionTemplateDto.ToSurveyTemplateQuestionEntity();

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(TextSurveyTemplateQuestionEntity));
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_TextQuestionTemplateDto_PropertiesFilled()
  {
    // Arrange
    TextQuestionTemplateDto textQuestionTemplateDto = new()
    {
      QuestionType = SurveyQuestionType.Text,
      Text = "test",
    };

    // Act
    SurveyTemplateQuestionEntityBase questionTemplateEntityBase = textQuestionTemplateDto.ToSurveyTemplateQuestionEntity();

    // Assert
    Assert.AreEqual(textQuestionTemplateDto.Text, questionTemplateEntityBase.Text);
  }
}
