// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Test.Integration
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;

  using Survey.Infrastructure.Entities;
  using Survey.Infrastructure.Initialization;

  [TestClass]
  public sealed class DatabaseInitializerTest
  {
    private CancellationToken _cancellationToken;

#pragma warning disable CS8618
    private IServiceScope _scope;

    private DbContext _dbContext;
    private IDatabaseInitializer _databaseInitializer;
#pragma warning restore CS8618

    [TestInitialize]
    public void Initialize()
    {
      _cancellationToken = CancellationToken.None;

      var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                    .Build();

      _scope = new ServiceCollection().SetUpDatabase(configuration)
                                      .BuildServiceProvider()
                                      .CreateScope();

      _dbContext = _scope.ServiceProvider.GetRequiredService<DbContext>();
      _databaseInitializer = _scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
    }

    [TestCleanup]
    public void Cleanup()
    {
      _dbContext?.Database?.EnsureDeleted();
      _scope?.Dispose();
    }

    public async Task Initialize_Should_Create_New_Database()
    {
      await _dbContext.Database.EnsureDeletedAsync(_cancellationToken);
      await _databaseInitializer.InitializeAsync(_cancellationToken);

      Assert.AreEqual(0, await _dbContext.Set<SurveyEntity>().CountAsync(_cancellationToken));

      _dbContext.Add(DatabaseInitializerTest.GenerateTestSurvey());
      await _dbContext.SaveChangesAsync(_cancellationToken);

      Assert.AreEqual(1, await _dbContext.Set<SurveyEntity>().CountAsync(_cancellationToken));
    }

    private static SurveyEntity GenerateTestSurvey() => new SurveyEntity
    {
      Name = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
    };
  }
}
