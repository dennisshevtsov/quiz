// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class SingleChoiceQuestionTemplateDtoTest
{
  [TestMethod]
  public void ToQuestionTemplateEntity_SingleChoiceQuestionTemplateDto_SingleChoiceQuestionTemplateEntityReturned()
  {
    // Arrange
    SingleChoiceQuestionTemplateDto singleChoiceQuestionTemplateDto = new();

    // Act
    SurveyTemplateQuestionEntityBase questionTemplateEntityBase = singleChoiceQuestionTemplateDto.ToSurveyTemplateQuestionEntity();

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(SingleChoiceSurveyTemplateQuestionEntity));
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
    SurveyTemplateQuestionEntityBase questionTemplateEntityBase = singleChoiceQuestionTemplateDto.ToSurveyTemplateQuestionEntity();

    // Assert
    Assert.AreEqual(singleChoiceQuestionTemplateDto.Text, questionTemplateEntityBase.Text);

    SingleChoiceSurveyTemplateQuestionEntity singleChoiceQuestionTemplateEntity =
      (SingleChoiceSurveyTemplateQuestionEntity)questionTemplateEntityBase;
    Assert.AreEqual(singleChoiceQuestionTemplateDto.Choices.Length, singleChoiceQuestionTemplateEntity.Choices.Length);

    string[] expected = singleChoiceQuestionTemplateDto.Choices.Order().ToArray();
    string[] actual = singleChoiceQuestionTemplateEntity.Choices.Order().ToArray();

    for (int i = 0; i < expected.Length; i++)
    {
      Assert.AreEqual(expected[i], actual[i]);
    }
  }
}
