// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class AddSurveyTemplateRequestDtoTest
{
  [TestMethod]
  public void ToSurveyTemplateEntity_AddSurveyTemplateRequestDto_SurveyTemplateEntityCreated()
  {
    // Arrange
    AddSurveyTemplateRequestDto addSurveyTemplateRequestDto = new()
    {
      Title       = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
    };

    // Act
    ExecutedContext<SurveyTemplateEntity> newSurveyTemplateEntityContext = addSurveyTemplateRequestDto.ToSurveyTemplateEntity();

    // Assert
    Assert.AreEqual(addSurveyTemplateRequestDto.Title, newSurveyTemplateEntityContext.Rusult!.Title);
    Assert.AreEqual(addSurveyTemplateRequestDto.Description, newSurveyTemplateEntityContext.Rusult!.Description);
    Assert.AreEqual(addSurveyTemplateRequestDto.Questions.Length, newSurveyTemplateEntityContext.Rusult!.Questions.Length);
  }
}
