// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Web.Dtos
{
  using SurveyApp.Survey;

  /// <summary>Represents a survey.</summary>
  public sealed class GetSurveyResponseDto : ISurveyEntity
  {
    /// <summary>Initializes a new instance of the <see cref="SurveyApp.Web.Dtos.GetSurveyResponseDto"/> class.</summary>
    /// <param name="surveyEntity">An object that represents a survey entity.</param>
    public GetSurveyResponseDto(ISurveyEntity surveyEntity)
    {
      SurveyId    = surveyEntity.SurveyId;
      Name        = surveyEntity.Name;
      Description = surveyEntity.Description;
    }

    /// <summary>Gets/sets an object that represents an identity of a survey.</summary>
    public Guid SurveyId { get; }

    /// <summary>Gets/sets an object that represents a name of a survey.</summary>
    public string Name { get; }

    /// <summary>Gets/sets an object that represents a description of survey.</summary>
    public string Description { get; }
  }
}
