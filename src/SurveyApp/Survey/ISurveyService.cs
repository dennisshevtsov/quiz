// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey;

/// <summary>Provides a simple GRUD API for the <see cref="SurveyApp.Survey.ISurveyEntity"/>.</summary>
public interface ISurveyService : IService<ISurveyEntity, ISurveyIdentity> { }
