// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.Web;

namespace SurveyApp.Survey.Web;

/// <summary>Represents a codition to query a survey.</summary>
public sealed class GetSurveyRequestDto : IRequestDto, ISurveyIdentity
{
  /// <summary>Initializes a new instance of the <see cref="SurveyApp.Survey.Web.GetSurveyRequestDto"/> class.</summary>
  public GetSurveyRequestDto() {}

  /// <summary>Initializes a new instance of the <see cref="SurveyApp.Survey.Web.GetSurveyRequestDto"/> class.</summary>
  /// <param name="surveyId">An object that represents an ID of a survey.</param>
  public GetSurveyRequestDto(Guid surveyId)
  {
    SurveyId = surveyId;
  }

  /// <summary>Gets an object that represents an identity of a survey.</summary>
  public Guid SurveyId { get; set; }
}
