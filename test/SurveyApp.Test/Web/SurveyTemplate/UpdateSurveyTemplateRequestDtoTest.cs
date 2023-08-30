// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyQuestion;
using SurveyApp.Web.SurveyQuestion;

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class UpdateSurveyTemplateRequestDtoTest
{
  [TestMethod]
  public void UpdateSurveyTemplate_SurveyTemplateEntity_SurveyTemplateEntityUpdated()
  {
    // Arrange
    UpdateSurveyTemplateRequestDto updateSurveyTemplateRequestDto = new()
    {
      Title = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
      Questions = new SurveyTemplateQuestionDtoBase[]
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
      },
    };

    Guid surveyTemplateId = Guid.NewGuid();

    SurveyTemplateEntity surveyTemplateEntity = new()
    {
      SurveyTemplateId = surveyTemplateId,
      Title = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
      Questions = new List<SurveyQuestionEntityBase>
      {
        new MultipleChoiceQuestionEntity
        {
          Text = Guid.NewGuid().ToString(),
          Choices = new[]
          {
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
          },
        },
        new SingleChoiceQuestionEntity
        {
          Text = Guid.NewGuid().ToString(),
          Choices = new[]
          {
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
          },
        },
      },
    };

    // Act
    updateSurveyTemplateRequestDto.UpdateSurveyTemplate(surveyTemplateEntity);

    // Assert
    Assert.AreEqual(surveyTemplateId, surveyTemplateEntity.SurveyTemplateId);
    Assert.AreEqual(updateSurveyTemplateRequestDto.Title, surveyTemplateEntity.Title);
    Assert.AreEqual(updateSurveyTemplateRequestDto.Description, surveyTemplateEntity.Description);
    Assert.AreEqual(updateSurveyTemplateRequestDto.Questions.Length, surveyTemplateEntity.Questions.Count);
  }
}
