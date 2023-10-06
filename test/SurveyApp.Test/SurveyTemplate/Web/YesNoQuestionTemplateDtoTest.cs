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
    YesNoQuestionTemplateDto yesNoQuestionTemplateDto = new()
    {
      Text = Guid.NewGuid().ToString(),
    };

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = yesNoQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext())!;

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(YesNoQuestionTemplateEntity));
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_YesNoQuestionTemplateDto_TextFilled()
  {
    // Arrange
    YesNoQuestionTemplateDto yesNoQuestionTemplateDto = new()
    {
      Text = Guid.NewGuid().ToString(),
    };

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = yesNoQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext())!;

    // Assert
    Assert.AreEqual(yesNoQuestionTemplateDto.Text, questionTemplateEntityBase.Text);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_NoText_NullReturned()
  {
    // Arrange
    YesNoQuestionTemplateDto yesNoQuestionTemplateDto = new()
    {
      Text = string.Empty,
    };

    // Act
    QuestionTemplateEntityBase? questionTemplateEntityBase = yesNoQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext());

    // Assert
    Assert.IsNull(questionTemplateEntityBase);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_NoText_ContextHasErrors()
  {
    // Arrange
    YesNoQuestionTemplateDto yesNoQuestionTemplateDto = new()
    {
      Text = string.Empty,
    };

    ExecutingContext context = new();

    // Act
    yesNoQuestionTemplateDto.ToTemplateQuestionEntity(context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }
}
