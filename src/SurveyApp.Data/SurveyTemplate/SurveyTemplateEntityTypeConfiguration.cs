// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Data
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using Microsoft.EntityFrameworkCore.ValueGeneration;

  /// <summary>Allows configuration for an entity type.</summary>
  public sealed class SurveyTemplateEntityTypeConfiguration : IEntityTypeConfiguration<SurveyTemplateEntity>
  {
    /// <summary>Configures the entity of type <see cref="Survey.Infrastructure.Survey.SurveyEntity"/>.</summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<SurveyTemplateEntity> builder)
    {
      builder.ToTable("surveys");
      builder.HasKey(e => e.SurveyId);

      builder.Property(entity => entity.SurveyId)
             .HasColumnName("id")
             .ValueGeneratedOnAdd()
             .HasValueGenerator<GuidValueGenerator>();

      builder.Property(entity => entity.Name)
             .HasColumnName("name")
             .IsRequired()
             .HasMaxLength(128);

      builder.Property(entity => entity.Description)
             .HasColumnName("description")
             .HasMaxLength(256);
    }
  }
}
