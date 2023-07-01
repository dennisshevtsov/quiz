// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.Web;

namespace SurveyApp.Survey.Web;

/// <summary>Represents data to delete a survey.</summary>
public sealed class DeleteSurveyRequestDto : IRequestDto, ISurveyIdentity
{
  /// <summary>Gets an object that represents an identity of a survey.</summary>
  public Guid SurveyId { get; set; }
}
