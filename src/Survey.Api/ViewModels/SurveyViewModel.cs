// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Api.ViewModels
{
  using System.ComponentModel.DataAnnotations;

  using Survey.Domain.Entities;

  /// <summary>Represents a survey view model.</summary>
  public class SurveyViewModel : ISurveyData
  {
    /// <summary>Initializes a new instance of the <see cref="Survey.Api.ViewModels.SurveyViewModel"/> class.</summary>
    public SurveyViewModel() {}

    /// <summary>Initializes a new instance of the <see cref="Survey.Api.ViewModels.SurveyViewModel"/> class.</summary>
    /// <param name="surveyData">An object that represents survey data.</param>
    public SurveyViewModel(ISurveyData surveyData)
    {
      Name = surveyData.Name;
      Description = surveyData.Description;
    }

    /// <summary>Gets an object that represents a name of a survey.</summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>Gets an object that represents a description of survey.</summary>
    public string Description { get; set; } = string.Empty;
  }
}
