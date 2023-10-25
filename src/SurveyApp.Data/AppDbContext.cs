// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using SurveyApp.Survey.Data;
using SurveyApp.SurveyTemplate.Data;

namespace SurveyApp.Data;

public sealed class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new SurveyTemplateEntityTypeConfiguration());
    modelBuilder.ApplyConfiguration(new SurveyEntityTypeConfiguration());
  }
}
