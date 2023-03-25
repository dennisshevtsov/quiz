// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Domain.Services
{
  using System;

  using Survey.Domain.Entities;

  /// <summary>Provides a simple API to the survey entity.</summary>
  public interface ISurveyService
  {
    /// <summary>Creates a new survey.</summary>
    /// <param name="surveyData">An object that represents survey data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Survey.Domain.Entities.ISurveyEntity"/>.</returns>
    public Task<ISurveyEntity> AddNewSurveyAsync(ISurveyData surveyData, CancellationToken cancellationToken);

    /// <summary>Gets a survey.</summary>
    /// <param name="surveyId">An object that represents an identity of a survey.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Survey.Domain.Entities.ISurveyEntity"/> class.</returns>
    public Task<ISurveyEntity?> GetSurveyAsync(Guid surveyId, CancellationToken cancellationToken);
  }
}
