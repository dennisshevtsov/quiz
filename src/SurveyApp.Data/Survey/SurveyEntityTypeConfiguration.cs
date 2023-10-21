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
    builder.ToTable("survey");
    builder.HasKey(entity => entity.SurveyId);

    builder.Property(entity => entity.SurveyId)
           .HasColumnName("id")
           .IsRequired();

    builder.Property(entity => entity.State)
           .HasColumnName("state")
           .IsRequired();

    builder.Property(entity => entity.Title)
           .HasColumnName("title")
           .IsRequired();

    builder.Property(entity => entity.Description)
           .HasColumnName("description")
           .IsRequired();

    builder.Property(entity => entity.IntervieweeName)
           .HasColumnName("intervieweeName")
           .IsRequired();

    builder.Property(entity => entity.Questions)
           .HasColumnName("questions")
           .HasColumnType("jsonb")
           .IsRequired();
  }
}
