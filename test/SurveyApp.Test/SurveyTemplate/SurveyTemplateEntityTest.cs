// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Test;

[TestClass]
public sealed class SurveyTemplateEntityTest
{
  [TestMethod]
  public void Constructor_FullListOfParameters_SurveyTemplateIdFilled()
  {
    // Arrange
    Guid surveyTemplateId = Guid.NewGuid();

    // Act
    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: surveyTemplateId,
      title           : string.Empty,
      description     : string.Empty,
      questions       : Array.Empty<QuestionTemplateEntityBase>()
    );

    // Assert
    Assert.AreEqual(surveyTemplateId, surveyTemplateEntity.SurveyTemplateId);
  }

  [TestMethod]
  public void Constructor_FullListOfParameters_TitleFilled()
  {
    // Arrange
    string title = Guid.NewGuid().ToString();

    // Act
    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: default,
      title           : title,
      description     : string.Empty,
      questions       : Array.Empty<QuestionTemplateEntityBase>()
    );

    // title
    Assert.AreEqual(title, surveyTemplateEntity.Title);
  }

  [TestMethod]
  public void Constructor_FullListOfParameters_DescriptionFilled()
  {
    // Arrange
    string description = Guid.NewGuid().ToString();

    // Act
    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: default,
      title           : string.Empty,
      description     : description,
      questions       : Array.Empty<QuestionTemplateEntityBase>()
    );

    // title
    Assert.AreEqual(description, surveyTemplateEntity.Description);
  }

  [TestMethod]
  public void Constructor_FullListOfParameters_QuestionsFilled()
  {
    // Arrange
    QuestionTemplateEntityBase[] questions = new QuestionTemplateEntityBase[0];

    // Act
    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: default,
      title           : string.Empty,
      description     : string.Empty,
      questions       : questions
    );

    // title
    Assert.AreEqual(questions, surveyTemplateEntity.Questions);
  }
}
