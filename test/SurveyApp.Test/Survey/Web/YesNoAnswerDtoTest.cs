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

    YesNoAnswerDto yesNoAnswerDto = new()
    {
      Answer = YesNo.Yes,
    };

    // Act
    yesNoAnswerDto.Update(yesNoQuestionEntity);

    // Assert
    Assert.AreEqual(yesNoAnswerDto.Answer, yesNoQuestionEntity.Answer);
  }
}
