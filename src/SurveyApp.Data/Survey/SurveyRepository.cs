// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Data;

public sealed class SurveyRepository : ISurveyRepository
{
  private readonly Dictionary<Guid, SurveyEntity> _surveys = new();

  public Task<SurveyEntity?> GetSurveyAsync(Guid surveyId, CancellationToken cancellationToken)
  {
    if (_surveys.ContainsKey(surveyId))
    {
      return Task.FromResult<SurveyEntity?>(_surveys[surveyId]);
    }

    return Task.FromResult(default(SurveyEntity));
  }

  public Task<SurveyEntity> AddSurveyAsync(SurveyEntity surveyEntity, CancellationToken cancellationToken)
  {
    _surveys[surveyEntity.SurveyId] = surveyEntity;

    return Task.FromResult(surveyEntity);
  }

  public Task UpdateSurveyAsync(SurveyEntity surveyEntity, CancellationToken cancellationToken)
  {
    if (_surveys.ContainsKey(surveyEntity.SurveyId))
    {
      _surveys[surveyEntity.SurveyId] = surveyEntity;
    }

    return Task.CompletedTask;
  }

  public Task DeleteSurveyAsync(Guid surveyId, CancellationToken cancellationToken)
  {
    _surveys.Remove(surveyId);

    return Task.CompletedTask;
  }
}
