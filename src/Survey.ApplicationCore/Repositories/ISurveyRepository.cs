// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.ApplicationCore.Repositories
{
  using Survey.ApplicationCore.Entities;

  /// <summary>Provides a simple API to the storage of the survey entity.</summary>
  public interface ISurveyRepository
  {
    /// <summary>Saves a new survey entity to the storage.</summary>
    /// <param name="surveyEntity">An object that represents a survey entity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task InsertAsync(ISurveyEntity surveyEntity, CancellationToken cancellationToken);
  }
}
