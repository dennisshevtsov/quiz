// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public interface ISurveyTemplateRepository
{
  public Task AddSurveyTemplateAsync(SurveyTemplateEntity surveyTemplateEntity, CancellationToken cancellationToken);

  public Task GetSurveyTemplateAsync(Guid surveyTemplateId, CancellationToken cancellationToken);
}
