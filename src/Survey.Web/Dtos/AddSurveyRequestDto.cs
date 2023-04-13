// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Web.Dtos
{
  using System.ComponentModel.DataAnnotations;

  using Survey.Domain.Entities;

  /// <summary>Represents data to add a survey.</summary>
  public sealed class AddSurveyRequestDto : ISurveyData
  {
    /// <summary>Initializes a new instance of the <see cref="Survey.Web.Dtos.AddSurveyRequestDto"/> class.</summary>
    public AddSurveyRequestDto() {}

    /// <summary>Gets an object that represents a name of a survey.</summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>Gets an object that represents a description of survey.</summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>Gets an object that represents a collection of questions.</summary>
    public IQuestionEntity[] Questions { get; set; } = new IQuestionEntity[0];
  }
}
