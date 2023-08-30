// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyQuestion;

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
    SurveyQuestionEntityBase questionTemplateEntityBase = yesNoQuestionTemplateDto.ToQuestionTemplateEntity();

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(YesNoQuestionEntity));
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
    SurveyQuestionEntityBase questionTemplateEntityBase = yesNoQuestionTemplateDto.ToQuestionTemplateEntity();

    // Assert
    Assert.AreEqual(yesNoQuestionTemplateDto.Text, questionTemplateEntityBase.Text);
  }
}
