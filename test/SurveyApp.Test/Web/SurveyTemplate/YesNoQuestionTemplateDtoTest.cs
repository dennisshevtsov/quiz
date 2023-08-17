﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class YesNoQuestionTemplateDtoTest
{
  [TestMethod]
  public void ToQuestionTemplateEntity_YesNoQuestionTemplateDto_YesNoQuestionTemplateEntityReturned()
  {
    // Arrange
    YesNoQuestionTemplateDto yesNoQuestionTemplateDto = new();

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = yesNoQuestionTemplateDto.ToQuestionTemplateEntity();

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(YesNoQuestionTemplateEntity));
  }
}
