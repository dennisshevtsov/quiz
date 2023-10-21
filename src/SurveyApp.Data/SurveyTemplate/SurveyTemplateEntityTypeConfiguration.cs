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
    builder.ToTable("survey_template");
    builder.HasKey(entity => entity.SurveyTemplateId);

    builder.Property(entity => entity.SurveyTemplateId)
           .HasColumnName("id")
           .IsRequired();

    builder.Property(entity => entity.Title)
           .HasColumnName("title")
           .IsRequired();

    builder.Property(entity => entity.Description)
           .HasColumnName("description")
           .IsRequired();

    builder.Property(entity => entity.Questions)
           .HasColumnName("questions")
           .HasColumnType("jsonb")
           .IsRequired();
  }
}
