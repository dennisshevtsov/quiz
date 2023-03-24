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
                        .ReturnsAsync(new SurveyIdentity())
                        .Verifiable();

      var vm = new SurveyViewModel
      {
        Name = Guid.NewGuid().ToString(),
        Description = Guid.NewGuid().ToString(),
      };

      var actionResult = await _surveyController.AddSurvey(vm, CancellationToken.None);

      Assert.IsNotNull(actionResult);
      Assert.IsInstanceOfType(actionResult, typeof(OkResult));

      _surveyServiceMock.Verify(service => service.AddNewSurveyAsync(It.Is<ISurveyData>(data => data.Name == vm.Name && data.Description == vm.Description), CancellationToken.None));
      _surveyServiceMock.VerifyNoOtherCalls();
    }

    private sealed class SurveyIdentity : ISurveyIdentity
    {
      public Guid SurveyId { get; set; }
    }
  }
}
