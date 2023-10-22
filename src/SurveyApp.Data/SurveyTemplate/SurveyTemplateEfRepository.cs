// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Data;

public sealed class SurveyTemplateEfRepository : ISurveyTemplateRepository
{
  public Task<SurveyTemplateEntity?> GetSurveyTemplateAsync(Guid surveyTemplateId, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<SurveyTemplateEntity> AddSurveyTemplateAsync(SurveyTemplateEntity surveyTemplateEntity, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task UpdateSurveyTemplateAsync(SurveyTemplateEntity surveyTemplateEntity, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task DeleteSurveyTemplateAsync(Guid surveyTemplateId, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
