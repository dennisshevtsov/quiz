// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class SingleChoiceQuestionDtoTest
{
  [TestMethod]
  public void Constructor_SingleChoiceQuestionEntity_TextFilled()
  {
    // Arrange
    SingleChoiceQuestionEntity singleChoiceQuestionEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      answer : null
    );

    // Act
    SingleChoiceQuestionDto singleChoiceQuestionDto = new(singleChoiceQuestionEntity);

    // Assert
    Assert.AreEqual(singleChoiceQuestionEntity.Text, singleChoiceQuestionDto.Text);
  }

  [TestMethod]
  public void Constructor_SingleChoiceQuestionEntity_ChoicesFilled()
  {
    // Arrange
    SingleChoiceQuestionEntity singleChoiceQuestionEntity = new
    (
      text: Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      answer: null
    );

    // Act
    SingleChoiceQuestionDto singleChoiceQuestionDto = new(singleChoiceQuestionEntity);

    // Assert
    Assert.AreEqual(singleChoiceQuestionEntity.Choices, singleChoiceQuestionDto.Choices);
  }
}
