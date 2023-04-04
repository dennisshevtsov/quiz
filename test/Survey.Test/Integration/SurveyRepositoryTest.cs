// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Infrastructure.Repositories.Test
{
  using System;

  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.DependencyInjection;

  using Survey.Domain.Repositories;
  using Survey.Infrastructure.Entities;
  using Survey.Test.Integration;

  [TestClass]
  public sealed class SurveyRepositoryTest : IntegrationTestBase
  {
#pragma warning disable CS8618
    private ISurveyRepository _surveyRepository;
#pragma warning restore CS8618

    protected override void InitializeInternal()
    {
      _surveyRepository = ServiceProvider.GetRequiredService<ISurveyRepository>();
    }

    [TestMethod]
    public async Task AddSurveyAsync_Should_Create_New_Survey()
    {
      var controlSurveyEntity = SurveyRepositoryTest.GenerateTestSurvey();

      await _surveyRepository.AddSurveyAsync(controlSurveyEntity, CancellationToken);

      var actualSurveyEntity =
        await DbContext.Set<SurveyEntity>()
                       .AsNoTracking()
                       .Where(entity => entity.SurveyId == controlSurveyEntity.SurveyId)
                       .SingleOrDefaultAsync(CancellationToken);

      Assert.IsNotNull(actualSurveyEntity);

      SurveyRepositoryTest.AreEqual(controlSurveyEntity, actualSurveyEntity);
      IsDetached(controlSurveyEntity);
    }

    private static SurveyEntity GenerateTestSurvey() => new()
    {
      SurveyId    = Guid.NewGuid(),
      Name        = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
    };

    private static void AreEqual(SurveyEntity control, SurveyEntity actual)
    {
      Assert.AreEqual(control.SurveyId, actual.SurveyId);
      Assert.AreEqual(control.Name, actual.Name);
      Assert.AreEqual(control.Description, actual.Description);
    }

    private void IsDetached(SurveyEntity entity)
    {
      var entry = DbContext.Entry(entity);

      Assert.AreEqual(EntityState.Detached, entry.State);
    }
  }
}
