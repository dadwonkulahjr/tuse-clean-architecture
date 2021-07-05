using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGentelellaCleanArchitecture.Domain.Enities;

namespace MyGentelellaCleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            builder.HasKey(s => s.StudentId)
                   .HasName("PrimaryKey_StudentId");

            builder.Property(s => s.FirstName)
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)")
                    .IsRequired();

            builder.Property(s => s.LastName)
                   .HasMaxLength(50)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(s => s.Email)
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)")
                     .IsRequired();

            builder.Property(s => s.DateEnrolled)
                .HasComment("Date student enrolled in the institution.")
                   .HasColumnType("Date");

            builder.Ignore(s => s.FullName);

            builder.ToTable("tblStudent");


        }
    }
}
