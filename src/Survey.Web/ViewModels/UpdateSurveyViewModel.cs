// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.
namespace Survey.Web.ViewModels
{
  using Survey.Domain.Entities;

  /// <summary>Represents a survey view model.</summary>
  public sealed class UpdateSurveyViewModel : ISurveyEntity
  {
    /// <summary>Initializes a new instance of the <see cref="Survey.Web.ViewModels.UpdateSurveyViewModel"/> class.</summary>
    public UpdateSurveyViewModel()
    {
      Name = string.Empty;
      Description = string.Empty;
    }

    /// <summary>Initializes a new instance of the <see cref="Survey.Web.ViewModels.UpdateSurveyViewModel"/> class.</summary>
    /// <param name="surveyData">An object that represents survey data.</param>
    public UpdateSurveyViewModel(ISurveyEntity surveyEntity)
    {
      SurveyId = surveyEntity.SurveyId;
      Name = surveyEntity.Name;
      Description = surveyEntity.Description;
    }

    /// <summary>Gets/sets an object that represents an identity of a survey.</summary>
    public Guid SurveyId { get; set; }

    /// <summary>Gets/sets an object that represents a name of a survey.</summary>
    public string Name { get; set; }

    /// <summary>Gets/sets an object that represents a description of survey.</summary>
    public string Description { get; set; }
  }
}
