﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.App;

namespace SurveyApp.Survey.App;

/// <summary>Represents a survey entity.</summary>
public sealed class SurveyEntity : EntityBase, ISurveyEntity, IUpdatable<ISurveyEntity>
{
  /// <summary>Initializes a new instance of the <see cref="Survey.Infrastructure.Survey.SurveyEntity"/> class.</summary>
  public SurveyEntity()
  {
    Name        = string.Empty;
    Description = string.Empty;
  }

  /// <summary>Initializes a new instance of the <see cref="Survey.Infrastructure.Survey.SurveyEntity"/> class.</summary>
  /// <param name="surveyEntity">An object that represents a survey entity.</param>
  public SurveyEntity(ISurveyEntity surveyEntity) : this()
  {
    SurveyId    = surveyEntity.SurveyId;
    Name        = surveyEntity.Name;
    Description = surveyEntity.Description;
  }

  /// <summary>Gets an object that represents an identity of a survey.</summary>
  public Guid SurveyId { get; set; }

  /// <summary>Gets an object that represents a name of a survey.</summary>
  public string Name { get; set; }

  /// <summary>Gets an object that represents a description of survey.</summary>
  public string Description { get; set; }

  /// <summary>Updates this entity.</summary>
  /// <param name="newEntity">An object that represents an entity from which this entity should be updated.</param>
  /// <returns>An object that represents a collection of updated properties.</returns>
  public IEnumerable<string> Update(ISurveyEntity newEntity) => base.Update(newEntity);

  /// <summary>Updates this entity.</summary>
  /// <param name="newEntity">An object that represents an entity from which this entity should be updated.</param>
  /// <param name="propertiesToUpdate">An object that represents a collection of properties to update.</param>
  /// <returns>An object that represents a collection of updated properties.</returns>
  public IEnumerable<string> Update(ISurveyEntity newEntity, IEnumerable<string> properties) =>
    base.Update(newEntity, properties);
}
