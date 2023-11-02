// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.Survey;
using SurveyApp.Survey.Data;

namespace Microsoft.Extensions.DependencyInjection;

public static class SurveyDataServicesExtensions
{
  public static IServiceCollection AddSurveyDataEf(this IServiceCollection services)
  {
    services.AddSingleton<ISurveyRepository, SurveyRepositoryEf>();

    return services;
  }
}
