// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Domain.Services
{
  using Survey.Domain.Entities;

  /// <summary>Provides a simple API to the survey entity.</summary>
  public interface ISurveyService
  {
    /// <summary>Creates a new survey.</summary>
    /// <param name="surveyData">An object that represents survey data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task AddNewSurveyAsync(ISurveyData surveyData, CancellationToken cancellationToken);
  }
}
