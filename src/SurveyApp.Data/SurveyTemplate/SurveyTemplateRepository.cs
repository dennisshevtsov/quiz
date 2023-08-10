// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Data;

public sealed class SurveyTemplateRepository : ISurveyTemplateRepository
{
  public Task AddSurveyTemplateAsync(SurveyTemplateEntity surveyTemplateEntity, CancellationToken cancellationToken) => Task.CompletedTask;

  public Task GetSurveyTemplateAsync(Guid surveyTemplateId, CancellationToken cancellationToken) => Task.CompletedTask;
}
