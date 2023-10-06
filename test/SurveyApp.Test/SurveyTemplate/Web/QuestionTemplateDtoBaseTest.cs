// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class QuestionTemplateDtoBaseTest
{
  [TestMethod]
  public void FromQuestionTemplateEntity_TextQuestionTemplateEntity_NullNotReturned()
  {
    // Arrange
    TextQuestionTemplateEntity textQuestionTemplateEntity = TextQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(textQuestionTemplateEntity);

    // Assert
    Assert.IsNotNull(surveyTemplateQuestionDtoBase);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_TextQuestionTemplateEntity_TextQuestionTemplateDtoReturned()
  {
    // Arrange
    TextQuestionTemplateEntity textQuestionTemplateEntity = TextQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(textQuestionTemplateEntity);

    // Assert
    Assert.IsInstanceOfType<TextQuestionTemplateDto>(surveyTemplateQuestionDtoBase);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_TextQuestionTemplateEntity_TextFilled()
  {
    // Arrange
    TextQuestionTemplateEntity textQuestionTemplateEntity = TextQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(textQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(surveyTemplateQuestionDtoBase.Text, textQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_YesNoQuestionTemplateEntity_NullNotReturned()
  {
    // Arrange
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = YesNoQuestionTemplateEntity.New(
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(yesNoQuestionTemplateEntity);

    // Assert
    Assert.IsNotNull(surveyTemplateQuestionDtoBase);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_YesNoQuestionTemplateEntity_YesNoQuestionTemplateDtoReturned()
  {
    // Arrange
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = YesNoQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(yesNoQuestionTemplateEntity);

    // Assert
    Assert.IsInstanceOfType(surveyTemplateQuestionDtoBase, typeof(YesNoQuestionTemplateDto));
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_YesNoQuestionTemplateEntity_TextFilled()
  {
    // Arrange
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = YesNoQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(yesNoQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(surveyTemplateQuestionDtoBase.Text, yesNoQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_MultipleChoiceQuestionTemplateEntity_NullNotReturned()
  {
    // Arrange
    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = MultipleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(multipleChoiceQuestionTemplateEntity);

    // Assert
    Assert.IsNotNull(surveyTemplateQuestionDtoBase);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_MultipleChoiceQuestionTemplateEntity_MultipleChoiceQuestionTemplateDtoReturned()
  {
    // Arrange
    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = MultipleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(multipleChoiceQuestionTemplateEntity);

    // Assert
    Assert.IsInstanceOfType<MultipleChoiceQuestionTemplateDto>(surveyTemplateQuestionDtoBase);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_MultipleChoiceQuestionTemplateEntity_TextFilled()
  {
    // Arrange
    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = MultipleChoiceQuestionTemplateEntity.New
    (
      text   :Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(multipleChoiceQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(surveyTemplateQuestionDtoBase.Text, multipleChoiceQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_MultipleChoiceQuestionTemplateEntity_ChoicesFilled()
  {
    // Arrange
    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = MultipleChoiceQuestionTemplateEntity.New
    (
      text: Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(multipleChoiceQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(multipleChoiceQuestionTemplateEntity.Choices, ((MultipleChoiceQuestionTemplateDto)surveyTemplateQuestionDtoBase).Choices);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_SingleChoiceQuestionTemplateEntity_NullNotReturned()
  {
    // Arrange
    SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(singleChoiceQuestionTemplateEntity);

    // Assert
    Assert.IsNotNull(surveyTemplateQuestionDtoBase);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_SingleChoiceQuestionTemplateEntity_SingleChoiceQuestionTemplateDtoReturned()
  {
    // Arrange
    SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(singleChoiceQuestionTemplateEntity);

    // Assert
    Assert.IsInstanceOfType<SingleChoiceQuestionTemplateDto>(surveyTemplateQuestionDtoBase);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_SingleChoiceQuestionTemplateEntity_TextFilled()
  {
    // Arrange
    SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   :Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(singleChoiceQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(surveyTemplateQuestionDtoBase.Text, singleChoiceQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_SingleChoiceQuestionTemplateEntity_ChoicesFilled()
  {
    // Arrange
    SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity = SingleChoiceQuestionTemplateEntity.New
    (
      text   : Guid.NewGuid().ToString(),
      choices: new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
      context: new ExecutingContext()
    )!;

    // Act
    QuestionTemplateDtoBase surveyTemplateQuestionDtoBase =
      QuestionTemplateDtoBase.FromQuestionTemplateEntity(singleChoiceQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(singleChoiceQuestionTemplateEntity.Choices, ((SingleChoiceQuestionTemplateDto)surveyTemplateQuestionDtoBase).Choices);
  }

  [TestMethod]
  public void ToQuestionTemplateEntityCollection_SurveyTemplateDtoCollection_EntityListCreated()
  {
    // Arrange
    QuestionTemplateDtoBase[] questionTemplateDtos = new QuestionTemplateDtoBase[]
    {
      new YesNoQuestionTemplateDto
      {
        QuestionType = QuestionType.YesNo,
        Text         = Guid.NewGuid().ToString(),
      },
      new TextQuestionTemplateDto
      {
        QuestionType = QuestionType.Text,
        Text         = Guid.NewGuid().ToString(),
      },
      new MultipleChoiceQuestionTemplateDto
      {
        QuestionType = QuestionType.MultipleChoice,
        Text         = Guid.NewGuid().ToString(),
        Choices      = new[]
        {
          Guid.NewGuid().ToString(),
          Guid.NewGuid().ToString(),
        },
      },
      new SingleChoiceQuestionTemplateDto
      {
        QuestionType = QuestionType.SingleChoice,
        Text         = Guid.NewGuid().ToString(),
        Choices      = new[]
        {
          Guid.NewGuid().ToString(),
          Guid.NewGuid().ToString(),
        },
      },
    };

    // Act
    QuestionTemplateEntityBase[] questionTemplateEntities = QuestionTemplateDtoBase.ToQuestionTemplateEntityCollection
    (
      questions: questionTemplateDtos,
      context  : new ExecutingContext()
    );

    // Assert
    Assert.AreEqual(questionTemplateDtos.Length, questionTemplateEntities.Length);

    for (int i = 0; i < questionTemplateDtos.Length; i++)
    {
      AreEqual(questionTemplateDtos[i], questionTemplateEntities[i]);
    }
  }

  [TestMethod]
  public void FromQuestionTemplateEntityCollection_QuestionTemplateEntityCollection_QuestionTemplateDtoCollectionCreated()
  {
    // Arrange
    QuestionTemplateEntityBase[] questionTemplateEntities = new QuestionTemplateEntityBase[]
    {
      YesNoQuestionTemplateEntity.New
      (
        text   : Guid.NewGuid().ToString(),
        context: new ExecutingContext()
      )!,
      TextQuestionTemplateEntity.New
      (
        text   : Guid.NewGuid().ToString(),
        context: new ExecutingContext()
      )!,
      MultipleChoiceQuestionTemplateEntity.New
      (
        text   : Guid.NewGuid().ToString(),
        choices: new[]
        {
          Guid.NewGuid().ToString(),
          Guid.NewGuid().ToString(),
          Guid.NewGuid().ToString(),
        },
        context: new ExecutingContext()
      )!,
      SingleChoiceQuestionTemplateEntity.New
      (
        text   : Guid.NewGuid().ToString(),
        choices: new[]
        {
          Guid.NewGuid().ToString(),
          Guid.NewGuid().ToString(),
          Guid.NewGuid().ToString(),
        },
        context: new ExecutingContext()
      )!,
    };

    // Act
    QuestionTemplateDtoBase[] questionTemplateDtos = QuestionTemplateDtoBase.FromQuestionTemplateEntityCollection(questionTemplateEntities);

    // Assert
    Assert.AreEqual(questionTemplateDtos.Length, questionTemplateEntities.Length);

    for (int i = 0; i < questionTemplateDtos.Length; i++)
    {
      AreEqual(questionTemplateDtos[i], questionTemplateEntities[i]);
    }
  }

  private static void AreEqual(QuestionTemplateDtoBase expected, QuestionTemplateEntityBase actual)
  {
    Assert.AreEqual(expected.QuestionType, actual.QuestionType);
    Assert.AreEqual(expected.Text, actual.Text);

    if (expected.QuestionType == QuestionType.MultipleChoice)
    {
      AreChoicesEqual(((MultipleChoiceQuestionTemplateDto)expected).Choices, ((MultipleChoiceQuestionTemplateEntity)actual).Choices);
    }

    if (expected.QuestionType == QuestionType.SingleChoice)
    {
      AreChoicesEqual(((SingleChoiceQuestionTemplateDto)expected).Choices, ((SingleChoiceQuestionTemplateEntity)actual).Choices);
    }
  }

  private static void AreChoicesEqual(string[] expected, string[] actual)
  {
    Assert.AreEqual(expected.Length, actual.Length);

    for (int i = 0; i < expected.Length; i++)
    {
      Assert.AreEqual(expected[i], actual[i]);
    }
  }
}
