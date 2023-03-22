// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Application.Services.Test
{
  using Survey.Domain.Repositories;

  [TestClass]
  public sealed class SurveyServiceTest
  {
#pragma warning disable CS8618
    private Mock<ISurveyRepository> _surveyRepositoryMock;

    private SurveyService _surveyService;
#pragma warning restore CS8618

    [TestInitialize]
    public void Initialize()
    {
      _surveyRepositoryMock = new Mock<ISurveyRepository>();

      _surveyService = new SurveyService(_surveyRepositoryMock.Object);
    }
  }
}
