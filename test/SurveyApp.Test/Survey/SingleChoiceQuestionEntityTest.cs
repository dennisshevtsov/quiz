// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Test;

[TestClass]
public sealed class SingleChoiceQuestionEntityTest
{
  [TestMethod]
  public void Constructor_Text_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();

    // Act
    SingleChoiceQuestionEntity singleChoiceQuestionEntity = new
    (
      text   : text,
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      answer : null
    );

    // Assert
    Assert.AreEqual(text, singleChoiceQuestionEntity.Text);
  }

  [TestMethod]
  public void Constructor_Choices_ChoicesFilled()
  {
    // Arrange
    string[] choices = new[]
    {
      Guid.NewGuid().ToString(),
      Guid.NewGuid().ToString(),
      Guid.NewGuid().ToString(),
    };

    // Act
    SingleChoiceQuestionEntity singleChoiceQuestionEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: choices,
      answer : null
    );

    // Assert
    Assert.AreEqual(choices, singleChoiceQuestionEntity.Choices);
  }

  [TestMethod]
  public void Constructor_Answer_AnwerFilled()
  {
    // Arrange
    string answer = Guid.NewGuid().ToString();

    // Act
    SingleChoiceQuestionEntity singleChoiceQuestionEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      answer : answer
    );

    // Assert
    Assert.AreEqual(answer, singleChoiceQuestionEntity.Answer);
  }

  [TestMethod]
  public void SetAnswer_Answer_AnwerUpdated()
  {
    // Arrange
    string answer = Guid.NewGuid().ToString();

    SingleChoiceQuestionEntity singleChoiceQuestionEntity = new
    (
      text  : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        answer,
      },
      answer : null
    );

    // Act
    singleChoiceQuestionEntity.SetAnswer(answer);

    // Assert
    Assert.AreEqual(answer, singleChoiceQuestionEntity.Answer);
  }
}
