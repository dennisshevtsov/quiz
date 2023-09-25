﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey.Test;

[TestClass]
public sealed class QuestionEntityBaseTest
{
  [TestMethod]
  public void Copy_TextQuestionTemplateEntity_TextQuestionEntityReturned()
  {
    // Arrange
    TextQuestionTemplateEntity textQuestionTemplateEntity = new
    (
      text: Guid.NewGuid().ToString()
    );

    // Act
    QuestionEntityBase questionEntity = QuestionEntityBase.Copy(textQuestionTemplateEntity);

    // Assert
    Assert.IsInstanceOfType<TextQuestionEntity>(questionEntity);
  }

  [TestMethod]
  public void Copy_YesNoQuestionTemplateEntity_YesNoQuestionEntityReturned()
  {
    // Arrange
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = new
    (
      text: Guid.NewGuid().ToString()
    );

    // Act
    QuestionEntityBase questionEntity = QuestionEntityBase.Copy(yesNoQuestionTemplateEntity);

    // Assert
    Assert.IsInstanceOfType<YesNoQuestionEntity>(questionEntity);
  }

  [TestMethod]
  public void Copy_MultipleChoiceQuestionTemplateEntity_MultipleChoiceQuestionEntityReturned()
  {
    // Arrange
    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = new
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      }
    );

    // Act
    QuestionEntityBase questionEntity = QuestionEntityBase.Copy(multipleChoiceQuestionTemplateEntity);

    // Assert
    Assert.IsInstanceOfType<MultipleChoiceQuestionEntity>(questionEntity);
  }
}
