// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Domain.Repositories
{
  using System;

  using Survey.Domain.Entities;

  /// <summary>Provides a simple API to the storage of the <see cref="Survey.ApplicationCore.Entities.ISurveyEntity"/>.</summary>
  public interface ISurveyRepository
  {
    /// <summary>Saves a new survey entity to the storage.</summary>
    /// <param name="surveyEntity">An object that represents a survey entity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Survey.Domain.Entities.ISurveyEntity"/>.</returns>
    public Task<ISurveyEntity> AddSurveyAsync(ISurveyEntity surveyEntity, CancellationToken cancellationToken);

    /// <summary>Updates a survey.</summary>
    /// <param name="surveyEntity">An object that represents a survey entity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateSurveyAsync(ISurveyEntity surveyEntity, CancellationToken cancellationToken);

    /// <summary>Deletes a survey.</summary>
    /// <param name="surveyIdentity">An object that represents a survey identity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task DeleteSurveyAsync(ISurveyIdentity surveyIdentity, CancellationToken cancellationToken);

    /// <summary>Gets a survey.</summary>
    /// <param name="surveyId">An object that represents an identity of a survey.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Survey.Domain.Entities.ISurveyEntity"/>.</returns>
    public Task<ISurveyEntity?> GetSurveyAsync(Guid surveyId, CancellationToken cancellationToken);

    /// <summary>Gets a collection of surveys.</summary>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an collection of the <see cref="Survey.Domain.Entities.ISurveyEntity"/>.</returns>
    public Task<ISurveyEntity[]> GetSurveysAsync(CancellationToken cancellationToken);
  }
}
