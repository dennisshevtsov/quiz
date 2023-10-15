// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.SurveyTemplate;
using SurveyApp.Survey.Test;

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class SurveyControllerTest
{
#pragma warning disable CS8618
  private Mock<ISurveyRepository> _surveyRepositoryMock;
  private Mock<ISurveyTemplateRepository> _surveyTemplateRepositoryMock;
  private SurveyController _surveyController;
#pragma warning restore CS8618

  [TestInitialize]
  public void Initialize()
  {
    _surveyRepositoryMock         = new Mock<ISurveyRepository>();
    _surveyTemplateRepositoryMock = new Mock<ISurveyTemplateRepository>(); 
    _surveyController             = new SurveyController(_surveyRepositoryMock.Object, _surveyTemplateRepositoryMock.Object);
  }

  [TestMethod]
  public async Task GetSurvey_ExistingSurveyId_OkObjectResultReturned()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(SurveyEntityTest.CreateTestSurvey());

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
                         .ReturnsAsync(SurveyEntityTest.CreateTestSurvey());

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

  [TestMethod]
  public async Task GetSurvey_UnknownSurveyId_NotFoundReturned()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(default(SurveyEntity));

    GetSurveyRequestDto getSurveyRequestDto = new();

    // Act
    IActionResult actionResult = await _surveyController.GetSurvey(
      getSurveyRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
  }

  [TestMethod]
  public async Task AddSurvey_AddSurveyRequestDto_GetSurveyTemplateAsync()
  {
    // Arrange
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(default(SurveyTemplateEntity));

    AddSurveyRequestDto addSurveyRequestDto = new()
    {
      SurveyTemplateId = Guid.NewGuid(),
    };

    // Act
    await _surveyController.AddSurvey(addSurveyRequestDto, CancellationToken.None);

    // Assert
    Expression<Func<Guid, bool>> match = id => id == addSurveyRequestDto.SurveyTemplateId;
    _surveyTemplateRepositoryMock.Verify(repository => repository.GetSurveyTemplateAsync(It.Is(match), It.IsAny<CancellationToken>()));
  }

  [TestMethod]
  public async Task AddSurvey_UnknownSurveyTemplate_NotFoundReturned()
  {
    // Arrange
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(default(SurveyTemplateEntity));

    AddSurveyRequestDto addSurveyRequestDto = new();

    // Act
    IActionResult actionResult = await _surveyController.AddSurvey(
      addSurveyRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType<NotFoundResult>(actionResult);
  }

  [TestMethod]
  public async Task AddSurvey_ExistingSurveyTemplate_AddSurveyAsyncCalled()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title: Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions: Array.Empty<QuestionTemplateEntityBase>(),
      context: new ExecutingContext()
    )!;
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    _surveyRepositoryMock.Setup(repository => repository.AddSurveyAsync(It.IsAny<SurveyEntity>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((SurveyEntity surveyEntity, CancellationToken cancellationToken) => surveyEntity);

    AddSurveyRequestDto addSurveyRequestDto = new()
    {
      IntervieweeName = Guid.NewGuid().ToString(),
    };

    // Act
    await _surveyController.AddSurvey(addSurveyRequestDto, CancellationToken.None);

    // Assert
    Expression<Func<SurveyEntity, bool>> match =
      entity => entity.Title == surveyTemplateEntity.Title &&
                entity.Description == surveyTemplateEntity.Description;

    _surveyRepositoryMock.Verify(repository => repository.AddSurveyAsync(It.Is(match), It.IsAny<CancellationToken>()));
  }

  [TestMethod]
  public async Task AddSurvey_ExistingSurveyTemplate_CreatedAtActionResultReturned()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : new ExecutingContext()
    )!;
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    _surveyRepositoryMock.Setup(repository => repository.AddSurveyAsync(It.IsAny<SurveyEntity>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((SurveyEntity surveyEntity, CancellationToken cancellationToken) => surveyEntity);

    AddSurveyRequestDto addSurveyRequestDto = new()
    {
      IntervieweeName = Guid.NewGuid().ToString(),
    };

    // Act
    IActionResult actionResult = await _surveyController.AddSurvey(
      addSurveyRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(CreatedAtActionResult));
  }

  [TestMethod]
  public async Task AddSurvey_NoIntervieweeName_BadRequestReturned()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : new ExecutingContext()
    )!;
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    _surveyRepositoryMock.Setup(repository => repository.AddSurveyAsync(It.IsAny<SurveyEntity>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((SurveyEntity surveyEntity, CancellationToken cancellationToken) => surveyEntity);

    AddSurveyRequestDto addSurveyRequestDto = new()
    {
      IntervieweeName = string.Empty,
    };

    // Act
    IActionResult actionResult = await _surveyController.AddSurvey(
      addSurveyRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
  }

  [TestMethod]
  public async Task AddSurvey_ExistingSurveyTemplate_ActionNamePopulated()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : new ExecutingContext()
    )!;
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    _surveyRepositoryMock.Setup(repository => repository.AddSurveyAsync(It.IsAny<SurveyEntity>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((SurveyEntity surveyEntity, CancellationToken cancellationToken) => surveyEntity);

    AddSurveyRequestDto addSurveyRequestDto = new()
    {
      IntervieweeName = Guid.NewGuid().ToString(),
    };

    // Act
    IActionResult actionResult = await _surveyController.AddSurvey(
      addSurveyRequestDto, CancellationToken.None);

    // Assert
    Assert.AreEqual(nameof(SurveyController.GetSurvey), ((CreatedAtActionResult)actionResult).ActionName);
  }

  [TestMethod]
  public async Task AddSurvey_ExistingSurveyTemplate_RouteValuesPopulated()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New
    (
      title      : Guid.NewGuid().ToString(),
      description: Guid.NewGuid().ToString(),
      questions  : Array.Empty<QuestionTemplateEntityBase>(),
      context    : new ExecutingContext()
    )!;
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    _surveyRepositoryMock.Setup(repository => repository.AddSurveyAsync(It.IsAny<SurveyEntity>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((SurveyEntity surveyEntity, CancellationToken cancellationToken) => surveyEntity);

    AddSurveyRequestDto addSurveyRequestDto = new()
    {
      IntervieweeName = Guid.NewGuid().ToString(),
    };

    // Act
    IActionResult actionResult = await _surveyController.AddSurvey(
      addSurveyRequestDto, CancellationToken.None);

    // Assert
    CreatedAtActionResult createdAtActionResult = (CreatedAtActionResult)actionResult;

    Assert.IsNotNull(createdAtActionResult.RouteValues);
    Assert.IsTrue(createdAtActionResult.RouteValues.ContainsKey("surveyId"));
  }

  [TestMethod]
  public async Task UpdateSurvey_UpdateSurveyRequestDto_GetSurveyAsyncCalled()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .Verifiable();

    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      SurveyId = Guid.NewGuid(),
    };

    // Act
    await _surveyController.UpdateSurvey(updateSurveyRequestDto, CancellationToken.None);

    // Assert
    Expression<Func<Guid, bool>> match = id => id == updateSurveyRequestDto.SurveyId;
    _surveyRepositoryMock.Verify(repository => repository.GetSurveyAsync(It.Is(match), It.IsAny<CancellationToken>()));
  }

  [TestMethod]
  public async Task UpdateSurvey_UnknownSurvey_NotFoundReturned()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(default(SurveyEntity));

    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      SurveyId = Guid.NewGuid(),
    };

    // Act
    IActionResult actionResult = await _surveyController.UpdateSurvey(updateSurveyRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
  }

  [TestMethod]
  public async Task UpdateSurvey_ExistingSurvey_NoContentReturned()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(SurveyEntityTest.CreateTestSurvey());

    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      IntervieweeName = Guid.NewGuid().ToString(),
    };

    // Act
    IActionResult actionResult = await _surveyController.UpdateSurvey(updateSurveyRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
  }

  [TestMethod]
  public async Task UpdateSurvey_InvalidRequestDto_BadRequestReturned()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(SurveyEntityTest.CreateTestSurvey());

    UpdateSurveyRequestDto updateSurveyRequestDto = new();

    // Act
    IActionResult actionResult = await _surveyController.UpdateSurvey(updateSurveyRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
  }

  [TestMethod]
  public async Task UpdateSurvey_InvalidRequestDto_UpdateSurveyAsyncNotCalled()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(SurveyEntityTest.CreateTestSurvey());

    UpdateSurveyRequestDto updateSurveyRequestDto = new();

    // Act
    await _surveyController.UpdateSurvey(updateSurveyRequestDto, CancellationToken.None);

    // Assert
    _surveyRepositoryMock.Verify(repository => repository.UpdateSurveyAsync(It.IsAny<SurveyEntity>(), It.IsAny<CancellationToken>()), Times.Never);
  }

  [TestMethod]
  public async Task UpdateSurvey_ExistingSurvey_UpdateSurveyAsyncCalled()
  {
    // Arrange
    Guid surveyId = Guid.NewGuid();

    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(SurveyEntityTest.CreateTestSurvey(surveyId: surveyId));

    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      SurveyId      = surveyId,
      IntervieweeName = Guid.NewGuid().ToString(),
    };

    // Act
    await _surveyController.UpdateSurvey(updateSurveyRequestDto, CancellationToken.None);

    // Assert
    Expression<Func<SurveyEntity, bool>> match =
      entity => entity.SurveyId         == surveyId &&
                entity.IntervieweeName  == updateSurveyRequestDto.IntervieweeName;

    _surveyRepositoryMock.Verify(repository => repository.UpdateSurveyAsync(It.Is(match), It.IsAny<CancellationToken>()));
  }

  [TestMethod]
  public async Task MoveToState_UnknownSurvey_NotFoundReturned()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(default(SurveyEntity));

    Guid surveyId = Guid.NewGuid();
    SurveyState state = SurveyState.Draft;

    // Act
    IActionResult actionResult = await _surveyController.MoveToState(surveyId, state, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
  }

  [TestMethod]
  public async Task MoveToState_UnacceptableSurveyState_BadRequestReturned()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(SurveyEntityTest.CreateTestSurvey(state: SurveyState.Done));

    Guid surveyId = Guid.NewGuid();
    SurveyState state = SurveyState.Cancelled;

    // Act
    IActionResult actionResult = await _surveyController.MoveToState(surveyId, state, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
  }

  [TestMethod]
  public async Task MoveToState_AcceptableSurveyState_NoContentReturned()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(SurveyEntityTest.CreateTestSurvey(state: SurveyState.Ready));

    Guid surveyId = Guid.NewGuid();
    SurveyState state = SurveyState.Done;

    // Act
    IActionResult actionResult = await _surveyController.MoveToState(surveyId, state, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
  }

  [TestMethod]
  public async Task MoveToState_AcceptableSurveyState_UpdateSurveyAsyncCalled()
  {
    // Arrange
    Guid surveyId = Guid.NewGuid();
    SurveyState state = SurveyState.Done;

    SurveyEntity surveyEntity = SurveyEntityTest.CreateTestSurvey
    (
      surveyId: surveyId,
      state: SurveyState.Ready
    );

    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(surveyEntity);

    // Act
    IActionResult actionResult = await _surveyController.MoveToState(surveyId, state, CancellationToken.None);

    // Assert
    Expression<Func<SurveyEntity, bool>> match = entity => entity.SurveyId == surveyId && entity.State == state;
    _surveyRepositoryMock.Verify(repository => repository.UpdateSurveyAsync(It.Is(match), It.IsAny<CancellationToken>()));
  }

  [TestMethod]
  public async Task Answer_UnknownSurvey_NotFoundReturned()
  {
    // Arrange
    _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(default(SurveyEntity));

    AnswerQuestionsRequestDto requestDto = new();

    // Act
    IActionResult actionResult = await _surveyController.Answer(requestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
  }
}
