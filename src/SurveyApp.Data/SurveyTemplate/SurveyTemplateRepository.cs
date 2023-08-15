// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Data;

public sealed class SurveyTemplateRepository : ISurveyTemplateRepository
{
  private readonly Dictionary<Guid, SurveyTemplateEntity> _surveyTemplates = new();

  public Task<SurveyTemplateEntity?> GetSurveyTemplateAsync(Guid surveyTemplateId, CancellationToken cancellationToken)
  {
    if (_surveyTemplates.ContainsKey(surveyTemplateId))
    {
      return Task.FromResult<SurveyTemplateEntity?>(_surveyTemplates[surveyTemplateId]);
    }

    return Task.FromResult(default(SurveyTemplateEntity));
  }

  public Task<SurveyTemplateEntity> AddSurveyTemplateAsync(SurveyTemplateEntity surveyTemplateEntity, CancellationToken cancellationToken)
  {
    surveyTemplateEntity.SurveyTemplateId =
      surveyTemplateEntity.SurveyTemplateId != default ?
      surveyTemplateEntity.SurveyTemplateId :
      Guid.NewGuid();

    _surveyTemplates[surveyTemplateEntity.SurveyTemplateId] = surveyTemplateEntity;

    return Task.FromResult(surveyTemplateEntity);
  }

  public Task UpdateSurveyTemplateAsync(SurveyTemplateEntity surveyTemplateEntity, CancellationToken cancellationToken)
  {
    if (_surveyTemplates.ContainsKey(surveyTemplateEntity.SurveyTemplateId))
    {
      _surveyTemplates[surveyTemplateEntity.SurveyTemplateId] = surveyTemplateEntity;
    }

    return Task.CompletedTask;
  }

  public Task DeleteSurveyTemplateAsync(Guid surveyTemplateId, CancellationToken cancellationToken)
  {
    _surveyTemplates.Remove(surveyTemplateId);

    return Task.CompletedTask;
  }
}
