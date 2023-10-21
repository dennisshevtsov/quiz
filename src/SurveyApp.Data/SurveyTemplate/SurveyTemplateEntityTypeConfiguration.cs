// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SurveyApp.SurveyTemplate.Data;

public sealed class SurveyTemplateEntityTypeConfiguration : IEntityTypeConfiguration<SurveyTemplateEntity>
{
  public void Configure(EntityTypeBuilder<SurveyTemplateEntity> builder)
  {
    
  }
}
