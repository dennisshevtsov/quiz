// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class SurveyTemplateQuestionDtoBaseTest
{
  [TestMethod]
  public void FromQuestionTemplateEntity_TextQuestionTemplateEntity_SurveyTemplateQuestionDtoBaseCreated()
  {
    // Arrange
    TextQuestionTemplateEntity textQuestionTemplateEntity = new();

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
    TextQuestionTemplateEntity textQuestionTemplateEntity = new();

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
    TextQuestionTemplateEntity textQuestionTemplateEntity = new()
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
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = new();

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
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = new();

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
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = new()
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
    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = new();

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
    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = new();

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
    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = new()
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
    SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity = new();

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
    SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity = new();

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
    SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity = new()
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
    Assert.AreEqual(((MultipleChoiceQuestionTemplateDto)surveyTemplateQuestionDtoBase).Choices.Length, singleChoiceQuestionTemplateEntity.Choices.Length);

    for (int i = 0; i < singleChoiceQuestionTemplateEntity.Choices.Length; i++)
    {
      Assert.AreEqual(((MultipleChoiceQuestionTemplateDto)surveyTemplateQuestionDtoBase).Choices[i], singleChoiceQuestionTemplateEntity.Choices[i]);
    }
  }
}
