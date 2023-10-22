// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;
using SurveyApp.SurveyTemplate.Data;

namespace Microsoft.Extensions.DependencyInjection;

public static class SurveyTemplateDataServicesExtensions
{
  public static IServiceCollection AddSurveyTemplateData(this IServiceCollection services)
  {
    services.AddSingleton<ISurveyTemplateRepository, SurveyTemplateRepository>();

    return services;
  }

  public static IServiceCollection AddSurveyTemplateDataEf(this IServiceCollection services)
  {
    services.AddSingleton<ISurveyTemplateRepository, SurveyTemplateRepositoryEf>();

    return services;
  }
}
