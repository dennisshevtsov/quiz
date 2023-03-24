// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Infrastructure
{
  using Microsoft.EntityFrameworkCore;

  using Survey.Infrastructure.Configurations;

  /// <summary>Represents a session with the database and can be used to query and save instances of your entities.</summary>
  public sealed class ApplicationDbContext : DbContext
  {
    /// <summary>Configures the model.</summary>
    /// <param name="modelBuilder">An object that provides a simple API surface for configuring the model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new SurveyEntityTypeConfiguration());
    }
  }
}
