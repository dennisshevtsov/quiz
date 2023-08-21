// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class SurveyTemplateQuestionDtoBaseTest
{
  [TestMethod]
  public void FromQuestionTemplateEntity_TextQuestionTemplateEntity_SurveyTemplateQuestionDtoCreated()
  {
    // Arrange
    TextQuestionTemplateEntity textQuestionTemplateEntity = new();

    // Act
    SurveyTemplateQuestionDtoBase getSurveyTemplateResponseDto =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(textQuestionTemplateEntity);

    // Assert
    Assert.IsNotNull(getSurveyTemplateResponseDto);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_YesNoQuestionTemplateEntity_SurveyTemplateQuestionDtoCreated()
  {
    // Arrange
    YesNoQuestionTemplateEntity yesNoQuestionTemplateEntity = new();

    // Act
    SurveyTemplateQuestionDtoBase getSurveyTemplateResponseDto =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(yesNoQuestionTemplateEntity);

    // Assert
    Assert.IsNotNull(getSurveyTemplateResponseDto);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_MultipleChoiceQuestionTemplateEntity_SurveyTemplateQuestionDtoCreated()
  {
    // Arrange
    MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity = new();

    // Act
    SurveyTemplateQuestionDtoBase getSurveyTemplateResponseDto =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(multipleChoiceQuestionTemplateEntity);

    // Assert
    Assert.IsNotNull(getSurveyTemplateResponseDto);
  }

  [TestMethod]
  public void FromQuestionTemplateEntity_SingleChoiceQuestionTemplateEntity_SurveyTemplateQuestionDtoCreated()
  {
    // Arrange
    SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity = new();

    // Act
    SurveyTemplateQuestionDtoBase getSurveyTemplateResponseDto =
      SurveyTemplateQuestionDtoBase.FromQuestionTemplateEntity(singleChoiceQuestionTemplateEntity);

    // Assert
    Assert.IsNotNull(getSurveyTemplateResponseDto);
  }
}
