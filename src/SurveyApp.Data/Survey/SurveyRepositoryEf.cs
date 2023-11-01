// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using SurveyApp.Survey;

namespace SurveyApp.Data.Survey;

public sealed class SurveyRepositoryEf : ISurveyRepository
{
  private readonly DbContext _dbContext;

  public SurveyRepositoryEf(DbContext dbContext)
  {
    _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
  }

  public Task<SurveyEntity?> GetSurveyAsync(Guid surveyId, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<SurveyEntity> AddSurveyAsync(SurveyEntity surveyEntity, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task UpdateSurveyAsync(SurveyEntity surveyEntity, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task DeleteSurveyAsync(Guid surveyId, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
