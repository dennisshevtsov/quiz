// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

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
      Questions = new QuestionTemplateDtoBase[]
      {
        new YesNoQuestionTemplateDto
        {
          QuestionType = QuestionType.YesNo,
          Text = Guid.NewGuid().ToString(),
        },
        new TextQuestionTemplateDto
        {
          QuestionType = QuestionType.Text,
          Text = Guid.NewGuid().ToString(),
        },
      },
    };

    QuestionTemplateEntityBase[] questionTemplateEntityCollection = new QuestionTemplateEntityBase[]
    {
      new MultipleChoiceQuestionTemplateEntity
      (
        text   : Guid.NewGuid().ToString(),
        choices: new[]
        {
          Guid.NewGuid().ToString(),
          Guid.NewGuid().ToString(),
        }
      ),
      new SingleChoiceQuestionTemplateEntity
      (
        text   : Guid.NewGuid().ToString(),
        choices: new[]
        {
          Guid.NewGuid().ToString(),
          Guid.NewGuid().ToString(),
        }
      ),
    };

    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : questionTemplateEntityCollection).Rusult!;

    Guid surveyTemplateId = surveyTemplateEntity.SurveyTemplateId;

    // Act
    updateSurveyTemplateRequestDto.UpdateSurveyTemplate(surveyTemplateEntity);

    // Assert
    Assert.AreEqual(surveyTemplateId, surveyTemplateEntity.SurveyTemplateId);
    Assert.AreEqual(updateSurveyTemplateRequestDto.Title, surveyTemplateEntity.Title);
    Assert.AreEqual(updateSurveyTemplateRequestDto.Description, surveyTemplateEntity.Description);
    Assert.AreEqual(updateSurveyTemplateRequestDto.Questions.Length, surveyTemplateEntity.Questions.Length);
  }
}
