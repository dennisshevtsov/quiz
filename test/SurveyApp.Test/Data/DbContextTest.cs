// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.Survey;
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
    IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                             .Build();

    ServiceCollection services = new ServiceCollection();
    services.AddDataEf(configuration);

    _scope = services.BuildServiceProvider().CreateScope();

    _context = _scope.ServiceProvider.GetRequiredService<DbContext>();
    _context.Database.EnsureCreated();
  }

  [TestCleanup]
  public void Cleanup()
  {
    _context?.Database.EnsureDeleted();
    _scope?.Dispose();
  }

  [TestMethod]
  public async Task SaveChangesAsync_SurveyTemplateAdded_ExceptionNotThrown()
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

  [TestMethod]
  public async Task SaveChangesAsync_SurveyTemplateModified_SurveyTemplateUpdated()
  {
    // Arange
    SurveyTemplateEntity original = await AddTestSurveyTemplateAsync();

    SurveyTemplateEntity updated = new
    (
      surveyTemplateId: original.SurveyTemplateId,
      title           : Guid.NewGuid().ToString(),
      description     : Guid.NewGuid().ToString(),
      questions       : Array.Empty<QuestionTemplateEntityBase>()
    );

    _context.Entry(updated).State = EntityState.Modified;

    // Act
    await _context.SaveChangesAsync();

    // Assert
    SurveyTemplateEntity? actual = await GetSurveyTemplateAsync(original.SurveyTemplateId);
    Assert.AreEqual(updated, actual);
  }

  [TestMethod]
  public async Task SaveChangesAsync_SurveyTemplateDeleted_SurveyTemplateDeleted()
  {
    // Arange
    SurveyTemplateEntity original = await AddTestSurveyTemplateAsync();

    _context.Entry(original).State = EntityState.Deleted;

    // Act
    await _context.SaveChangesAsync();

    // Assert
    SurveyTemplateEntity? actual = await GetSurveyTemplateAsync(original.SurveyTemplateId);
    Assert.IsNull(actual);
  }

  [TestMethod]
  public async Task FirstOrDefaultAsync_ExitingSurveyTemplateId_SurveyTemplateReturned()
  {
    // Arange
    SurveyTemplateEntity expected = await AddTestSurveyTemplateAsync();

    // Act
    SurveyTemplateEntity? actual = await GetSurveyTemplateAsync(expected.SurveyTemplateId);

    // Assert
    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public async Task SaveChangesAsync_SurveyAdded_ExceptionNotThrown()
  {
    // Arange
    SurveyEntity surveyEntity = new
    (
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Draft,
      title          : Guid.NewGuid().ToString(),
      description    : Guid.NewGuid().ToString(),
      intervieweeName: Guid.NewGuid().ToString(),
      questions      : Array.Empty<QuestionEntityBase>()
    );

    _context.Add(surveyEntity);

    // Act
    Func<Task> act = () => _context.SaveChangesAsync();

    // Assert
    await act();
  }

    [TestMethod]
  public async Task SaveChangesAsync_SurveyModified_SurveyTemplateUpdated()
  {
    // Arange
    SurveyEntity original = await AddTestSurveyAsync();

    SurveyEntity updated = new
    (
      surveyId       : original.SurveyId,
      state          : SurveyState.Draft,
      title          : Guid.NewGuid().ToString(),
      description    : Guid.NewGuid().ToString(),
      intervieweeName: Guid.NewGuid().ToString(),
      questions      : Array.Empty<QuestionEntityBase>()
    );

    _context.Entry(updated).State = EntityState.Modified;

    // Act
    await _context.SaveChangesAsync();

    // Assert
    SurveyEntity? actual = await GetSurveyAsync(original.SurveyId);
    Assert.AreEqual(updated, actual);
  }

  [TestMethod]
  public async Task SaveChangesAsync_SurveyDeleted_SurveyDeleted()
  {
    // Arange
    SurveyEntity original = await AddTestSurveyAsync();

    _context.Entry(original).State = EntityState.Deleted;

    // Act
    await _context.SaveChangesAsync();

    // Assert
    SurveyEntity? actual = await GetSurveyAsync(original.SurveyId);
    Assert.IsNull(actual);
  }

  [TestMethod]
  public async Task FirstOrDefaultAsync_ExitingSurveyId_SurveyReturned()
  {
    // Arange
    SurveyEntity expected = await AddTestSurveyAsync();

    // Act
    SurveyEntity? actual = await GetSurveyAsync(expected.SurveyId);

    // Assert
    Assert.AreEqual(expected, actual);
  }


  private async Task<SurveyTemplateEntity> AddTestSurveyTemplateAsync()
  {
    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: Guid.NewGuid(),
      title           : Guid.NewGuid().ToString(),
      description     : Guid.NewGuid().ToString(),
      questions       : new QuestionTemplateEntityBase[]
      {
        new TextQuestionTemplateEntity
        (
          text: Guid.NewGuid().ToString()
        ),
        new YesNoQuestionTemplateEntity
        (
          text: Guid.NewGuid().ToString()
        ),
        new MultipleChoiceQuestionTemplateEntity
        (
          text   : Guid.NewGuid().ToString(),
          choices: new[]
          {
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
          }
        ),
        new SingleChoiceQuestionTemplateEntity
        (
          text   : Guid.NewGuid().ToString(),
          choices: new[]
          {
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
          }
        )
      }
    );

    _context.Add(surveyTemplateEntity);
    await _context.SaveChangesAsync();
    _context.Entry(surveyTemplateEntity).State = EntityState.Detached;

    return surveyTemplateEntity;
  }

  private Task<SurveyTemplateEntity?> GetSurveyTemplateAsync(Guid surveyTemplateId) =>
    _context.Set<SurveyTemplateEntity>()
            .AsNoTracking()
            .Where(entity => entity.SurveyTemplateId == surveyTemplateId)
            .FirstOrDefaultAsync();

  private async Task<SurveyEntity> AddTestSurveyAsync()
  {
    SurveyEntity surveyEntity = new
    (
      surveyId       : Guid.NewGuid(),
      state          : SurveyState.Draft,
      title          : Guid.NewGuid().ToString(),
      description    : Guid.NewGuid().ToString(),
      intervieweeName: Guid.NewGuid().ToString(),
      questions      : new QuestionEntityBase[]
      {
        new TextQuestionEntity
        (
          text  : Guid.NewGuid().ToString(),
          answer: null
        ),
        new YesNoQuestionEntity
        (
          text  : Guid.NewGuid().ToString(),
          answer: YesNo.None
        ),
        new MultipleChoiceQuestionEntity
        (
          text   : Guid.NewGuid().ToString(),
          choices: new[]
          {
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
          },
          answers: Array.Empty<string>()
        ),
        new SingleChoiceQuestionEntity
        (
          text   : Guid.NewGuid().ToString(),
          choices: new[]
          {
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
          },
          answer : null
        ),
      }
    );

    _context.Add(surveyEntity);
    await _context.SaveChangesAsync();
    _context.Entry(surveyEntity).State = EntityState.Detached;

    return surveyEntity;
  }

  private Task<SurveyEntity?> GetSurveyAsync(Guid surveyId) =>
    _context.Set<SurveyEntity>()
            .AsNoTracking()
            .Where(entity => entity.SurveyId == surveyId)
            .FirstOrDefaultAsync();
}
