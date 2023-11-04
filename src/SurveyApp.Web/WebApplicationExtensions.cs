using Microsoft.EntityFrameworkCore;

namespace Microsoft.AspNetCore.Builder;

public static class WebApplicationExtensions
{
  public static WebApplication UseData(this WebApplication app)
  {
    using (IServiceScope scope = app.Services.CreateScope())
    {
      scope.ServiceProvider.GetRequiredService<DbContext>().Database.EnsureCreated();
    }

    return app;
  }
}
