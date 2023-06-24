// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

/// <summary>Represents a collection of surveys.</summary>
public sealed class GetSurveyCollectionResponseDto
{
  /// <summary>Initializes a new instance of the <see cref="SurveyApp.Survey.Web.GetSurveyCollectionResponseDto"/> class.</summary>
  /// <param name="surveyEntityCollection">An object that represents a collection of the <see cref="SurveyApp.Survey.ISurveyEntity"/> class.</param>
  public GetSurveyCollectionResponseDto(ISurveyEntity[] surveyEntityCollection)
  {
    Surveys = GetSurveyCollectionResponseDto.ToViewModelCollection(surveyEntityCollection);
  }

  /// <summary>Gets an object that represents a collection of the <see cref="SurveyApp.Survey.Web.GetSurveyResponseDto"/>.</summary>
  public GetSurveyResponseDto[] Surveys { get; }

  private static GetSurveyResponseDto[] ToViewModelCollection(ISurveyEntity[] surveyEntityCollection)
  {
    var getSurveyViewModelCollection = new GetSurveyResponseDto[surveyEntityCollection.Length];

    for (int i = 0; i < surveyEntityCollection.Length; i++)
    {
      getSurveyViewModelCollection[i] = new GetSurveyResponseDto(surveyEntityCollection[i]);
    }

    return getSurveyViewModelCollection;
  }
}
