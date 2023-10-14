// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class TextAnswerDtoTest
{
  [TestMethod]
  public void Update_TextQuestionEntity_AnswerUpdated()
  {
    // Arrange
    TextQuestionEntity textQuestionEntity = new
    (
      text  : Guid.NewGuid().ToString(),
      answer: null
    );

    string answer = Guid.NewGuid().ToString();
    TextAnswerDto textAnswerDto = new()
    {
      Answer = answer,
    };

    // Act
    textAnswerDto.SetAnswer(textQuestionEntity, new ExecutingContext());

    // Assert
    Assert.AreEqual(answer, textQuestionEntity.Answer);
  }
}
