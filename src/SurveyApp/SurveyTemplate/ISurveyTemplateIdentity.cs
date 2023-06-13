// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate
{
  /// <summary>Represents a survey identity.</summary>
  public interface ISurveyTemplateIdentity
  {
    /// <summary>Gets an object that represents an identity of a survey.</summary>
    public Guid SurveyId { get; }
  }
}
