// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Web.ViewModels
{
  using System.ComponentModel.DataAnnotations;

  using Survey.Domain.Entities;

  /// <summary>Represents a survey view model.</summary>
  public sealed class AddSurveyViewModel : ISurveyData
  {
    /// <summary>Initializes a new instance of the <see cref="Survey.Web.ViewModels.AddSurveyViewModel"/> class.</summary>
    public AddSurveyViewModel() {}

    /// <summary>Initializes a new instance of the <see cref="Survey.Web.ViewModels.AddSurveyViewModel"/> class.</summary>
    /// <param name="surveyData">An object that represents survey data.</param>
    public AddSurveyViewModel(ISurveyData surveyData)
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
