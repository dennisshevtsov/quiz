// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Linq.Expressions;

using Microsoft.AspNetCore.Mvc;

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class SurveyTemplateControllerTest
{
#pragma warning disable CS8618
  private Mock<ISurveyTemplateRepository> _surveyTemplateRepositoryMock;
  private SurveyTemplateController _surveyTemplateController;
#pragma warning restore CS8618

  [TestInitialize]
  public void Initialize()
  {
    _surveyTemplateRepositoryMock = new Mock<ISurveyTemplateRepository>();
    _surveyTemplateController = new SurveyTemplateController(_surveyTemplateRepositoryMock.Object);
  }

  [TestMethod]
  public async Task GetSurveyTemplate_ExistingSurveyTemplateId_OkObjectResultReturned()
  {
    // Arrange
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(new SurveyTemplateEntity());

    // Act
    IActionResult actionResult = await _surveyTemplateController.GetSurveyTemplate(
      Guid.NewGuid(), CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
  }

  [TestMethod]
  public async Task GetSurveyTemplate_ExistingSurveyTemplateId_GetSurveyTemplateResponseDtoReturned()
  {
    // Arrange
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(new SurveyTemplateEntity());

    // Act
    IActionResult actionResult = await _surveyTemplateController.GetSurveyTemplate(
      Guid.NewGuid(), CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(((ObjectResult)actionResult).Value, typeof(GetSurveyTemplateResponseDto));
  }

  [TestMethod]
  public async Task GetSurveyTemplate_ExistingSurveyTemplateId_GetSurveyTemplateAsyncCalled()
  {
    // Arrange
    Guid surveyTemplateId = Guid.NewGuid();

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .Verifiable();

    // Act
    await _surveyTemplateController.GetSurveyTemplate(
      surveyTemplateId, CancellationToken.None);

    // Assert
    Expression<Func<Guid, bool>> surveyTemplateIdMatch = id => id == surveyTemplateId;
    _surveyTemplateRepositoryMock.Verify(repository => repository.GetSurveyTemplateAsync(It.Is(surveyTemplateIdMatch), It.IsAny<CancellationToken>()));
  }

  [TestMethod]
  public async Task GetSurveyTemplate_UnknownSurveyTemplateId_NotFoundReturned()
  {
    // Arrange
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(default(SurveyTemplateEntity));

    // Act
    IActionResult actionResult = await _surveyTemplateController.GetSurveyTemplate(
      Guid.NewGuid(), CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
  }

  [TestMethod]
  public async Task AddSurveyTemplate_AddSurveyTemplateRequestDto_AddSurveyTemplateAsyncCalled()
  {
    // Arrange
    _surveyTemplateRepositoryMock.Setup(repository => repository.AddSurveyTemplateAsync(It.IsAny<SurveyTemplateEntity>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(new SurveyTemplateEntity
                                 {
                                   SurveyTemplateId = Guid.NewGuid(),
                                 });

    AddSurveyTemplateRequestDto addSurveyTemplateRequestDto = new()
    {
      Title = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
      Questions = new SurveyTemplateQuestionDtoBase[]
      {
        new TextQuestionTemplateDto
        {
          QuestionType = SurveyQuestionType.Text,
          Text = Guid.NewGuid().ToString(),
        },
        new YesNoQuestionTemplateDto
        {
          QuestionType = SurveyQuestionType.YesNo,
          Text = Guid.NewGuid().ToString(),
        },
      },
    };

    // Act
    IActionResult actionResult = await _surveyTemplateController.AddSurveyTemplate(
      addSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    Expression<Func<SurveyTemplateEntity, bool>> match =
      entity => entity.Title == addSurveyTemplateRequestDto.Title &&
                entity.Description == addSurveyTemplateRequestDto.Description &&
                entity.Questions.Count == addSurveyTemplateRequestDto.Questions.Length;

    _surveyTemplateRepositoryMock.Verify(repository => repository.AddSurveyTemplateAsync(It.Is(match), It.IsAny<CancellationToken>()));
  }

  [TestMethod]
  public async Task AddSurveyTemplate_AddSurveyTemplateRequestDto_CreatedAtActionResultReturned()
  {
    // Arrange
    _surveyTemplateRepositoryMock.Setup(repository => repository.AddSurveyTemplateAsync(It.IsAny<SurveyTemplateEntity>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(new SurveyTemplateEntity
                                 {
                                   SurveyTemplateId = Guid.NewGuid(),
                                 });

    AddSurveyTemplateRequestDto addSurveyTemplateRequestDto = new();

    // Act
    IActionResult actionResult = await _surveyTemplateController.AddSurveyTemplate(
      addSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(CreatedAtActionResult));
  }

  [TestMethod]
  public async Task AddSurveyTemplate_AddSurveyTemplateRequestDto_ActionNamePopulated()
  {
    // Arrange
    _surveyTemplateRepositoryMock.Setup(repository => repository.AddSurveyTemplateAsync(It.IsAny<SurveyTemplateEntity>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(new SurveyTemplateEntity
                                 {
                                   SurveyTemplateId = Guid.NewGuid(),
                                 });

    AddSurveyTemplateRequestDto addSurveyTemplateRequestDto = new();

    // Act
    IActionResult actionResult = await _surveyTemplateController.AddSurveyTemplate(
      addSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    Assert.AreEqual(nameof(SurveyTemplateController.GetSurveyTemplate), ((CreatedAtActionResult)actionResult).ActionName);
  }

  [TestMethod]
  public async Task AddSurveyTemplate_AddSurveyTemplateRequestDto_RouteValuesPopulated()
  {
    // Arrange
    Guid surveyTemplateId = Guid.NewGuid();

    _surveyTemplateRepositoryMock.Setup(repository => repository.AddSurveyTemplateAsync(It.IsAny<SurveyTemplateEntity>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(new SurveyTemplateEntity
                                 {
                                   SurveyTemplateId = surveyTemplateId,
                                 });

    AddSurveyTemplateRequestDto addSurveyTemplateRequestDto = new();

    // Act
    IActionResult actionResult = await _surveyTemplateController.AddSurveyTemplate(
      addSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    CreatedAtActionResult createdAtActionResult = (CreatedAtActionResult)actionResult;

    Assert.IsNotNull(createdAtActionResult.RouteValues);
    Assert.AreEqual(surveyTemplateId, createdAtActionResult.RouteValues["surveyTemplateId"]);
  }

  [TestMethod]
  public async Task UpdateSurveyTemplate_UpdateSurveyTemplateRequestDto_GetSurveyTemplateAsyncCalled()
  {
    // Arrange
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .Verifiable();

    UpdateSurveyTemplateRequestDto updateSurveyTemplateRequestDto = new()
    {
      SurveyTemplateId = Guid.NewGuid(),
    };

    // Act
    await _surveyTemplateController.UpdateSurveyTemplate(updateSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    Expression<Func<Guid, bool>> match = id => id == updateSurveyTemplateRequestDto.SurveyTemplateId;

    _surveyTemplateRepositoryMock.Verify(repository => repository.GetSurveyTemplateAsync(It.Is(match), It.IsAny<CancellationToken>()));
  }

  [TestMethod]
  public async Task UpdateSurveyTemplate_UnknownSurveyTemplate_NotFoundReturned()
  {
    // Arrange
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .Verifiable();

    UpdateSurveyTemplateRequestDto updateSurveyTemplateRequestDto = new()
    {
      SurveyTemplateId = Guid.NewGuid(),
    };

    // Act
    IActionResult actionResult = await _surveyTemplateController.UpdateSurveyTemplate(updateSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
  }
}
