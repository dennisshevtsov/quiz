// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Web.Controllers.Test
{
  using Microsoft.AspNetCore.Mvc;

  using Survey.Domain.Entities;
  using Survey.Domain.Services;
  using Survey.Web.ViewModels;

  [TestClass]
  public sealed class SurveyControllerTest
  {
#pragma warning disable CS8618
    private Mock<ISurveyService> _surveyServiceMock;

    private SurveyController _surveyController;
#pragma warning restore CS8618

    [TestInitialize]
    public void Initialize()
    {
      _surveyServiceMock = new Mock<ISurveyService>();

      _surveyController = new SurveyController(_surveyServiceMock.Object);
    }

    [TestMethod]
    public async Task AddSurvey_Should_Save_Survey()
    {
      _surveyServiceMock.Setup(service => service.AddNewSurveyAsync(It.IsAny<ISurveyData>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(new TestSurveyEntity())
                        .Verifiable();

      var vm = new AddSurveyViewModel
      {
        Name = Guid.NewGuid().ToString(),
        Description = Guid.NewGuid().ToString(),
      };

      var actionResult = await _surveyController.AddSurvey(vm, CancellationToken.None);

      Assert.IsNotNull(actionResult);

      var createdAtRouteResult = actionResult as CreatedAtRouteResult;

      Assert.IsNotNull(createdAtRouteResult);
      Assert.AreEqual(nameof(SurveyController.GetSurvey), createdAtRouteResult.RouteName);

      _surveyServiceMock.Verify(service => service.AddNewSurveyAsync(It.Is<ISurveyData>(data => data.Name == vm.Name && data.Description == vm.Description), CancellationToken.None));
      _surveyServiceMock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task UpdateSurvey_Should_Return_NotFound()
    {
      _surveyServiceMock.Setup(service => service.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(default(ISurveyEntity))
                        .Verifiable();

      var vm = new UpdateSurveyViewModel();

      var actionResult = await _surveyController.UpdateSurvey(vm, CancellationToken.None);

      Assert.IsNotNull(actionResult);

      var notFoundResult = actionResult as NotFoundResult;

      Assert.IsNotNull(notFoundResult);

      _surveyServiceMock.Verify(service => service.GetSurveyAsync(vm.SurveyId, CancellationToken.None));
      _surveyServiceMock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task UpdateSurvey_Should_Return_NoContent()
    {
      _surveyServiceMock.Setup(service => service.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(new TestSurveyEntity())
                        .Verifiable();

      _surveyServiceMock.Setup(service => service.UpdateSurveyAsync(It.IsAny<ISurveyEntity>(), It.IsAny<CancellationToken>()))
                        .Returns(Task.CompletedTask)
                        .Verifiable();

      var vm = new UpdateSurveyViewModel
      {
        SurveyId = Guid.NewGuid(),
        Name = Guid.NewGuid().ToString(),
        Description = Guid.NewGuid().ToString(),
      };

      var actionResult = await _surveyController.UpdateSurvey(vm, CancellationToken.None);

      Assert.IsNotNull(actionResult);

      var notContentResult = actionResult as NoContentResult;

      Assert.IsNotNull(notContentResult);

      _surveyServiceMock.Verify(service => service.GetSurveyAsync(vm.SurveyId, CancellationToken.None));
      _surveyServiceMock.Verify(service => service.UpdateSurveyAsync(It.Is<ISurveyEntity>(data => data.SurveyId == vm.SurveyId && data.Name == vm.Name && data.Description == vm.Description), CancellationToken.None));
      _surveyServiceMock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task GetSurvey_Should_Return_Not_Found()
    {
      _surveyServiceMock.Setup(service => service.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(default(ISurveyEntity))
                        .Verifiable();

      var surveyId = Guid.NewGuid();

      var actionResult = await _surveyController.GetSurvey(surveyId, CancellationToken.None);

      Assert.IsNotNull(actionResult);
      Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));

      _surveyServiceMock.Verify(service => service.GetSurveyAsync(surveyId, CancellationToken.None));
      _surveyServiceMock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task GetSurvey_Should_Return_Ok()
    {
      var controlSurveyEntity = new TestSurveyEntity();

      _surveyServiceMock.Setup(service => service.GetSurveyAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(controlSurveyEntity)
                        .Verifiable();

      var surveyId = Guid.NewGuid();

      var actionResult = await _surveyController.GetSurvey(surveyId, CancellationToken.None);

      Assert.IsNotNull(actionResult);

      var okObjectResult = actionResult as OkObjectResult;

      Assert.IsNotNull(okObjectResult);
      Assert.IsNotNull(okObjectResult.Value);

      var getSurveyViewModel = okObjectResult.Value as GetSurveyViewModel;

      Assert.IsNotNull(getSurveyViewModel);
      Assert.AreEqual(controlSurveyEntity.SurveyId, getSurveyViewModel.SurveyId);
      Assert.AreEqual(controlSurveyEntity.Name, getSurveyViewModel.Name);
      Assert.AreEqual(controlSurveyEntity.Description, getSurveyViewModel.Description);

      _surveyServiceMock.Verify(service => service.GetSurveyAsync(surveyId, CancellationToken.None));
      _surveyServiceMock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task GetSurveys_Should_Return_Ok()
    {
      var controlSurveyEntityCollection = new TestSurveyEntity[0];

      _surveyServiceMock.Setup(service => service.GetSurveysAsync(It.IsAny<CancellationToken>()))
                        .ReturnsAsync(controlSurveyEntityCollection)
                        .Verifiable();

      var actionResult = await _surveyController.GetSurveys(CancellationToken.None);

      Assert.IsNotNull(actionResult);

      var okObjectResult = actionResult as OkObjectResult;

      Assert.IsNotNull(okObjectResult);
      Assert.IsNotNull(okObjectResult.Value);

      var getSurveyCollectionViewModel = okObjectResult.Value as GetSurveyCollectionViewModel;

      Assert.IsNotNull(getSurveyCollectionViewModel);

      _surveyServiceMock.Verify(service => service.GetSurveysAsync(CancellationToken.None));
      _surveyServiceMock.VerifyNoOtherCalls();
    }

    private sealed class TestSurveyEntity : ISurveyEntity
    {
      public Guid SurveyId { get; } = Guid.NewGuid();

      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();
    }
  }
}
