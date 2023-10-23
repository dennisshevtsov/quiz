// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.SurveyTemplate;

namespace SurveyApp.Data.Test;

[TestClass]
public sealed class DbContextTest
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
  private IServiceScope _scope;
  private DbContext _context;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

  [TestInitialize]
  public void Initialize()
  {
    IConfiguration configuration =
      new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                .Build();

    ServiceCollection services = new ServiceCollection();
    services.AddDataEf(configuration);

    _scope = services.BuildServiceProvider().CreateScope();
    _context = _scope.ServiceProvider.GetRequiredService<DbContext>();
  }

  [TestCleanup]
  public void Cleanup()
  {
    _context?.Database.EnsureDeleted();
    _scope?.Dispose();
  }

  [TestMethod]
  public async Task SaveChangesAsync_NewSurveyTemplate_ExceptionNotThrown()
  {
    // Arange
    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: Guid.NewGuid(),
      title           : Guid.NewGuid().ToString(),
      description     : Guid.NewGuid().ToString(),
      questions       : Array.Empty<QuestionTemplateEntityBase>()
    );

    _context.Add(surveyTemplateEntity);

    // Act
    Func<Task> act = () => _context.SaveChangesAsync();

    // Assert
    await act();
  }
}
