// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Domain.Repositories
{
  using Survey.Domain.Entities;

  /// <summary>Provides a simple API to the storage of the <see cref="Survey.ApplicationCore.Entities.ISurveyEntity"/>.</summary>
  public interface ISurveyRepository
  {
    /// <summary>Saves a new survey entity to the storage.</summary>
    /// <param name="surveyData">An object that represents survey data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task InsertAsync(ISurveyData surveyData, CancellationToken cancellationToken);
  }
}
