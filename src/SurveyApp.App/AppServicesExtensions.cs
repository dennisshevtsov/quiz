// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.Survey;
using SurveyApp.Survey.App;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>Extends a API of the <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/> class.</summary>
public static class AppServicesExtensions
{
  /// <summary>Registers the application services.</summary>
  /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
  /// <param name="configuration">An object that represents a set of key/value application configuration properties.</param>
  /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
  public static IServiceCollection SetUpData(this IServiceCollection services)
  {
    services.AddScoped<ISurveyService, SurveyService>();

    return services;
  }
}
