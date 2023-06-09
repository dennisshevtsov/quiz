// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Infrastructure.Entities
{
  using Survey.Domain.Entities;

  /// <summary>Represents a survey entity.</summary>
  public sealed class SurveyEntity : ISurveyEntity
  {
    /// <summary>Initializes a new instance of the <see cref="Survey.Infrastructure.Entities.SurveyEntity"/> class.</summary>
    public SurveyEntity()
    {
      Name = string.Empty;
      Description = string.Empty;
      Questions = new IQuestionEntity[0];
    }

    /// <summary>Initializes a new instance of the <see cref="Survey.Infrastructure.Entities.SurveyEntity"/> class.</summary>
    /// <param name="surveyData">An object that represents survey data.</param>
    public SurveyEntity(ISurveyData surveyData)
    {
      Name = surveyData.Name;
      Description = surveyData.Description;
      Questions = surveyData.Questions;
    }

    /// <summary>Initializes a new instance of the <see cref="Survey.Infrastructure.Entities.SurveyEntity"/> class.</summary>
    /// <param name="surveyEntity">An object that represents a survey entity.</param>
    public SurveyEntity(ISurveyEntity surveyEntity)
    {
      SurveyId = surveyEntity.SurveyId;
      Name = surveyEntity.Name;
      Description = surveyEntity.Description;
      Questions = surveyEntity.Questions;
    }

    /// <summary>Gets an object that represents an identity of a survey.</summary>
    public Guid SurveyId { get; set; }

    /// <summary>Gets an object that represents a name of a survey.</summary>
    public string Name { get; set; }

    /// <summary>Gets an object that represents a description of survey.</summary>
    public string Description { get; set; }

    /// <summary>Gets an object that represents a collection of questions.</summary>
    public IQuestionEntity[] Questions { get; set; }
  }
}
