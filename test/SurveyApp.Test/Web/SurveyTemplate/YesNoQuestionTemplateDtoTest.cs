// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class YesNoQuestionTemplateDtoTest
{
  [TestMethod]
  public void ToQuestionTemplateEntity_YesNoQuestionTemplateDto_YesNoQuestionTemplateEntityReturned()
  {
    // Arrange
    YesNoQuestionTemplateDto yesNoQuestionTemplateDto = new();

    // Act
    SurveyTemplateQuestionEntityBase questionTemplateEntityBase = yesNoQuestionTemplateDto.ToSurveyTemplateQuestionEntity();

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(YesNoSurveyTemplateQuestionEntity));
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_YesNoQuestionTemplateDto_PropertiesFilled()
  {
    // Arrange
    YesNoQuestionTemplateDto yesNoQuestionTemplateDto = new()
    {
      QuestionType = SurveyQuestionType.YesNo,
      Text = "test",
    };

    // Act
    SurveyTemplateQuestionEntityBase questionTemplateEntityBase = yesNoQuestionTemplateDto.ToSurveyTemplateQuestionEntity();

    // Assert
    Assert.AreEqual(yesNoQuestionTemplateDto.Text, questionTemplateEntityBase.Text);
  }
}
