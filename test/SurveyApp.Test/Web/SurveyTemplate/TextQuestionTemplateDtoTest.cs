// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyQuestion;
using SurveyApp.Web.SurveyQuestion;

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
    SurveyQuestionEntityBase questionTemplateEntityBase = textQuestionTemplateDto.ToQuestionTemplateEntity();

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(TextQuestionEntity));
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
    SurveyQuestionEntityBase questionTemplateEntityBase = textQuestionTemplateDto.ToQuestionTemplateEntity();

    // Assert
    Assert.AreEqual(textQuestionTemplateDto.Text, questionTemplateEntityBase.Text);
  }
}
