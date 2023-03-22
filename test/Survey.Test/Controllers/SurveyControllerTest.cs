// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Web.Controllers.Test
{
  using Survey.Domain.Services;

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
  }
}
