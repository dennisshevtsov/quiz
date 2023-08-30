// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyQuestion;

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class SurveyTemplateQuestionDtoBaseTest
{
  [TestMethod]
  public void FromQuestionTemplateEntity_TextQuestionTemplateEntity_SurveyTemplateQuestionDtoBaseCreated()
  {
    // Arrange
    TextQuestionEntity textQuestionTemplateEntity = new();

    // Act
    SurveyTemplateQuestionDtoBase surveyTemplateQuestionDtoBase =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(textQuestionTemplateEntity);

    // Assert
    Assert.IsNotNull(surveyTemplateQuestionDtoBase);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_TextQuestionTemplateEntity_TextQuestionTemplateDtoCreated()
  {
    // Arrange
    TextQuestionEntity textQuestionTemplateEntity = new();

    // Act
    SurveyTemplateQuestionDtoBase surveyTemplateQuestionDtoBase =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(textQuestionTemplateEntity);

    // Assert
    Assert.IsInstanceOfType(surveyTemplateQuestionDtoBase, typeof(TextQuestionTemplateDto));
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_TextQuestionTemplateEntity_PropertiesFilled()
  {
    // Arrange
    TextQuestionEntity textQuestionTemplateEntity = new()
    {
      Text = Guid.NewGuid().ToString(),
    };

    // Act
    SurveyTemplateQuestionDtoBase surveyTemplateQuestionDtoBase =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(textQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(surveyTemplateQuestionDtoBase.Text, textQuestionTemplateEntity.Text);
  }
  [TestMethod]
  public void FromQuestionTemplateEntity_YesNoQuestionTemplateEntity_SurveyTemplateQuestionDtoBaseCreated()
  {
    // Arrange
    YesNoQuestionEntity yesNoQuestionTemplateEntity = new();

    // Act
    SurveyTemplateQuestionDtoBase surveyTemplateQuestionDtoBase =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(yesNoQuestionTemplateEntity);

    // Assert
    Assert.IsNotNull(surveyTemplateQuestionDtoBase);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_YesNoQuestionTemplateEntity_YesNoQuestionTemplateDtoCreated()
  {
    // Arrange
    YesNoQuestionEntity yesNoQuestionTemplateEntity = new();

    // Act
    SurveyTemplateQuestionDtoBase surveyTemplateQuestionDtoBase =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(yesNoQuestionTemplateEntity);

    // Assert
    Assert.IsInstanceOfType(surveyTemplateQuestionDtoBase, typeof(YesNoQuestionTemplateDto));
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_YesNoQuestionTemplateEntity_PropertiesFilled()
  {
    // Arrange
    YesNoQuestionEntity yesNoQuestionTemplateEntity = new()
    {
      Text = Guid.NewGuid().ToString(),
    };

    // Act
    SurveyTemplateQuestionDtoBase surveyTemplateQuestionDtoBase =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(yesNoQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(surveyTemplateQuestionDtoBase.Text, yesNoQuestionTemplateEntity.Text);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_MultipleChoiceQuestionTemplateEntity_SurveyTemplateQuestionDtoBaseCreated()
  {
    // Arrange
    MultipleChoiceQuestionEntity multipleChoiceQuestionTemplateEntity = new();

    // Act
    SurveyTemplateQuestionDtoBase surveyTemplateQuestionDtoBase =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(multipleChoiceQuestionTemplateEntity);

    // Assert
    Assert.IsNotNull(surveyTemplateQuestionDtoBase);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_MultipleChoiceQuestionTemplateEntity_MultipleChoiceQuestionTemplateDtoCreated()
  {
    // Arrange
    MultipleChoiceQuestionEntity multipleChoiceQuestionTemplateEntity = new();

    // Act
    SurveyTemplateQuestionDtoBase surveyTemplateQuestionDtoBase =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(multipleChoiceQuestionTemplateEntity);

    // Assert
    Assert.IsInstanceOfType(surveyTemplateQuestionDtoBase, typeof(MultipleChoiceQuestionTemplateDto));
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_MultipleChoiceQuestionTemplateEntity_PropertiesFilled()
  {
    // Arrange
    MultipleChoiceQuestionEntity multipleChoiceQuestionTemplateEntity = new()
    {
      Text = Guid.NewGuid().ToString(),
      Choices = new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
    };

    // Act
    SurveyTemplateQuestionDtoBase surveyTemplateQuestionDtoBase =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(multipleChoiceQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(surveyTemplateQuestionDtoBase.Text, multipleChoiceQuestionTemplateEntity.Text);
    Assert.AreEqual(((MultipleChoiceQuestionTemplateDto)surveyTemplateQuestionDtoBase).Choices.Length, multipleChoiceQuestionTemplateEntity.Choices.Length);

    for (int i = 0; i < multipleChoiceQuestionTemplateEntity.Choices.Length; i++)
    {
      Assert.AreEqual(((MultipleChoiceQuestionTemplateDto)surveyTemplateQuestionDtoBase).Choices[i], multipleChoiceQuestionTemplateEntity.Choices[i]);
    }
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_SingleChoiceQuestionTemplateEntity_SurveyTemplateQuestionDtoBaseCreated()
  {
    // Arrange
    SingleChoiceQuestionEntity singleChoiceQuestionTemplateEntity = new();

    // Act
    SurveyTemplateQuestionDtoBase surveyTemplateQuestionDtoBase =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(singleChoiceQuestionTemplateEntity);

    // Assert
    Assert.IsNotNull(surveyTemplateQuestionDtoBase);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_SingleChoiceQuestionTemplateEntity_SingleChoiceQuestionTemplateDtoCreated()
  {
    // Arrange
    SingleChoiceQuestionEntity singleChoiceQuestionTemplateEntity = new();

    // Act
    SurveyTemplateQuestionDtoBase surveyTemplateQuestionDtoBase =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(singleChoiceQuestionTemplateEntity);

    // Assert
    Assert.IsInstanceOfType(surveyTemplateQuestionDtoBase, typeof(SingleChoiceQuestionTemplateDto));
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_SingleChoiceQuestionTemplateEntity_PropertiesFilled()
  {
    // Arrange
    SingleChoiceQuestionEntity singleChoiceQuestionTemplateEntity = new()
    {
      Text = Guid.NewGuid().ToString(),
      Choices = new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
    };

    // Act
    SurveyTemplateQuestionDtoBase surveyTemplateQuestionDtoBase =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(singleChoiceQuestionTemplateEntity);

    // Assert
    Assert.AreEqual(surveyTemplateQuestionDtoBase.Text, singleChoiceQuestionTemplateEntity.Text);
    Assert.AreEqual(((SingleChoiceQuestionTemplateDto)surveyTemplateQuestionDtoBase).Choices.Length, singleChoiceQuestionTemplateEntity.Choices.Length);

    for (int i = 0; i < singleChoiceQuestionTemplateEntity.Choices.Length; i++)
    {
      Assert.AreEqual(((SingleChoiceQuestionTemplateDto)surveyTemplateQuestionDtoBase).Choices[i], singleChoiceQuestionTemplateEntity.Choices[i]);
    }
  }

  [TestMethod]
  public void ToQuestionTemplateEntityCollection_SurveyTemplateDtoCollection_EntityListCreated()
  {
    // Arrange
    SurveyTemplateQuestionDtoBase[] surveyTemplateQuestionDtoCollection = new SurveyTemplateQuestionDtoBase[]
    {
      new YesNoQuestionTemplateDto
      {
        QuestionType = SurveyQuestionType.YesNo,
        Text = Guid.NewGuid().ToString(),
      },
      new TextQuestionTemplateDto
      {
        QuestionType = SurveyQuestionType.Text,
        Text = Guid.NewGuid().ToString(),
      },
      new MultipleChoiceQuestionTemplateDto
      {
        QuestionType = SurveyQuestionType.MultipleChoice,
        Text = Guid.NewGuid().ToString(),
        Choices = new[]
        {
          Guid.NewGuid().ToString(),
          Guid.NewGuid().ToString(),
        },
      },
      new SingleChoiceQuestionTemplateDto
      {
        QuestionType = SurveyQuestionType.SingleChoice,
        Text = Guid.NewGuid().ToString(),
        Choices = new[]
        {
          Guid.NewGuid().ToString(),
          Guid.NewGuid().ToString(),
        },
      },
    };

    // Act
    List<SurveyQuestionEntityBase> questionTemplateEntityBaseCollection =
      SurveyTemplateQuestionDtoBase.ToQuestionTemplateEntityCollection(surveyTemplateQuestionDtoCollection);

    // Assert
    Assert.AreEqual(surveyTemplateQuestionDtoCollection.Length, questionTemplateEntityBaseCollection.Count);

    for (int i = 0; i < surveyTemplateQuestionDtoCollection.Length; i++)
    {
      AreEqual(surveyTemplateQuestionDtoCollection[i], questionTemplateEntityBaseCollection[i]);
    }
  }

  private void AreEqual(SurveyTemplateQuestionDtoBase expected, SurveyQuestionEntityBase actual)
  {
    Assert.AreEqual(expected.QuestionType, actual.QuestionType);
    Assert.AreEqual(expected.Text, actual.Text);

    if (expected.QuestionType == SurveyQuestionType.MultipleChoice)
    {
      AreChoicesEqual(((MultipleChoiceQuestionTemplateDto)expected).Choices, ((MultipleChoiceQuestionEntity)actual).Choices);
    }

    if (expected.QuestionType == SurveyQuestionType.SingleChoice)
    {
      AreChoicesEqual(((SingleChoiceQuestionTemplateDto)expected).Choices, ((SingleChoiceQuestionEntity)actual).Choices);
    }
  }

  private void AreChoicesEqual(string[] expected, string[] actual)
  {
    Assert.AreEqual(expected.Length, actual.Length);

    for (int i = 0; i < expected.Length; i++)
    {
      Assert.AreEqual(expected[i], actual[i]);
    }
  }
}
