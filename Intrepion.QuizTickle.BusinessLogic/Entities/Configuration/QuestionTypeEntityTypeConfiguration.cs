using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Configuration;

public class QuestionTypeEntityTypeConfiguration : IEntityTypeConfiguration<QuestionType>
{
    public void Configure(EntityTypeBuilder<QuestionType> builder)
    {
        builder.ToTable("TableNamePlaceholder", x => x.IsTemporal());

        // EntityConfigurationCodePlaceholder
        // builder.Property(x => x.PropertyNamePlaceholder);

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedTableNamePlaceholder)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
