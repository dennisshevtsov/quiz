// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Linq.Expressions;

using Microsoft.AspNetCore.Mvc;
using SurveyApp.Survey.Web;

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class SurveyControllerTest
{
#pragma warning disable CS8618
  private Mock<ISurveyRepository> _surveyRepositoryMock;
  private SurveyController _surveyController;
#pragma warning restore CS8618

  [TestInitialize]
  public void Initialize()
  {
    _surveyRepositoryMock = new Mock<ISurveyRepository>();
    _surveyController     = new SurveyController(_surveyRepositoryMock.Object);
  }

  [TestMethod]
  public async Task AddSurvey_AddSurveyRequestDto_AddSurveyAsyncCalled()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.AddSurveyAsync(It.IsAny<SurveyEntity>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(new SurveyEntity(string.Empty, string.Empty, string.Empty, Array.Empty<QuestionEntityBase>()));

    AddSurveyRequestDto addSurveyRequestDto = new()
    {
      Title         = Guid.NewGuid().ToString(),
      Description   = Guid.NewGuid().ToString(),
      CandidateName = Guid.NewGuid().ToString(),
      Questions     = new QuestionDtoBase[]
      {
        new TextQuestionDto
        {
          QuestionType = QuestionType.Text,
          Text         = Guid.NewGuid().ToString(),
        },
        new YesNoQuestionDto
        {
          QuestionType = QuestionType.YesNo,
          Text         = Guid.NewGuid().ToString(),
        },
      },
    };

    // Act
    IActionResult actionResult = await _surveyController.AddSurvey(
      addSurveyRequestDto, CancellationToken.None);

    // Assert
    Expression<Func<SurveyEntity, bool>> match =
      entity => entity.Title            == addSurveyRequestDto.Title &&
                entity.Description      == addSurveyRequestDto.Description &&
                entity.CandidateName    == addSurveyRequestDto.CandidateName &&
                entity.Questions.Length == addSurveyRequestDto.Questions.Length;

    _surveyRepositoryMock.Verify(repository => repository.AddSurveyAsync(It.Is(match), It.IsAny<CancellationToken>()));
  }

  [TestMethod]
  public async Task AddSurvey_AddSurveyRequestDto_CreatedAtActionResultReturned()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.AddSurveyAsync(It.IsAny<SurveyEntity>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(new SurveyEntity(string.Empty, string.Empty, string.Empty, Array.Empty<QuestionEntityBase>()));

    AddSurveyRequestDto addSurveyRequestDto = new();

    // Act
    IActionResult actionResult = await _surveyController.AddSurvey(
      addSurveyRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(CreatedAtActionResult));
  }

  [TestMethod]
  public async Task AddSurvey_AddSurveyRequestDto_ActionNamePopulated()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.AddSurveyAsync(It.IsAny<SurveyEntity>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(new SurveyEntity(string.Empty, string.Empty, string.Empty, Array.Empty<QuestionEntityBase>()));

    AddSurveyRequestDto addSurveyRequestDto = new();

    // Act
    IActionResult actionResult = await _surveyController.AddSurvey(
      addSurveyRequestDto, CancellationToken.None);

    // Assert
    Assert.AreEqual(nameof(SurveyController.GetSurvey), ((CreatedAtActionResult)actionResult).ActionName);
  }

  [TestMethod]
  public async Task AddSurvey_AddSurveyRequestDto_RouteValuesPopulated()
  {
    // Arrange
    Guid surveyId = Guid.NewGuid();

    _surveyRepositoryMock.Setup(repository => repository.AddSurveyAsync(It.IsAny<SurveyEntity>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(new SurveyEntity(surveyId, SurveyState.Draft, string.Empty, string.Empty, string.Empty, Array.Empty<QuestionEntityBase>()));

    AddSurveyRequestDto addSurveyRequestDto = new();

    // Act
    IActionResult actionResult = await _surveyController.AddSurvey(
      addSurveyRequestDto, CancellationToken.None);

    // Assert
    CreatedAtActionResult createdAtActionResult = (CreatedAtActionResult)actionResult;

    Assert.IsNotNull(createdAtActionResult.RouteValues);
    Assert.AreEqual(surveyId, createdAtActionResult.RouteValues["surveyId"]);
  }

  [TestMethod]
  public async Task GetSurvey_ExistingSurveyId_OkObjectResultReturned()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(new SurveyEntity(string.Empty, string.Empty, string.Empty, Array.Empty<QuestionEntityBase>()));

    GetSurveyRequestDto getSurveyRequestDto = new();

    // Act
    IActionResult actionResult = await _surveyController.GetSurvey(
      getSurveyRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
  }

  [TestMethod]
  public async Task GetSurvey_ExistingSurveyId_GetSurveyResponseDtoReturned()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(new SurveyEntity(string.Empty, string.Empty, string.Empty, Array.Empty<QuestionEntityBase>()));

    GetSurveyRequestDto getSurveyRequestDto = new();

    // Act
    IActionResult actionResult = await _surveyController.GetSurvey(
      getSurveyRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(((ObjectResult)actionResult).Value, typeof(GetSurveyResponseDto));
  }

  [TestMethod]
  public async Task GetSurvey_ExistingSurveyId_GetSurveyAsyncCalled()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .Verifiable();

    Guid surveyId = Guid.NewGuid();
    GetSurveyRequestDto getSurveyRequestDto = new()
    {
      SurveyId = surveyId,
    };

    // Act
    await _surveyController.GetSurvey(
      getSurveyRequestDto, CancellationToken.None);

    // Assert
    Expression<Func<Guid, bool>> surveyIdMatch = id => id == surveyId;
    _surveyRepositoryMock.Verify(repository => repository.GetSurveyAsync(It.Is(surveyIdMatch), It.IsAny<CancellationToken>()));
  }
}
