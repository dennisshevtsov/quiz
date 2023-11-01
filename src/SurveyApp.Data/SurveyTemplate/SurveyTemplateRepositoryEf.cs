// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SurveyApp.SurveyTemplate.Data;

public sealed class SurveyTemplateRepositoryEf : ISurveyTemplateRepository
{
  private readonly DbContext _dbContext;

  public SurveyTemplateRepositoryEf(DbContext dbContext)
  {
    _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
  }

  public Task<SurveyTemplateEntity?> GetSurveyTemplateAsync(Guid surveyTemplateId, CancellationToken cancellationToken) =>
    _dbContext.Set<SurveyTemplateEntity>()
              .AsNoTracking()
              .Where(entity => entity.SurveyTemplateId == surveyTemplateId)
              .FirstOrDefaultAsync(cancellationToken);

  public async Task<SurveyTemplateEntity> AddSurveyTemplateAsync(SurveyTemplateEntity surveyTemplateEntity, CancellationToken cancellationToken)
  {
    EntityEntry<SurveyTemplateEntity> surveyTemplateEntityEntry = _dbContext.Entry(surveyTemplateEntity);
    surveyTemplateEntityEntry.State = EntityState.Added;
    await _dbContext.SaveChangesAsync(cancellationToken);
    surveyTemplateEntityEntry.State = EntityState.Detached;

    return surveyTemplateEntity;
  }

  public async Task UpdateSurveyTemplateAsync(SurveyTemplateEntity surveyTemplateEntity, CancellationToken cancellationToken)
  {
    EntityEntry<SurveyTemplateEntity> surveyTemplateEntityEntry = _dbContext.Entry(surveyTemplateEntity);
    surveyTemplateEntityEntry.State = EntityState.Modified;
    await _dbContext.SaveChangesAsync(cancellationToken);
    surveyTemplateEntityEntry.State = EntityState.Detached;
  }

  public async Task DeleteSurveyTemplateAsync(Guid surveyTemplateId, CancellationToken cancellationToken)
  {
    await _dbContext.Set<SurveyTemplateEntity>()
                    .Where(entity => entity.SurveyTemplateId == surveyTemplateId)
                    .ExecuteDeleteAsync(cancellationToken);
  }
}
