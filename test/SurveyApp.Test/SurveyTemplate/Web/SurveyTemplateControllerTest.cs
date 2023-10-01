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
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

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
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

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
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    _surveyTemplateRepositoryMock.Setup(repository => repository.AddSurveyTemplateAsync(It.IsAny<SurveyTemplateEntity>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    AddSurveyTemplateRequestDto addSurveyTemplateRequestDto = new()
    {
      Title = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
      Questions = new QuestionTemplateDtoBase[]
      {
        new TextQuestionTemplateDto
        {
          QuestionType = QuestionType.Text,
          Text = Guid.NewGuid().ToString(),
        },
        new YesNoQuestionTemplateDto
        {
          QuestionType = QuestionType.YesNo,
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
                entity.Questions.Length == addSurveyTemplateRequestDto.Questions.Length;

    _surveyTemplateRepositoryMock.Verify(repository => repository.AddSurveyTemplateAsync(It.Is(match), It.IsAny<CancellationToken>()));
  }

  [TestMethod]
  public async Task AddSurveyTemplate_AddSurveyTemplateRequestDto_CreatedAtActionResultReturned()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    _surveyTemplateRepositoryMock.Setup(repository => repository.AddSurveyTemplateAsync(It.IsAny<SurveyTemplateEntity>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    AddSurveyTemplateRequestDto addSurveyTemplateRequestDto = new()
    {
      Title = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
    };

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
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    _surveyTemplateRepositoryMock.Setup(repository => repository.AddSurveyTemplateAsync(It.IsAny<SurveyTemplateEntity>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    AddSurveyTemplateRequestDto addSurveyTemplateRequestDto = new()
    {
      Title       = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
    };

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
                                 .ReturnsAsync(new SurveyTemplateEntity(surveyTemplateId, string.Empty, string.Empty, Array.Empty<QuestionTemplateEntityBase>()));

    AddSurveyTemplateRequestDto addSurveyTemplateRequestDto = new()
    {
      Title = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
    };

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
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));

    UpdateSurveyTemplateRequestDto updateSurveyTemplateRequestDto = new()
    {
      SurveyTemplateId = Guid.NewGuid(),
    };

    // Act
    IActionResult actionResult = await _surveyTemplateController.UpdateSurveyTemplate(updateSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
  }

  [TestMethod]
  public async Task UpdateSurveyTemplate_ExistingSurveyTemplate_NoContentReturned()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    UpdateSurveyTemplateRequestDto updateSurveyTemplateRequestDto = new()
    {
      Title       = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
    };

    // Act
    IActionResult actionResult = await _surveyTemplateController.UpdateSurveyTemplate(updateSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
  }

  [TestMethod]
  public async Task UpdateSurveyTemplate_ExistingSurveyTemplate_UpdateSurveyTemplateAsyncCalled()
  {
    // Arrange
    Guid surveyTemplateId = Guid.NewGuid();

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(new SurveyTemplateEntity(surveyTemplateId, string.Empty, string.Empty, Array.Empty<QuestionTemplateEntityBase>()));

    UpdateSurveyTemplateRequestDto updateSurveyTemplateRequestDto = new()
    {
      SurveyTemplateId = surveyTemplateId,
      Title = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
      Questions = new QuestionTemplateDtoBase[]
      {
        new TextQuestionTemplateDto
        {
          QuestionType = QuestionType.Text,
          Text = Guid.NewGuid().ToString(),
        },
        new YesNoQuestionTemplateDto
        {
          QuestionType = QuestionType.YesNo,
          Text = Guid.NewGuid().ToString(),
        },
      }
    };

    // Act
    await _surveyTemplateController.UpdateSurveyTemplate(updateSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    Expression<Func<SurveyTemplateEntity, bool>> match =
      entity => entity.SurveyTemplateId == updateSurveyTemplateRequestDto.SurveyTemplateId &&
                entity.Title == updateSurveyTemplateRequestDto.Title &&
                entity.Description == updateSurveyTemplateRequestDto.Description &&
                entity.Questions.Length == updateSurveyTemplateRequestDto.Questions.Length;

    _surveyTemplateRepositoryMock.Verify(repository => repository.UpdateSurveyTemplateAsync(It.Is(match), It.IsAny<CancellationToken>()));
  }

  [TestMethod]
  public async Task UpdateSurveyTemplate_NoTitle_BadRequestReturned()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    UpdateSurveyTemplateRequestDto updateSurveyTemplateRequestDto = new()
    {
      Title       = string.Empty,
      Description = Guid.NewGuid().ToString(),
    };

    // Act
    IActionResult actionResult = await _surveyTemplateController.UpdateSurveyTemplate(updateSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
  }

  [TestMethod]
  public async Task UpdateSurveyTemplate_NoTitle_UpdateSurveyTemplateAsyncNotCalled()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    UpdateSurveyTemplateRequestDto updateSurveyTemplateRequestDto = new()
    {
      Title       = string.Empty,
      Description = Guid.NewGuid().ToString(),
    };

    // Act
    await _surveyTemplateController.UpdateSurveyTemplate(updateSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    _surveyTemplateRepositoryMock.Verify(repository => repository.UpdateSurveyTemplateAsync(It.IsAny<SurveyTemplateEntity>(), It.IsAny<CancellationToken>()), Times.Never);
  }

  [TestMethod]
  public async Task UpdateSurveyTemplate_NoDescription_BadRequestReturned()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    UpdateSurveyTemplateRequestDto updateSurveyTemplateRequestDto = new()
    {
      Title       = Guid.NewGuid().ToString(),
      Description = string.Empty,
    };

    // Act
    IActionResult actionResult = await _surveyTemplateController.UpdateSurveyTemplate(updateSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));
  }

  [TestMethod]
  public async Task UpdateSurveyTemplate_NoDescription_UpdateSurveyTemplateAsyncNotCalled()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    UpdateSurveyTemplateRequestDto updateSurveyTemplateRequestDto = new()
    {
      Title       = Guid.NewGuid().ToString(),
      Description = string.Empty,
    };

    // Act
    await _surveyTemplateController.UpdateSurveyTemplate(updateSurveyTemplateRequestDto, CancellationToken.None);

    // Assert
    _surveyTemplateRepositoryMock.Verify(repository => repository.UpdateSurveyTemplateAsync(It.IsAny<SurveyTemplateEntity>(), It.IsAny<CancellationToken>()), Times.Never);
  }

  [TestMethod]
  public async Task DeleteSurveyTemplate_UnknownSurveyTemplate_NotFoundReturned()
  {
    // Arrange
    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(default(SurveyTemplateEntity));

    Guid surveyTemplateId = Guid.NewGuid();

    // Act
    IActionResult actionResult = await _surveyTemplateController.DeleteSurveyTemplate(surveyTemplateId, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
  }

  [TestMethod]
  public async Task DeleteSurveyTemplate_SurveyTemplateId_GetSurveyTemplateAsyncCalled()
  {
    // Arrange
    Guid surveyTemplateId = Guid.NewGuid();

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .Verifiable();

    // Act
    await _surveyTemplateController.DeleteSurveyTemplate(surveyTemplateId, CancellationToken.None);

    // Assert
    Expression<Func<Guid, bool>> match = id => id == surveyTemplateId;
    _surveyTemplateRepositoryMock.Verify(repository => repository.GetSurveyTemplateAsync(It.Is(match), It.IsAny<CancellationToken>()));
  }

  [TestMethod]
  public async Task DeleteSurveyTemplate_ExistingSurveyTemplate_NoContentReturned()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    Guid surveyTemplateId = Guid.NewGuid();

    // Act
    IActionResult actionResult = await _surveyTemplateController.DeleteSurveyTemplate(surveyTemplateId, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
  }

  [TestMethod]
  public async Task DeleteSurveyTemplate_ExistingSurveyTemplate_DeleteSurveyTemplateAsyncCalled()
  {
    // Arrange
    SurveyTemplateEntity surveyTemplateEntity = SurveyTemplateEntity.New(
       title      : Guid.NewGuid().ToString(),
       description: Guid.NewGuid().ToString(),
       questions  : Array.Empty<QuestionTemplateEntityBase>()).Rusult!;

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(surveyTemplateEntity);

    Guid surveyTemplateId = Guid.NewGuid();

    // Act
    IActionResult actionResult = await _surveyTemplateController.DeleteSurveyTemplate(surveyTemplateId, CancellationToken.None);

    // Assert
    Expression<Func<Guid, bool>> match = id => id == surveyTemplateId;
    _surveyTemplateRepositoryMock.Verify(repository => repository.DeleteSurveyTemplateAsync(It.Is(match), It.IsAny<CancellationToken>()));
  }
}
