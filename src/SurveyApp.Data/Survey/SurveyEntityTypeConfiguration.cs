// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SurveyApp.Survey.Data;

public sealed class SurveyEntityTypeConfiguration : IEntityTypeConfiguration<SurveyEntity>
{
  public void Configure(EntityTypeBuilder<SurveyEntity> builder)
  {
    throw new NotImplementedException();
  }
}
