// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;

using SurveyApp.Survey;
using SurveyApp.Survey.Data;

namespace SurveyApp.Data.Survey;

/// <summary>Provides a simple API to persistence of the <see cref="SurveyApp.Survey.ISurveyEntity"/>.</summary>
public sealed class SurveyRepository : RepositoryBase<SurveyEntity, ISurveyEntity, ISurveyIdentity>, ISurveyRepository
{
  /// <summary>Initializes a new instance of the <see cref="SurveyApp.Data.Survey.SurveyRepository"/> class.</summary>
  /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
  public SurveyRepository(DbContext dbContext) : base(dbContext) { }
}
