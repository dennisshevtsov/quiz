// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp
{
  /// <summary>Provides a simple GRUD API.</summary>
  /// <typeparam name="TEntity">An entity type.</typeparam>
  /// <typeparam name="TIdentity">An identity type.</typeparam>
  public interface IService<TEntity, TIdentity>
  {
    /// <summary>Gets an entity.</summary>
    /// <param name="identity">An object that represents an identity to get.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="BookApi.Author.IAuthorEntity"/>. The result can be null.</returns>
    public Task<TEntity?> GetAsync(TIdentity identity, CancellationToken cancellationToken);

    /// <summary>Gets an entity.</summary>
    /// <param name="identity">An object that represents an identity to get.</param>
    /// <param name="relations">An object that represents a collection of relations to load.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="BookApi.Author.IAuthorEntity"/>. The result can be null.</returns>
    public Task<TEntity?> GetAsync(TIdentity identity, IEnumerable<string> relations, CancellationToken cancellationToken);

    /// <summary>Adds an entity.</summary>
    /// <param name="data">An object that represents an entity from that a new entity should be created.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="BookApi.Author.IAuthorEntity"/>.</returns>
    public Task<TEntity> AddAsync(TEntity data, CancellationToken cancellationToken);

    /// <summary>Updates an entity.</summary>
    /// <param name="originalEntity">An object that represents an entity to update.</param>
    /// <param name="newEntity">An object that represents an entity from that the original one should be updated.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateAsync(TEntity originalEntity, TEntity newEntity, CancellationToken cancellationToken);

    /// <summary>Updates an entity partially.</summary>
    /// <param name="originalEntity">An object that represents an entity to update.</param>
    /// <param name="newEntity">An object that represents an entity from that the original one should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateAsync(TEntity originalEntity, TEntity newEntity, IEnumerable<string> properties, CancellationToken cancellationToken);

    /// <summary>Deletes an entity.</summary>
    /// <param name="identity">An object that represents an identity to delete.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task DeleteAsync(TIdentity identity, CancellationToken cancellationToken);
  }
}
