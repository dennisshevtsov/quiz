// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Web.Dtos
{
  using SurveyApp.Domain.Question;
  using SurveyApp.Domain.Survey;

  /// <summary>Represents data to update a survey.</summary>
  public sealed class UpdateSurveyRequestDto : ISurveyEntity
  {
    /// <summary>Initializes a new instance of the <see cref="SurveyApp.Web.Dtos.UpdateSurveyRequestDto"/> class.</summary>
    public UpdateSurveyRequestDto()
    {
      Name = string.Empty;
      Description = string.Empty;
      Questions = new IQuestionEntity[0];
    }

    /// <summary>Initializes a new instance of the <see cref="SurveyApp.Web.Dtos.UpdateSurveyRequestDto"/> class.</summary>
    /// <param name="surveyData">An object that represents survey data.</param>
    public UpdateSurveyRequestDto(ISurveyEntity surveyEntity)
    {
      SurveyId = surveyEntity.SurveyId;
      Name = surveyEntity.Name;
      Description = surveyEntity.Description;
      Questions = surveyEntity.Questions;
    }

    /// <summary>Gets/sets an object that represents an identity of a survey.</summary>
    public Guid SurveyId { get; set; }

    /// <summary>Gets/sets an object that represents a name of a survey.</summary>
    public string Name { get; set; }

    /// <summary>Gets/sets an object that represents a description of survey.</summary>
    public string Description { get; set; }

    /// <summary>Gets an object that represents a collection of questions.</summary>
    public IQuestionEntity[] Questions { get; set; }
  }
}
