// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class MultipleChoiceQuestionTemplateDtoTest
{
  [TestMethod]
  public void ToQuestionTemplateEntity_MultipleChoiceQuestionTemplateDto_MultipleChoiceQuestionTemplateEntityReturned()
  {
    // Arrange
    MultipleChoiceQuestionTemplateDto multipleChoiceQuestionTemplateDto = new();

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = multipleChoiceQuestionTemplateDto.ToQuestionTemplateEntity();

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(MultipleChoiceQuestionTemplateEntity));
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_MultipleChoiceQuestionTemplateDto_PropertiesFilled()
  {
    // Arrange
    MultipleChoiceQuestionTemplateDto multipleChoiceQuestionTemplateDto = new()
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
    QuestionTemplateEntityBase questionTemplateEntityBase = multipleChoiceQuestionTemplateDto.ToQuestionTemplateEntity();

    // Assert
    Assert.AreEqual(multipleChoiceQuestionTemplateDto.Text, questionTemplateEntityBase.Text);

    MultipleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity =
      (MultipleChoiceQuestionTemplateEntity)questionTemplateEntityBase;
    Assert.AreEqual(multipleChoiceQuestionTemplateDto.Choices.Length, singleChoiceQuestionTemplateEntity.Choices.Length);

    string[] expected = multipleChoiceQuestionTemplateDto.Choices.Order().ToArray();
    string[] actual = singleChoiceQuestionTemplateEntity.Choices.Order().ToArray();

    for (int i = 0; i < expected.Length; i++)
    {
      Assert.AreEqual(expected[i], actual[i]);
    }
  }
}
