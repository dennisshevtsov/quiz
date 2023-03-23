// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Infrastructure.Repositories
{
  using Survey.Domain.Entities;
  using Survey.Domain.Repositories;

  /// <summary>Provides a simple API to the storage of the <see cref="Survey.ApplicationCore.Entities.ISurveyEntity"/>.</summary>
  public sealed class SurveyRepository : ISurveyRepository
  {
    private readonly IList<ISurveyEntity> _surveyEntityCollection;

    /// <summary>Initializes a new instance of the <see cref="Survey.Infrastructure.Repositories.SurveyRepository"/> class.</summary>
    public SurveyRepository()
    {
      _surveyEntityCollection = new List<ISurveyEntity>();
    }

    /// <summary>Saves a new survey entity to the storage.</summary>
    /// <param name="surveyEntity">An object that represents a survey entity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task AddSurveyAsync(ISurveyEntity surveyEntity, CancellationToken cancellationToken)
    {
      _surveyEntityCollection.Add(surveyEntity);

      return Task.CompletedTask;
    }

    /// <summary>Gets a survey.</summary>
    /// <param name="surveyId">An object that represents an identity of a survey.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Survey.Domain.Entities.ISurveyEntity"/> class.</returns>
    public Task<ISurveyEntity?> GetSurveyAsync(Guid surveyId, CancellationToken cancellationToken)
      => Task.FromResult(_surveyEntityCollection.FirstOrDefault(entity => entity.SurveyId == surveyId));
  }
}
