// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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
}
