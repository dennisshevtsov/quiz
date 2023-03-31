// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Web.ViewModels
{
  using Survey.Domain.Entities;

  /// <summary>Represents a survey collection view model.</summary>
  public sealed class GetSurveyCollectionViewModel
  {
    /// <summary>Initializes a new instance of the <see cref="Survey.Web.ViewModels.GetSurveyCollectionViewModel"/> class.</summary>
    /// <param name="surveyEntityCollection">An object that represents a collection of the <see cref="Survey.Domain.Entities.ISurveyEntity"/> class.</param>
    public GetSurveyCollectionViewModel(ISurveyEntity[] surveyEntityCollection)
    {
      Surveys = GetSurveyCollectionViewModel.ToViewModelCollection(surveyEntityCollection);
    }

    /// <summary>Gets an object that represents a collection of the <see cref="Survey.Web.ViewModels.GetSurveyViewModel"/>.</summary>
    public GetSurveyViewModel[] Surveys { get; }

    private static GetSurveyViewModel[] ToViewModelCollection(ISurveyEntity[] surveyEntityCollection)
    {
      var getSurveyViewModelCollection = new GetSurveyViewModel[surveyEntityCollection.Length];

      for (int i = 0; i < surveyEntityCollection.Length; i++)
      {
        getSurveyViewModelCollection[i] = new GetSurveyViewModel(surveyEntityCollection[i]);
      }

      return getSurveyViewModelCollection;
    }
  }
}
