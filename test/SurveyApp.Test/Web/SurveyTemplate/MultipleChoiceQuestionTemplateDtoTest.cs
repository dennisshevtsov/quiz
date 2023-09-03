// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

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
    SurveyTemplateQuestionEntityBase questionTemplateEntityBase = multipleChoiceQuestionTemplateDto.ToSurveyTemplateQuestionEntity();

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(MultipleChoiceSurveyTemplateQuestionEntity));
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_MultipleChoiceQuestionTemplateDto_PropertiesFilled()
  {
    // Arrange
    MultipleChoiceQuestionTemplateDto multipleChoiceQuestionTemplateDto = new()
    {
      QuestionType = QuestionType.SingleChoice,
      Text = "test",
      Choices = new[]
      {
        "test1",
        "test2",
      },
    };

    // Act
    SurveyTemplateQuestionEntityBase questionTemplateEntityBase = multipleChoiceQuestionTemplateDto.ToSurveyTemplateQuestionEntity();

    // Assert
    Assert.AreEqual(multipleChoiceQuestionTemplateDto.Text, questionTemplateEntityBase.Text);

    MultipleChoiceSurveyTemplateQuestionEntity singleChoiceQuestionTemplateEntity =
      (MultipleChoiceSurveyTemplateQuestionEntity)questionTemplateEntityBase;
    Assert.AreEqual(multipleChoiceQuestionTemplateDto.Choices.Length, singleChoiceQuestionTemplateEntity.Choices.Length);

    string[] expected = multipleChoiceQuestionTemplateDto.Choices.Order().ToArray();
    string[] actual = singleChoiceQuestionTemplateEntity.Choices.Order().ToArray();

    for (int i = 0; i < expected.Length; i++)
    {
      Assert.AreEqual(expected[i], actual[i]);
    }
  }
}
