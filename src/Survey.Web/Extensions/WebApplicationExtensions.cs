// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection
{
  using Survey.Infrastructure.Initialization;

  /// <summary>Extends a API of the <see cref="Microsoft.AspNetCore.Builder.WebApplication"/> class.</summary>
  public static class WebApplicationExtensions
  {
    /// <summary>Sets up the database.</summary>
    /// <param name="app">The web application used to configure the HTTP pipeline, and routes.</param>
    /// <returns>The web application used to configure the HTTP pipeline, and routes.</returns>
    public static WebApplication SetUpDatabase(this WebApplication app)
    {
      using (var scope = app.Services.CreateScope())
      {
        scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>()
                             .InitializeAsync(CancellationToken.None)
                             .GetAwaiter()
                             .GetResult();
      }

      return app;
    }
  }
}
