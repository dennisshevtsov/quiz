// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.Web.Binding;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>Extends the API of the <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/>.</summary>
public static class ServicesExtensions
{
  /// <summary>Sets up the Web.</summary>
  /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
  /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
  public static IServiceCollection SetUpWeb(this IServiceCollection services)
  {
    services.AddControllers(options =>
    {
      options.ModelBinderProviders.Insert(0, new RequestDtoBinderProvider());
    });

    return services;
  }
}
