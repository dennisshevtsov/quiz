// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection
{
  using Survey.Domain.Repositories;
  using Survey.Infrastructure.Repositories;

  /// <summary>Extends a API of the <see cref="IServiceCollection"/> class.</summary>
  public static class InfrastructureExtensions
  {
    /// <summary>Registers the application services.</summary>
    /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
    /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
    public static IServiceCollection SetUpInfrastructure(this IServiceCollection services)
    {
      services.AddScoped<ISurveyRepository, SurveyRepository>();

      return services;
    }
  }
}
