// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey.Test;

[TestClass]
public sealed class YesNoQuestionEntityTest
{
  [TestMethod]
  public void Constructor_Text_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();

    // Act
    YesNoQuestionEntity yesNoQuestionEntity = new
    (
      text  : text,
      answer: default
    );

    // Assert
    Assert.AreEqual(text, yesNoQuestionEntity.Text);
  }

  [TestMethod]
  public void Constructor_Answer_AnswerFilled()
  {
    // Arrange
    YesNo answer = YesNo.Yes;

    // Act
    YesNoQuestionEntity yesNoQuestionEntity = new
    (
      text  : string.Empty,
      answer: answer
    );

    // Assert
    Assert.AreEqual(answer, yesNoQuestionEntity.Answer);
  }

  [TestMethod]
  public void Constructor_YesNoQuestionTemplateEntity_TextFilled()
  {
    // Arrange
    string text = Guid.NewGuid().ToString();
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = YesNoQuestionTemplateEntity.New
    (
      text   : text,
      context: new ExecutingContext()
    )!;

    // Act
    YesNoQuestionEntity yesNoQuestionEntity = new(yesNoQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(text, yesNoQuestionEntity.Text);
  }

  [TestMethod]
  public void Constructor_YesNoQuestionTemplateEntity_AnswerIsNone()
  {
    // Arrange
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = YesNoQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    )!;

    // Act
    YesNoQuestionEntity yesNoQuestionEntity = new(yesNoQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(YesNo.None, yesNoQuestionEntity.Answer);
  }

  [TestMethod]
  public void SetAnswer_Yes_AnswerUpdated()
  {
    // Arrange
    YesNoQuestionEntity yesNoQuestionEntity = new
    (
      text  : Guid.NewGuid().ToString(),
      answer: YesNo.None
    );

    YesNo answer = YesNo.Yes;

    // Act
    yesNoQuestionEntity.SetAnswer(answer, new ExecutingContext());

    // Assert
    Assert.AreEqual(answer, yesNoQuestionEntity.Answer);
  }

  [TestMethod]
  public void SetAnswer_None_AnswerUpdated()
  {
    // Arrange
    YesNoQuestionEntity yesNoQuestionEntity = new
    (
      text  : Guid.NewGuid().ToString(),
      answer: YesNo.None
    );

    YesNo answer = YesNo.No;

    // Act
    yesNoQuestionEntity.SetAnswer(answer, new ExecutingContext());

    // Assert
    Assert.AreEqual(answer, yesNoQuestionEntity.Answer);
  }

  [TestMethod]
  public void SetAnswer_No_AnswerUpdated()
  {
    // Arrange
    YesNoQuestionEntity yesNoQuestionEntity = new
    (
      text  : Guid.NewGuid().ToString(),
      answer: YesNo.None
    );

    YesNo answer = YesNo.No;

    // Act
    yesNoQuestionEntity.SetAnswer(answer, new ExecutingContext());

    // Assert
    Assert.AreEqual(answer, yesNoQuestionEntity.Answer);
  }

  [TestMethod]
  public void SetAnswer_UnknownAnswer_AnswerNotUpdated()
  {
    // Arrange
    YesNo originalAnswer = YesNo.Yes;
    YesNoQuestionEntity yesNoQuestionEntity = new
    (
      text  : Guid.NewGuid().ToString(),
      answer: YesNo.Yes
    );

    YesNo unknownAnswer = (YesNo)100;

    // Act
    yesNoQuestionEntity.SetAnswer(unknownAnswer, new ExecutingContext());

    // Assert
    Assert.AreEqual(originalAnswer, yesNoQuestionEntity.Answer);
  }
}
