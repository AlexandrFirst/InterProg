﻿// <auto-generated />
using InterProgApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InterProgApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseUser", b =>
                {
                    b.Property<int>("CoursesCourseId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("CoursesCourseId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("CourseUser");
                });

            modelBuilder.Entity("InterProgApi.Data.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CourseId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("InterProgApi.Data.Problem", b =>
                {
                    b.Property<int>("ProblemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TestJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProblemId");

                    b.HasIndex("CourseId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("InterProgApi.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InterProgApi.Data.UserProblem", b =>
                {
                    b.Property<int>("ProblemId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSolved")
                        .HasColumnType("bit");

                    b.HasKey("ProblemId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProblem");
                });

            modelBuilder.Entity("CourseUser", b =>
                {
                    b.HasOne("InterProgApi.Data.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InterProgApi.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InterProgApi.Data.Problem", b =>
                {
                    b.HasOne("InterProgApi.Data.Course", "Course")
                        .WithMany("Problems")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("InterProgApi.Data.UserProblem", b =>
                {
                    b.HasOne("InterProgApi.Data.Problem", "Problem")
                        .WithMany("UserProblems")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InterProgApi.Data.User", "User")
                        .WithMany("UserProblems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Problem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InterProgApi.Data.Course", b =>
                {
                    b.Navigation("Problems");
                });

            modelBuilder.Entity("InterProgApi.Data.Problem", b =>
                {
                    b.Navigation("UserProblems");
                });

            modelBuilder.Entity("InterProgApi.Data.User", b =>
                {
                    b.Navigation("UserProblems");
                });
#pragma warning restore 612, 618
        }
    }
}
