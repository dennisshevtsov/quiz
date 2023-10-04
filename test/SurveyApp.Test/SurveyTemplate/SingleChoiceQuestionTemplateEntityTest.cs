// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Test;

[TestClass]
public sealed class SingleChoiceQuestionTemplateEntityTest
{
  [TestMethod]
  public void Constructor_FullListOfParameters_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();

    // Act
    SingleChoiceQuestionTemplateEntity? singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : text,
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    );

    // Assert
    Assert.AreEqual(text, singleChoiceQuestionTemplateEntity!.Text);
  }
}
