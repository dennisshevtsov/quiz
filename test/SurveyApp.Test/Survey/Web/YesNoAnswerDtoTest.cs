// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class YesNoAnswerDtoTest
{
  [TestMethod]
  public void Update_YesNoQuestionEntity_AnswerUpdated()
  {
    // Arrange
    YesNoQuestionEntity yesNoQuestionEntity = new
    (
      text  : Guid.NewGuid().ToString(),
      answer: YesNo.None
    );

    YesNo answer = YesNo.Yes;
    YesNoAnswerDto yesNoAnswerDto = new()
    {
      Answer = answer,
    };

    // Act
    yesNoAnswerDto.SetAnswer(yesNoQuestionEntity, new ExecutingContext());

    // Assert
    Assert.AreEqual(answer, yesNoQuestionEntity.Answer);
  }
}
