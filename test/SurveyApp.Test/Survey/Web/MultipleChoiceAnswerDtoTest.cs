// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class MultipleChoiceAnswerDtoTest
{
  [TestMethod]
  public void Update_MultipleChoiceQuestionEntity_AnswersUpdated()
  {
    // Arrange
    string[] answers = new[]
    {
      Guid.NewGuid().ToString(),
    };

    MultipleChoiceAnswerDto multipleChoiceAnswerDto = new()
    {
      Answers = answers,
    };

    MultipleChoiceQuestionEntity multipleChoiceQuestionEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        answers[0],
      },
      answers: Array.Empty<string>()
    );

    // Act
    multipleChoiceAnswerDto.SetAnswer(multipleChoiceQuestionEntity);

    // Assert
    Assert.AreEqual(answers.Length, multipleChoiceQuestionEntity.Answers.Length);
    for (int i = 0; i < answers.Length; i++)
    {
      Assert.AreEqual(answers[i], multipleChoiceQuestionEntity.Answers[i]);
    }
  }

  [TestMethod]
  public void Update_UnknownAnswer_AnswerNotUpdated()
  {
    // Arrange
    MultipleChoiceAnswerDto multipleChoiceAnswerDto = new()
    {
      Answers = new[]
      {
        Guid.NewGuid().ToString(),
      },
    };

    string[] answers = new[]
    {
      Guid.NewGuid().ToString(),
    };
    MultipleChoiceQuestionEntity multipleChoiceQuestionEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      answers: answers
    );

    // Act
    multipleChoiceAnswerDto.SetAnswer(multipleChoiceQuestionEntity);

    // Assert
    Assert.AreEqual(answers, multipleChoiceQuestionEntity.Answers);
  }
}
