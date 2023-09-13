// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class AddSurveyRequestDtoTest
{
  [TestMethod]
  public void ToSurveyEntity_AddSurveyRequestDto_SurveyEntityCreated()
  {
    // Arrange
    AddSurveyRequestDto addSurveyRequestDto = new()
    {
      Title         = Guid.NewGuid().ToString(),
      Description   = Guid.NewGuid().ToString(),
      CandidateName = Guid.NewGuid().ToString(),
      Questions     = new QuestionDtoBase[]
      {
        new TextQuestionDto(),
        new YesNoQuestionDto(),
      },
    };

    // Act
    SurveyEntity surveyEntity = addSurveyRequestDto.ToSurveyEntity();

    // Assert
    Assert.AreEqual(addSurveyRequestDto.Title, surveyEntity.Title);
    Assert.AreEqual(addSurveyRequestDto.Description, surveyEntity.Description);
    Assert.AreEqual(addSurveyRequestDto.CandidateName, surveyEntity.CandidateName);
    Assert.AreEqual(addSurveyRequestDto.Questions.Length, surveyEntity.Questions.Length);
  }
}
