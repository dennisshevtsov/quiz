// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Data;

public sealed class SurveyTemplateRepository : ISurveyTemplateRepository
{
  private readonly Dictionary<Guid, SurveyTemplateEntity> _surveyTemplates = new();

  public Task AddSurveyTemplateAsync(SurveyTemplateEntity surveyTemplateEntity, CancellationToken cancellationToken)
  {
    surveyTemplateEntity.SurveyId =
      surveyTemplateEntity.SurveyId != default ?
      surveyTemplateEntity.SurveyId :
      Guid.NewGuid();

    _surveyTemplates[surveyTemplateEntity.SurveyId] = surveyTemplateEntity;

    return Task.CompletedTask;
  }

  public Task GetSurveyTemplateAsync(Guid surveyTemplateId, CancellationToken cancellationToken) => Task.CompletedTask;
}
