// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection
{
  using Microsoft.EntityFrameworkCore;

  using Survey.Domain.Repositories;
  using Survey.Infrastructure;
  using Survey.Infrastructure.Repositories;

  /// <summary>Extends a API of the <see cref="IServiceCollection"/> class.</summary>
  public static class InfrastructureExtensions
  {
    /// <summary>Registers the application services.</summary>
    /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
    /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
    public static IServiceCollection SetUpInfrastructure(this IServiceCollection services)
    {
      services.SetUpDatabase();

      services.AddScoped<ISurveyRepository, SurveyRepository>();

      return services;
    }

    /// <summary>Sets up the database access.</summary>
    /// <param name="services">n object that specifies the contract for a collection of service descriptors.</param>
    /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
    public static IServiceCollection SetUpDatabase(this IServiceCollection services)
    {
      services.AddDbContext<DbContext, SurveyDbContext>(options => options.UseNpgsql("Host=localhost;Port=5433;Database=surveydb;Username=dev;Password=dev"));

      return services;
    }
  }
}
