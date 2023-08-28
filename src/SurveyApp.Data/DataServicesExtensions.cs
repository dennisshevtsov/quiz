// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection;

public static class DataServicesExtensions
{
  public static IServiceCollection AddData(this IServiceCollection services)
  {
    services.AddSurveyData();
    services.AddSurveyTemplateData();

    return services;
  }
}
