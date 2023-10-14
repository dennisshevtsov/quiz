// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Test;

[TestClass]
public sealed class MultipleChoiceQuestionEntityTest
{
  [TestMethod]
  public void Constructor_Text_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();

    // Act
    MultipleChoiceQuestionEntity multipleChoiceQuestionEntity = new
    (
      text   : text,
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      answers: Array.Empty<string>()
    );

    // Assert
    Assert.AreEqual(text, multipleChoiceQuestionEntity.Text);
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
    MultipleChoiceQuestionEntity multipleChoiceQuestionEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: choices,
      answers: Array.Empty<string>()
    );

    // Assert
    Assert.AreEqual(choices, multipleChoiceQuestionEntity.Choices);
  }

  [TestMethod]
  public void Constructor_Answers_AnswersFilled()
  {
    // Arrange
    string[] answers = new[]
    {
      Guid.NewGuid().ToString(),
      Guid.NewGuid().ToString(),
    };

    // Act
    MultipleChoiceQuestionEntity multipleChoiceQuestionEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        answers[0],
        Guid.NewGuid().ToString(),
        answers[1],
      },
      answers: answers
    );

    // Assert
    Assert.AreEqual(answers, multipleChoiceQuestionEntity.Answers);
  }

  [TestMethod]
  public void SetAnswers_Answers_AnswersUpdated()
  {
    // Arrange
    string[] answers = new[]
    {
      Guid.NewGuid().ToString(),
      Guid.NewGuid().ToString(),
    };

    MultipleChoiceQuestionEntity multipleChoiceQuestionEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        answers[0],
        Guid.NewGuid().ToString(),
        answers[1],
      },
      answers: Array.Empty<string>()
    );

    // Act
    multipleChoiceQuestionEntity.SetAnswers(answers, new ExecutingContext());

    // Assert
    Assert.AreEqual(answers.Length, multipleChoiceQuestionEntity.Answers.Length);
    for (int i = 0; i < answers.Length; i++)
    {
      Assert.AreEqual(answers[i], multipleChoiceQuestionEntity.Answers[i]);
    }
  }

  [TestMethod]
  public void SetAnswers_UnknownAnswers_AnswersUpdated()
  {
    // Arrange
    string[] originalAnswers = new[]
    {
      Guid.NewGuid().ToString(),
      Guid.NewGuid().ToString(),
    };

    string[] unknownAnswers = new[]
    {
      Guid.NewGuid().ToString(),
      Guid.NewGuid().ToString(),
    };

    MultipleChoiceQuestionEntity multipleChoiceQuestionEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        originalAnswers[0],
        Guid.NewGuid().ToString(),
        originalAnswers[1],
      },
      answers: originalAnswers
    );

    // Act
    multipleChoiceQuestionEntity.SetAnswers(unknownAnswers, new ExecutingContext());

    // Assert
    Assert.AreEqual(originalAnswers, multipleChoiceQuestionEntity.Answers);
  }
}
