// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.App;

/// <summary>Provides a simple API to compare an entity.</summary>
/// <typeparam name="TEntity">A type of an entity from which this entity should be compared.</typeparam>
public interface IComparable<TEntity>
{
  /// <summary>Updates this entity.</summary>
  /// <param name="updatedEntity">An object that represents an entity from which this entity should be compared.</param>
  /// <returns>An object that represents a collection of updated properties.</returns>
  public IEnumerable<string> Compare(TEntity updatedEntity);

  /// <summary>Updates this entity.</summary>
  /// <param name="updatedEntity">An object that represents an entity from which this entity should be compared.</param>
  /// <param name="properties">An object that represents a collection of properties to compare.</param>
  /// <returns>An object that represents a collection of updated properties.</returns>
  public IEnumerable<string> Compare(TEntity updatedEntity, IEnumerable<string> properties);
}
