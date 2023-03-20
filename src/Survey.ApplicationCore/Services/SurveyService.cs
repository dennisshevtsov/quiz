// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.ApplicationCore.Services
{
  using System;

  using Survey.ApplicationCore.Entities;
  using Survey.ApplicationCore.Repositories;

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
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task AddNewSurveyAsync(ISurveyData surveyData, CancellationToken cancellationToken)
    {
      return _surveyRepository.InsertAsync(surveyData, cancellationToken);
    }
  }
}
