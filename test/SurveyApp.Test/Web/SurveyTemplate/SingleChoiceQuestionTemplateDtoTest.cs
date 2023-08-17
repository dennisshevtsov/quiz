// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class SingleChoiceQuestionTemplateDtoTest
{
  [TestMethod]
  public void ToQuestionTemplateEntity_SingleChoiceQuestionTemplateDto_TextQuestionTemplateEntityReturned()
  {
    // Arrange
    SingleChoiceQuestionTemplateDto singleChoiceQuestionTemplateDto = new();

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = singleChoiceQuestionTemplateDto.ToQuestionTemplateEntity();

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(SingleChoiceQuestionTemplateEntity));
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_SingleChoiceQuestionTemplateDto_PropertiesFilled()
  {
    // Arrange
    SingleChoiceQuestionTemplateDto singleChoiceQuestionTemplateDto = new()
    {
      QuestionType = SurveyQuestionType.SingleChoice,
      Text = "test",
      Choices = new[]
      {
        "test1",
        "test2",
      },
    };

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = singleChoiceQuestionTemplateDto.ToQuestionTemplateEntity();

    // Assert
    Assert.AreEqual(singleChoiceQuestionTemplateDto.Text, questionTemplateEntityBase.Text);

    SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity =
      (SingleChoiceQuestionTemplateEntity)questionTemplateEntityBase;
    Assert.AreEqual(singleChoiceQuestionTemplateDto.Choices.Length, singleChoiceQuestionTemplateEntity.Choices.Length);

    string[] expected = singleChoiceQuestionTemplateDto.Choices.Order().ToArray();
    string[] actual = singleChoiceQuestionTemplateEntity.Choices.Order().ToArray();

    for (int i = 0; i < expected.Length; i++)
    {
      Assert.AreEqual(expected[i], actual[i]);
    }
  }
}
