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
                           .ReturnsAsync(new TestSurveyEntity())
                           .Verifiable();

      var surveyData = new TestSurveyData();

      var surveyIdentity =
        await _surveyService.AddNewSurveyAsync(surveyData, CancellationToken.None);

      Assert.IsNotNull(surveyIdentity);

      _surveyRepositoryMock.Verify(repository => repository.AddSurveyAsync(It.Is<ISurveyEntity>(entity => surveyData.Equals(entity)), CancellationToken.None));
      _surveyRepositoryMock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task UpdateNewSurveyAsync_Should_Save_Survey()
    {
      _surveyRepositoryMock.Setup(repository => repository.UpdateSurveyAsync(It.IsAny<ISurveyEntity>(), It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask)
                           .Verifiable();

      var surveyEntity = new TestSurveyEntity();

      await _surveyService.UpdateSurveyAsync(surveyEntity, CancellationToken.None);

      _surveyRepositoryMock.Verify(repository => repository.UpdateSurveyAsync(It.Is<ISurveyEntity>(entity => surveyEntity.Equals(entity)), CancellationToken.None));
      _surveyRepositoryMock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task DeleteNewSurveyAsync_Should_Delete_Survey()
    {
      _surveyRepositoryMock.Setup(repository => repository.DeleteSurveyAsync(It.IsAny<ISurveyIdentity>(), It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask)
                           .Verifiable();

      var surveyIdentity = new TestSurveyIdentity();

      await _surveyService.DeleteSurveyAsync(surveyIdentity, CancellationToken.None);

      _surveyRepositoryMock.Verify(repository => repository.DeleteSurveyAsync(surveyIdentity, CancellationToken.None));
      _surveyRepositoryMock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task GetSurveyAsync_Should_Get_Survey()
    {
      var controlSurveyEntity = new TestSurveyEntity();

      _surveyRepositoryMock.Setup(repository => repository.GetSurveyAsync(It.IsAny<ISurveyIdentity>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(controlSurveyEntity)
                           .Verifiable();

      var surveyIdentity = new TestSurveyIdentity();

      var actualSurveyEntity =
        await _surveyService.GetSurveyAsync(surveyIdentity, CancellationToken.None);

      Assert.IsNotNull(actualSurveyEntity);
      Assert.AreEqual(controlSurveyEntity, actualSurveyEntity);

      _surveyRepositoryMock.Verify(repository => repository.GetSurveyAsync(surveyIdentity, CancellationToken.None));
      _surveyRepositoryMock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task GetSurveysAsync_Should_Get_Survey_Collection()
    {
      var controlSurveyEntityCollection = new TestSurveyEntity[0];

      _surveyRepositoryMock.Setup(repository => repository.GetSurveysAsync(It.IsAny<CancellationToken>()))
                           .ReturnsAsync(controlSurveyEntityCollection)
                           .Verifiable();

      var actualSurveyEntityCollection =
        await _surveyService.GetSurveysAsync(CancellationToken.None);

      Assert.IsNotNull(actualSurveyEntityCollection);
      Assert.AreEqual(controlSurveyEntityCollection, actualSurveyEntityCollection);

      _surveyRepositoryMock.Verify(repository => repository.GetSurveysAsync(CancellationToken.None));
      _surveyRepositoryMock.VerifyNoOtherCalls();
    }

    private sealed class TestSurveyIdentity : ISurveyIdentity
    {
      public Guid SurveyId { get; } = Guid.NewGuid();
    }

    private sealed class TestSurveyData : ISurveyData
    {
      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();

      public IQuestionEntity[] Questions { get; } = new IQuestionEntity[0];

      public bool Equals(ISurveyData other)
        => Name == other.Name && Description == other.Description;
    }

    private sealed class TestSurveyEntity : ISurveyEntity
    {
      public Guid SurveyId { get; } = Guid.NewGuid();

      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();

      public IQuestionEntity[] Questions { get; } = new IQuestionEntity[0];

      public bool Equals(TestSurveyEntity other)
        => SurveyId    == other.SurveyId &&
           Name        == other.Name     &&
           Description == other.Description;
    }
  }
}
