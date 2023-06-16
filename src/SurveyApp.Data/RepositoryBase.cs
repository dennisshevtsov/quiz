﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SurveyApp.Data;

/// <summary>Provides a simple API to persistence of an entity.</summary>
public abstract class RepositoryBase<TEntityImpl, TEntity, TIdentity> : IRepository<TEntity, TIdentity>
  where TEntityImpl : EntityBase, TEntity, IUpdatable<TEntity>
  where TEntity     : class, TIdentity
  where TIdentity   : class
{
  /// <summary>Initializes a new instance of the <see cref="RepositoryBase{TEntity, TIdentity}"/> class.</summary>
  /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
  protected RepositoryBase(DbContext dbContext)
  {
    DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
  }

  /// <summary>Gets an object that represents a session with the database and can be used to query and save instances of your entities.</summary>
  protected DbContext DbContext { get; }

  /// <summary>Gets an entity.</summary>
  /// <param name="identity">An object that represents an identity of an entity.</param>
  /// <param name="relations">An object that represents a collection of relations to load.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future.</returns>
  public async Task<TEntity?> GetAsync(TIdentity identity, IEnumerable<string> relations, CancellationToken cancellationToken)
  {
    var dataEntity = EntityBase.Create<TIdentity, TEntityImpl>(identity);
    var query = DbContext.Set<TEntityImpl>()
                         .AsNoTracking()
                         .Where(entity => entity.Id == dataEntity.Id);

    foreach (var relation in dataEntity.Relations(relations))
    {
      query = query.Include(relation);
    }

    return await query.SingleOrDefaultAsync(cancellationToken);
  }

  /// <summary>Adds an entity.</summary>
  /// <param name="entity">An object that represents an entity.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future.</returns>
  public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
  {
    var dataEntity = EntityBase.Create<TEntity, TEntityImpl>(entity);
    var dataEntityEntry = DbContext.Entry(dataEntity);

    dataEntityEntry.State = EntityState.Added;
    SetCollectionsAsUnchanged(dataEntityEntry);

    await DbContext.SaveChangesAsync(cancellationToken);
    dataEntityEntry.State = EntityState.Detached;

    return dataEntity;
  }

  /// <summary>Updates an entity.</summary>
  /// <param name="originalEntity">An object that represents an entity to update.</param>
  /// <param name="newEntity">An object that represents an entity from which the original entity should be updated.</param>
  /// <param name="properties">An object that represents a collection of properties to update.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation.</returns>
  public async Task UpdateAsync(TEntity originalEntity, TEntity newEntity, IEnumerable<string> properties, CancellationToken cancellationToken)
  {
    var originalDataEntity = EntityBase.Create<TEntity, TEntityImpl>(originalEntity);
    var originalDataEntityEntry = DbContext.Attach(originalDataEntity);

    originalDataEntity.Update(newEntity, properties);
    SetCollectionsAsUnchanged(originalDataEntityEntry);

    await DbContext.SaveChangesAsync(cancellationToken);
    originalDataEntityEntry.State = EntityState.Detached;
  }

  /// <summary>Deletes an entity.</summary>
  /// <param name="identity">An object that represents an identity of an entity.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation.</returns>
  public virtual Task DeleteAsync(TIdentity identity, CancellationToken cancellationToken)
  {
    var id = EntityBase.Create<TIdentity, TEntityImpl>(identity).Id;

    return DbContext.Set<TEntityImpl>()
                    .Where(entity => entity.Id == id)
                    .ExecuteDeleteAsync(cancellationToken);
  }

  private void SetCollectionsAsUnchanged(EntityEntry<TEntityImpl> entry)
  {
    foreach (var collectionEntry in entry.Collections)
    {
      if (collectionEntry.CurrentValue != null)
      {
        foreach (var collectionItemEntity in collectionEntry.CurrentValue)
        {
          DbContext.Entry(collectionItemEntity).State = EntityState.Unchanged;
        }
      }
    }
  }
}
