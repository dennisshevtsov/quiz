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
    TextQuestionTemplateDto textQuestionTemplateDto = new()
    {
      Text = Guid.NewGuid().ToString(),
    };

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = textQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext())!;

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(TextQuestionTemplateEntity));
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_TextQuestionTemplateDto_TextFilled()
  {
    // Arrange
    TextQuestionTemplateDto textQuestionTemplateDto = new()
    {
      Text = Guid.NewGuid().ToString(),
    };

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = textQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext())!;

    // Assert
    Assert.AreEqual(textQuestionTemplateDto.Text, questionTemplateEntityBase.Text);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_NoText_NullReturned()
  {
    // Arrange
    TextQuestionTemplateDto textQuestionTemplateDto = new()
    {
      Text = string.Empty,
    };

    // Act
    QuestionTemplateEntityBase? questionTemplateEntityBase = textQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext());

    // Assert
    Assert.IsNull(questionTemplateEntityBase);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_NoText_ContextContainsErrors()
  {
    // Arrange
    TextQuestionTemplateDto textQuestionTemplateDto = new()
    {
      Text = string.Empty,
    };

    ExecutingContext context = new();

    // Act
    textQuestionTemplateDto.ToTemplateQuestionEntity(context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }
}
