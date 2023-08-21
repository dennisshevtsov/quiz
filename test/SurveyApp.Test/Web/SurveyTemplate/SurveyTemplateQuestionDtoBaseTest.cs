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
}
