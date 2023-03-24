// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Infrastructure
{
  using Microsoft.EntityFrameworkCore;

  using Survey.Infrastructure.Configurations;

  /// <summary>Represents a session with the database and can be used to query and save instances of your entities.</summary>
  public sealed class SurveyDbContext : DbContext
  {
    /// <summary>Initializes a new instance of the <see cref="Survey.Infrastructure.SurveyDbContext"/> class.</summary>
    /// <param name="options">An object that retprents options to configure the DB context.</param>
    public SurveyDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>Configures the model.</summary>
    /// <param name="modelBuilder">An object that provides a simple API surface for configuring the model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new SurveyEntityTypeConfiguration());
    }
  }
}
