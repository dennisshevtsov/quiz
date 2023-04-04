// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Infrastructure.Repositories.Test
{
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;

  using Survey.Domain.Repositories;

  [TestClass]
  public sealed class SurveyRepositoryTest
  {
    private CancellationToken _cancellationToken;

#pragma warning disable CS8618
    private IServiceScope _scope;

    private ISurveyRepository _surveyRepository;
#pragma warning restore CS8618

    [TestInitialize]
    public void Initialize()
    {
      _cancellationToken = CancellationToken.None;

      var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                    .Build();

      _scope = new ServiceCollection().SetUpInfrastructure(configuration)
                                      .BuildServiceProvider()
                                      .CreateScope();

      _surveyRepository = _scope.ServiceProvider.GetRequiredService<ISurveyRepository>();
    }

    [TestCleanup]
    public void Cleanup()
    {
      _scope?.Dispose();
    }
  }
}
