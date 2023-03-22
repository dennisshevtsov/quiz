// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Application.Services.Test
{
  using Survey.Domain.Entities;
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

    [TestMethod]
    public async Task AddNewSurveyAsync_Should_Save_Survey()
    {
      _surveyRepositoryMock.Setup(repository => repository.AddSurveyAsync(It.IsAny<ISurveyEntity>(), It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask)
                           .Verifiable();

      var surveyData = new TestSurveyData();

      var surveyIdentity =
        await _surveyService.AddNewSurveyAsync(surveyData, CancellationToken.None);

      Assert.IsNotNull(surveyIdentity);

      _surveyRepositoryMock.Verify(
        repository => repository.AddSurveyAsync(
          It.Is<ISurveyEntity>(entity => entity.Name == surveyData.Name && entity.Description == surveyData.Description),
          CancellationToken.None));

      _surveyRepositoryMock.VerifyNoOtherCalls();
    }

    private sealed class TestSurveyData : ISurveyData
    {
      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();
    }
  }
}
