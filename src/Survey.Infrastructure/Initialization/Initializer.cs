// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Infrastructure.Initialization
{
  using System;

  using Microsoft.EntityFrameworkCore;

  /// <summary>Provides a simple API to initialize the database.</summary>
  public sealed class Initializer : IInitializer
  {
    private readonly DbContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="Survey.Infrastructure.Initialization.Initializer"/> class.</summary>
    /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
    public Initializer(DbContext dbContext)
    {
      _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>Initializes the database.</summary>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task InitializeAsync(CancellationToken cancellationToken)
    {
      return _dbContext.Database.EnsureCreatedAsync(cancellationToken);
    }
  }
}
