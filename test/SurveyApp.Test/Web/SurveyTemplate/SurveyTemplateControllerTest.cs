// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

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
    Guid surveyTemplateId = Guid.NewGuid();

    _surveyTemplateRepositoryMock.Setup(repository => repository.GetSurveyTemplateAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(new SurveyTemplateEntity());

    // Act
    IActionResult actionResult = await _surveyTemplateController.GetSurveyTemplate(
      surveyTemplateId, CancellationToken.None);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
  }
}
