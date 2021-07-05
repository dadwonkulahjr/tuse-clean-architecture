using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGentelellaCleanArchitecture.Domain.Enities;

namespace MyGentelellaCleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId)
                 .HasName("PrimaryKey_CourseId");


            builder.Property(c => c.CourseName)
                     .HasMaxLength(50)
                     .HasColumnType("varchar(50)")
                     .IsRequired();

            builder.Property(c => c.CourseNumber)
                    .HasColumnName("Cr.Number")
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(c => c.CourseHour)
                .HasComment("Student course hour.")
                    .HasColumnName("Cr.Hrs")
                    .HasColumnType("int")
                     .IsRequired();

            builder.HasOne(c => c.Student)
                   .WithMany()
                   .HasForeignKey(e => e.StudentId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired()
                   .HasConstraintName("FK_studentId");

            builder.ToTable("tblCourse");

        }
    }
}
