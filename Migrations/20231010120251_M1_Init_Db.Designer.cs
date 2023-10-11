﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FU_DEVER_BACKEND_TRAINING.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20231010120251_M1_Init_Db")]
    partial class M1_Init_Db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FU_DEVER_BACKEND_TRAINING.Entities.ClassroomEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<short>("NumberOfStudents")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Classrooms", (string)null);
                });

            modelBuilder.Entity("FU_DEVER_BACKEND_TRAINING.Entities.StudentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<short>("Age")
                        .HasColumnType("SMALLINT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<Guid>("classroomId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("classroomId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("FU_DEVER_BACKEND_TRAINING.Entities.StudentEntity", b =>
                {
                    b.HasOne("FU_DEVER_BACKEND_TRAINING.Entities.ClassroomEntity", "ClassroomEntity")
                        .WithMany("StudentEntities")
                        .HasForeignKey("classroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassroomEntity");
                });

            modelBuilder.Entity("FU_DEVER_BACKEND_TRAINING.Entities.ClassroomEntity", b =>
                {
                    b.Navigation("StudentEntities");
                });
#pragma warning restore 612, 618
        }
    }
}