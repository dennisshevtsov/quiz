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
      text: Guid.NewGuid().ToString(),
      answer: YesNo.None
    );

    // Act
    SingleChoiceQuestionDto singleChoiceQuestionDto = new(singleChoiceQuestionEntity);

    // Assert
    Assert.AreEqual(singleChoiceQuestionEntity.Text, singleChoiceQuestionDto.Text);
  }
}
