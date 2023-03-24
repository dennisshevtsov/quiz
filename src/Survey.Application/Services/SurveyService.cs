// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Application.Services
{
  using System;

  using Survey.Application.Entities;
  using Survey.Domain.Entities;
  using Survey.Domain.Repositories;
  using Survey.Domain.Services;

  /// <summary>Provides a simple API to the survey entity.</summary>
  public sealed class SurveyService : ISurveyService
  {
    private readonly ISurveyRepository _surveyRepository;

    /// <summary>Initializes a new instance of the <see cref="Survey.ApplicationCore.Services.SurveyService"/> class.</summary>
    /// <param name="surveyRepository">An object that provides a simple API to the storage of the <see cref="urvey.ApplicationCore.Entities.ISurveyEntity"/>.</param>
    public SurveyService(ISurveyRepository surveyRepository)
    {
      _surveyRepository = surveyRepository ?? throw new ArgumentNullException(nameof(surveyRepository));
    }

    /// <summary>Creates a new survey.</summary>
    /// <param name="surveyData">An object that represents survey data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Survey.Domain.Entities.ISurveyIdentity"/>.</returns>
    public async Task<ISurveyIdentity> AddNewSurveyAsync(ISurveyData surveyData, CancellationToken cancellationToken)
    {
      var surveyEntity = new SurveyEntity(surveyData);

      await _surveyRepository.AddSurveyAsync(surveyEntity, cancellationToken);

      return surveyEntity;
    }

    /// <summary>Gets a survey.</summary>
    /// <param name="surveyId">An object that represents an identity of a survey.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Survey.Domain.Entities.ISurveyEntity"/> class.</returns>
    public async Task<ISurveyEntity?> GetSurveyAsync(Guid surveyId, CancellationToken cancellationToken)
      => await _surveyRepository.GetSurveyAsync(surveyId, cancellationToken);
  }
}
