// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class MultipleChoiceQuestionDtoTest
{
  [TestMethod]
  public void Constructor_MultipleChoiceQuestionEntity_TextFilled()
  {
    // Arrange
    MultipleChoiceQuestionEntity multipleChoiceQuestionEntity = new
    (
      text: Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      answers: Array.Empty<string>()
    );

    // Act
    MultipleChoiceQuestionDto multipleChoiceQuestionDto = new(multipleChoiceQuestionEntity);

    // Assert
    Assert.AreEqual(multipleChoiceQuestionEntity.Text, multipleChoiceQuestionDto.Text);
  }
}
