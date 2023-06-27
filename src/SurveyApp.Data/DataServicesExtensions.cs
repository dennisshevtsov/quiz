// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using SurveyApp.Data;
using SurveyApp.Data.Survey;
using SurveyApp.Survey;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>Extends a API of the <see cref="IServiceCollection"/> class.</summary>
public static class DataServicesExtensions
{
  /// <summary>Registers the data services.</summary>
  /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
  /// <param name="configuration">An object that represents a set of key/value application configuration properties.</param>
  /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
  public static IServiceCollection SetUpData(this IServiceCollection services, IConfiguration configuration)
  {
    services.SetUpDatabase(configuration);
    services.AddScoped<ISurveyRepository, SurveyRepository>();

    return services;
  }

  /// <summary>Sets up the database access.</summary>
  /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
  /// <param name="configuration">An object that represents a set of key/value application configuration properties.</param>
  /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
  public static IServiceCollection SetUpDatabase(this IServiceCollection services, IConfiguration configuration)
  {
    services.Configure<DatabaseOptions>(configuration);
    services.AddDbContext<DbContext, AppDbContext>((provider, builder) =>
    {
      DatabaseOptions options = provider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
      ArgumentException.ThrowIfNullOrEmpty(options.ConnectionString);

      builder.UseNpgsql(options.ConnectionString);
    });

    return services;
  }
}
