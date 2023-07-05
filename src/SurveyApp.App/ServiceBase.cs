// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.App;

/// <summary>Provides a simple GRUD API.</summary>
/// <typeparam name="TBusinessEntity">A business entity.</typeparam>
/// <typeparam name="TEntity">An entity type.</typeparam>
/// <typeparam name="TIdentity">An identity type.</typeparam>
public abstract class ServiceBase<TBusinessEntity, TEntity, TIdentity> : IService<TEntity, TIdentity>
  where TBusinessEntity : EntityBase, TEntity, IComparable<TEntity>
  where TEntity         : TIdentity
{
  private readonly IRepository<TEntity, TIdentity> _repository;

  /// <summary>Initializes a new instance of the <see cref="BookApi.App.ServiceBase{TEntity, TData, TEntity}"/> class.</summary>
  /// <param name="repository">An object that provides a simple API to store instances of the <see cref="TEntity"/>.</param>
  protected ServiceBase(IRepository<TEntity, TIdentity> repository)
  {
    _repository = repository ?? throw new ArgumentNullException(nameof(repository));
  }

  /// <summary>Gets an entity.</summary>
  /// <param name="identity">An object that represents an identity to get.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="BookApi.Author.IAuthorEntity"/>. The result can be null.</returns>
  public virtual Task<TEntity?> GetAsync(TIdentity identity, CancellationToken cancellationToken)
  {
    TBusinessEntity businessEntity = EntityBase.Create<TIdentity, TBusinessEntity>(identity);

    return _repository.GetAsync(identity, businessEntity.Relations(), cancellationToken);
  }

  /// <summary>Gets an entity.</summary>
  /// <param name="identity">An object that represents an identity to get.</param>
  /// <param name="relations">An object that represents a collection of relations to load.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="BookApi.Author.IAuthorEntity"/>. The result can be null.</returns>
  public Task<TEntity?> GetAsync(TIdentity identity, IEnumerable<string> relations, CancellationToken cancellationToken) =>
    _repository.GetAsync(identity, relations, cancellationToken);

  /// <summary>Adds an entity.</summary>
  /// <param name="entity">An object that represents data from that a new entity should be created.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="BookApi.Author.IAuthorEntity"/>.</returns>
  public virtual Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    => _repository.AddAsync(entity, cancellationToken);

  /// <summary>Updates an entity.</summary>
  /// <param name="originalEntity">An object that represents an entity to update.</param>
  /// <param name="updatedEntity">An object that represents an entity from that the original one should be updated.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation.</returns>
  public virtual Task UpdateAsync(TEntity originalEntity, TEntity updatedEntity, CancellationToken cancellationToken)
  {
    TBusinessEntity     businessEntity    = EntityBase.Create<TEntity, TBusinessEntity>(originalEntity);
    IEnumerable<string> updatedProperties = businessEntity.Compare(updatedEntity!);

    return _repository.UpdateAsync(originalEntity, updatedEntity, updatedProperties, cancellationToken);
  }

  /// <summary>Updates an entity partially.</summary>
  /// <param name="originalEntity">An object that represents an entity to update.</param>
  /// <param name="updatedEntity">An object that represents an entity from that the original one should be updated.</param>
  /// <param name="properties">An object that represents a collection of properties to update.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation.</returns>
  public virtual Task UpdateAsync(TEntity originalEntity, TEntity updatedEntity, IEnumerable<string> properties, CancellationToken cancellationToken)
  {
    TBusinessEntity     businessEntity    = EntityBase.Create<TEntity, TBusinessEntity>(originalEntity);
    IEnumerable<string> updatedProperties = businessEntity.Compare(updatedEntity!, properties);

    return _repository.UpdateAsync(originalEntity, updatedEntity, updatedProperties, cancellationToken);
  }

  /// <summary>Deletes an entity.</summary>
  /// <param name="identity">An object that represents an identity to delete.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation.</returns>
  public virtual Task DeleteAsync(TIdentity identity, CancellationToken cancellationToken)
    => _repository.DeleteAsync(identity, cancellationToken);
}
