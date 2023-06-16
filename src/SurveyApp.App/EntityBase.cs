// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.App;

/// <summary>Represents an entity base.</summary>
public abstract class EntityBase
{
  /// <summary>Gets an object that represents a collection of related entities.</summary>
  public IEnumerable<string> Relations() =>
    GetType().GetProperties()
             .Where(property => !property.PropertyType.IsValueType)
             .Where(property => property.PropertyType != typeof(string))
             .Select(property => property.Name)
             .ToHashSet(StringComparer.OrdinalIgnoreCase);

  /// <summary>Gets an object that represents a collection of related entities.</summary>
  public IEnumerable<string> Relations(IEnumerable<string> relations)
  {
    var avalable = Relations();

    return avalable.Where(relation => avalable.Contains(relation))
                   .ToHashSet(StringComparer.OrdinalIgnoreCase);
  }

  /// <summary>Updates this entity.</summary>
  /// <param name="newEntity">An object that represents an entity from which this entity should be updated.</param>
  /// <returns>An object that represents a collection of updated properties.</returns>
  protected IEnumerable<string> Update(object newEntity)
  {
    var updatingProperties = GetUpdatingProperties();
    var updatedProperties = updatingProperties;

    return Update(newEntity, updatedProperties, updatingProperties);
  }

  /// <summary>Updates this entity.</summary>
  /// <param name="newEntity">An object that represents an entity from which this entity should be updated.</param>
  /// <param name="propertiesToUpdate">An object that represents a collection of properties to update.</param>
  /// <returns>An object that represents a collection of updated properties.</returns>
  protected IEnumerable<string> Update(object newEntity, IEnumerable<string> propertiesToUpdate) =>
    Update(newEntity, propertiesToUpdate, GetUpdatingProperties());

  /// <summary>Updates this entity.</summary>
  /// <param name="newEntity">An object that represents an entity from which this entity should be updated.</param>
  /// <param name="propertiesToUpdate">An object that represents a collection of properties to update.</param>
  /// <param name="updatingProperties">An object that represents a collection of properties that can be updated.</param>
  /// <returns></returns>
  protected virtual IEnumerable<string> Update(object newEntity, IEnumerable<string> propertiesToUpdate, ISet<string> updatingProperties)
  {
    var updatedProperties = new List<string>();

    foreach (var property in propertiesToUpdate)
    {
      if (updatingProperties.Contains(property))
      {
        var originalProperty = GetType().GetProperty(property)!;
        var newProperty = newEntity.GetType().GetProperty(property)!;

        var originalValue = originalProperty.GetValue(this);
        var newValue = newProperty.GetValue(newEntity);

        if (!object.Equals(originalValue, newValue))
        {
          originalProperty.SetValue(this, newValue);
        }

        updatedProperties.Add(property);
      }
    }

    return updatedProperties;
  }

  /// <summary>Creates a copy of an entity.</summary>
  /// <param name="entity">An object that represents an entity to copy.</param>
  /// <returns>An object that represents an instance of an entity copy.</returns>
  /// <exception cref="System.NotSupportedException">Throws if there is no such entity.</exception>
  public static T2 Create<T1, T2>(T1 entity) where T2 : EntityBase, T1
  {
    ArgumentNullException.ThrowIfNull(entity);

    if (entity.GetType() == typeof(T2))
    {
      return (T2)entity;
    }

    return (T2)typeof(T2).GetConstructor(new[] { typeof(T1) })!
                         .Invoke(new object[] { entity! });
  }

  private ISet<string> GetUpdatingProperties() =>
    GetType().GetProperties()
             .Where(property => property.CanWrite)
             .Select(property => property.Name)
             .ToHashSet(StringComparer.OrdinalIgnoreCase);
}
