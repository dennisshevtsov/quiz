// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate
{
  /// <summary>Represents a survey entity.</summary>
  public interface ISurveyTemplateEntity : ISurveyTemplateIdentity
  {
    /// <summary>Gets an object that represents a name of a survey.</summary>
    public string Name { get; }

    /// <summary>Gets an object that represents a description of survey.</summary>
    public string Description { get; }
  }
}
