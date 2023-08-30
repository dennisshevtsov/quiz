// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyQuestion;
using SurveyApp.Web.SurveyQuestion;

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
    SurveyQuestionEntityBase questionTemplateEntityBase = multipleChoiceQuestionTemplateDto.ToQuestionTemplateEntity();

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(MultipleChoiceQuestionEntity));
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
    SurveyQuestionEntityBase questionTemplateEntityBase = multipleChoiceQuestionTemplateDto.ToQuestionTemplateEntity();

    // Assert
    Assert.AreEqual(multipleChoiceQuestionTemplateDto.Text, questionTemplateEntityBase.Text);

    MultipleChoiceQuestionEntity singleChoiceQuestionTemplateEntity =
      (MultipleChoiceQuestionEntity)questionTemplateEntityBase;
    Assert.AreEqual(multipleChoiceQuestionTemplateDto.Choices.Length, singleChoiceQuestionTemplateEntity.Choices.Length);

    string[] expected = multipleChoiceQuestionTemplateDto.Choices.Order().ToArray();
    string[] actual = singleChoiceQuestionTemplateEntity.Choices.Order().ToArray();

    for (int i = 0; i < expected.Length; i++)
    {
      Assert.AreEqual(expected[i], actual[i]);
    }
  }
}
