using FU_DEVER_BACKEND_TRAINING.Entities;
using FU_DEVER_BACKEND_TRAINING.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FU_DEVER_BACKEND_TRAINING;

public sealed class SchoolContext : DbContext
{
    public DbSet<StudentEntity> StudentEntities { get; set; }

    public DbSet<ClassroomEntity> ClassroomEntities { get; set; }

    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options: options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<StudentEntity>(builder =>
            {
                builder.ToTable("Students");

                builder.HasKey(student => student.Id);

                builder
                    .Property(student => student.Name)
                    .HasColumnType(CustomConstants.VARCHAR_30)
                    .IsRequired();


                builder
                    .Property(student => student.Age)
                    .HasColumnType(CustomConstants.SMALLINT)
                    .IsRequired();

                builder
                     .Property(student => student.ClassroomId)
                     .IsRequired();
            })
            .Entity<ClassroomEntity>(builder =>
            {
                builder.ToTable("Classrooms");

                builder.HasKey(student => student.Id);

                builder
                    .Property(student => student.Name)
                    .HasColumnType(CustomConstants.VARCHAR_20)
                    .IsRequired();

                builder
                    .HasMany(classRoom => classRoom.StudentEntities)
                    .WithOne(student => student.ClassroomEntity)
                    .HasPrincipalKey(classRoom => classRoom.Id)
                    .HasForeignKey(student => student.ClassroomId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
    }
}
