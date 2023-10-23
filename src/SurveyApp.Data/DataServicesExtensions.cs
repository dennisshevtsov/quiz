// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SurveyApp.Data;

namespace Microsoft.Extensions.DependencyInjection;

public static class DataServicesExtensions
{
  public static IServiceCollection AddData(this IServiceCollection services)
  {
    services.AddSurveyData();
    services.AddSurveyTemplateData();
    return services;
  }

  public static IServiceCollection AddDataEf(this IServiceCollection services, IConfiguration configuration)
  {
    services.Configure<AppDbOptions>(configuration);
    services.AddDbContext<DbContext, AppDbContext>((provider, builder) =>
    {
      var options = provider.GetRequiredService<IOptions<AppDbOptions>>().Value;
      ArgumentException.ThrowIfNullOrEmpty(options.ConnectionString);

      builder.UseNpgsql(options.ConnectionString);
    });

    services.AddSurveyTemplateDataEf();

    return services;
  }
}
