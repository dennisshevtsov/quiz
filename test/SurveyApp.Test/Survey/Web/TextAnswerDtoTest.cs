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

    TextAnswerDto textAnswerDto = new()
    {
      Answer = Guid.NewGuid().ToString(),
    };

    // Act
    textAnswerDto.Update(textQuestionEntity);

    // Assert
    Assert.AreEqual(textAnswerDto.Answer, textQuestionEntity.Answer);
  }
}
