// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.App;

namespace SurveyApp.Survey.App;

/// <summary>Provides a simple GRUD API for the <see cref="SurveyApp.Survey.ISurveyEntity"/>.</summary>
public sealed class SurveyService : ServiceBase<SurveyEntity, ISurveyEntity, ISurveyIdentity>, ISurveyService
{
  /// <summary>Initializes a new instance of the <see cref="SurveyApp.Survey.App.SurveyService"/> class.</summary>
  /// <param name="repository">An object that rrovides a simple API to persistence of the <see cref="SurveyApp.Survey.ISurveyEntity"/>.</param>
  public SurveyService(ISurveyRepository repository) : base(repository) { }
}
