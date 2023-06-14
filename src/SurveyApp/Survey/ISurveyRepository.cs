// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey
{
  /// <summary>Provides a simple API to persistence of the <see cref="SurveyApp.Survey.ISurveyEntity"/>.</summary>
  public interface ISurveyRepository : IRepository<ISurveyEntity, ISurveyIdentity> { }
}
