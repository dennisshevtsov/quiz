// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using SurveyApp.Survey;

namespace SurveyApp.Web.Dtos;

/// <summary>Represents data to add a survey.</summary>
public sealed class AddSurveyRequestDto : ISurveyEntity
{
  /// <summary>Initializes a new instance of the <see cref="SurveyApp.Web.Dtos.AddSurveyRequestDto"/> class.</summary>
  public AddSurveyRequestDto() {}

  /// <summary>Gets an object that represents an identity of a survey.</summary>
  [JsonIgnore]
  public Guid SurveyId { get; set; }

  /// <summary>Gets an object that represents a name of a survey.</summary>
  [Required]
  public string Name { get; set; } = string.Empty;

  /// <summary>Gets an object that represents a description of survey.</summary>
  public string Description { get; set; } = string.Empty;
}
