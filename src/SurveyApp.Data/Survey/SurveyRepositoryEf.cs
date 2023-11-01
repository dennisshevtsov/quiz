// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SurveyApp.Survey.Data;

public sealed class SurveyRepositoryEf : ISurveyRepository
{
  private readonly DbContext _dbContext;

  public SurveyRepositoryEf(DbContext dbContext)
  {
    _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
  }

  public Task<SurveyEntity?> GetSurveyAsync(Guid surveyId, CancellationToken cancellationToken) =>
    _dbContext.Set<SurveyEntity>()
              .AsNoTracking()
              .Where(entity => entity.SurveyId == surveyId)
              .FirstOrDefaultAsync(cancellationToken);

  public async Task<SurveyEntity> AddSurveyAsync(SurveyEntity surveyEntity, CancellationToken cancellationToken)
  {
    EntityEntry<SurveyEntity> surveyEntityEntry = _dbContext.Entry(surveyEntity);
    surveyEntityEntry.State = EntityState.Added;
    await _dbContext.SaveChangesAsync(cancellationToken);
    surveyEntityEntry.State = EntityState.Detached;

    return surveyEntity;
  }

  public async Task UpdateSurveyAsync(SurveyEntity surveyEntity, CancellationToken cancellationToken)
  {
    EntityEntry<SurveyEntity> surveyEntityEntry = _dbContext.Entry(surveyEntity);
    surveyEntityEntry.State = EntityState.Modified;
    await _dbContext.SaveChangesAsync(cancellationToken);
    surveyEntityEntry.State = EntityState.Detached;
  }

  public Task DeleteSurveyAsync(Guid surveyId, CancellationToken cancellationToken) =>
    _dbContext.Set<SurveyEntity>()
              .Where(entity => entity.SurveyId == surveyId)
              .ExecuteDeleteAsync(cancellationToken);
}
