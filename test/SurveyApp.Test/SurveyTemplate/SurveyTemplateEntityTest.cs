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

  [TestMethod]
  public void New_ShortListOfParameters_SurveyTemplateIdFilled()
  {
    // Act
    ExecutedContext<SurveyTemplateEntity> newSurveyTemplateEntityContext = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>()
    );

    // Assert
    Assert.AreNotEqual(default, newSurveyTemplateEntityContext.Rusult!.SurveyTemplateId);
  }

  [TestMethod]
  public void New_ShortListOfParameters_TitleFilled()
  {
    // Arrange
    string title = Guid.NewGuid().ToString();

    // Act
    ExecutedContext<SurveyTemplateEntity> newSurveyTemplateEntityContext = SurveyTemplateEntity.New
    (
      title      : title,
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>()
    );

    // title
    Assert.AreEqual(title, newSurveyTemplateEntityContext.Rusult!.Title);
  }

  [TestMethod]
  public void New_ShortListOfParameters_DescriptionFilled()
  {
    // Arrange
    string description = Guid.NewGuid().ToString();

    // Act
    ExecutedContext<SurveyTemplateEntity> newSurveyTemplateEntityContext = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: description,
      questions  : Array.Empty<QuestionTemplateEntityBase>()
    );

    // title
    Assert.AreEqual(description, newSurveyTemplateEntityContext.Rusult!.Description);
  }

  [TestMethod]
  public void New_ShortListOfParameters_QuestionsFilled()
  {
    // Arrange
    QuestionTemplateEntityBase[] questions = new QuestionTemplateEntityBase[0];

    // Act
    ExecutedContext<SurveyTemplateEntity> newSurveyTemplateEntityContext = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : questions
    );

    // title
    Assert.AreEqual(questions, newSurveyTemplateEntityContext.Rusult!.Questions);
  }

  [TestMethod]
  public void New_NoTitle_ErrorsReturned()
  {
    // Act
    ExecutedContext<SurveyTemplateEntity> newSurveyTemplateEntityContext = SurveyTemplateEntity.New
    (
      title      : string.Empty,
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>()
    );

    // title
    Assert.IsTrue(newSurveyTemplateEntityContext.HasErrors);
  }

  [TestMethod]
  public void New_NoDescription_ErrorsReturned()
  {
    // Act
    ExecutedContext<SurveyTemplateEntity> newSurveyTemplateEntityContext = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: string.Empty,
      questions  : Array.Empty<QuestionTemplateEntityBase>()
    );

    // title
    Assert.IsTrue(newSurveyTemplateEntityContext.HasErrors);
  }

  [TestMethod]
  public void New_ShortListOfParameters_NoErrors()
  {
    // Act
    ExecutedContext<SurveyTemplateEntity> newSurveyTemplateEntityContext = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>()
    );

    // title
    Assert.IsFalse(newSurveyTemplateEntityContext.HasErrors);
  }

  [TestMethod]
  public void Update_FullListOfParameters_TitleFilled()
  {
    // Arrange
    string title = Guid.NewGuid().ToString();

    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    // Act
    surveyTemplateEntity.Update(
      title      : title,
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>());

    // title
    Assert.AreEqual(title, surveyTemplateEntity.Title);
  }

  [TestMethod]
  public void Update_FullListOfParameters_DescriptionFilled()
  {
    // Arrange
    string description = Guid.NewGuid().ToString();

    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    // Act
    surveyTemplateEntity.Update(
      title      : Guid.NewGuid().ToString(),
      description: description,
      questions  : Array.Empty<QuestionTemplateEntityBase>());

    // title
    Assert.AreEqual(description, surveyTemplateEntity.Description);
  }

  [TestMethod]
  public void Update_FullListOfParameters_QuestionsFilled()
  {
    // Arrange
    QuestionTemplateEntityBase[] questions = new QuestionTemplateEntityBase[0];

    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    // Act
    surveyTemplateEntity.Update(
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : questions);

    // title
    Assert.AreEqual(questions, surveyTemplateEntity.Questions);
  }
}
