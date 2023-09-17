// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class YesNoQuestionDtoTest
{
  [TestMethod]
  public void Constructor_YesNoQuestionEntity_TextFilled()
  {
    // Arrange
    YesNoQuestionEntity yesNoQuestionEntity = new(
      text  : Guid.NewGuid().ToString(),
      answer: YesNo.None);

    // Act
    YesNoQuestionDto yesNoQuestionDto = new(yesNoQuestionEntity);

    // Assert
    Assert.AreEqual(yesNoQuestionEntity.Text, yesNoQuestionDto.Text);
  }
}
