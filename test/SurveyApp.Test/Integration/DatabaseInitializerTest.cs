// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Data.Initialization.Test
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.DependencyInjection;

  using SurveyApp.Data.Initialization;
  using SurveyApp.Survey.Data;
  using SurveyApp.Test.Integration;

  [TestClass]
  public sealed class DatabaseInitializerTest : IntegrationTestBase
  {

#pragma warning disable CS8618
    private IDatabaseInitializer _databaseInitializer;
#pragma warning restore CS8618

    protected override void InitializeInternal()
    {
      _databaseInitializer = ServiceProvider.GetRequiredService<IDatabaseInitializer>();
    }

    [TestMethod]
    public async Task Initialize_Should_Create_New_Database()
    {
      await DbContext.Database.EnsureDeletedAsync(CancellationToken);
      await _databaseInitializer.InitializeAsync(CancellationToken);

      Assert.AreEqual(0, await DbContext.Set<SurveyEntity>().CountAsync(CancellationToken));

      DbContext.Add(DatabaseInitializerTest.GenerateTestSurvey());
      await DbContext.SaveChangesAsync(CancellationToken);

      Assert.AreEqual(1, await DbContext.Set<SurveyEntity>().CountAsync(CancellationToken));
    }

    private static SurveyEntity GenerateTestSurvey() => new()
    {
      Name = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
    };
  }
}
