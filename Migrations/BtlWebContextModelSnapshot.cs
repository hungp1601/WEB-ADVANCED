﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using btl_web.Models;

#nullable disable

namespace btl_web.Migrations
{
    [DbContext(typeof(BtlWebContext))]
    partial class BtlWebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("btl_web.Models.Assign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime")
                        .HasColumnName("due_date");

                    b.Property<bool?>("IsHidden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("is_hidden")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("LessonId")
                        .HasColumnType("int")
                        .HasColumnName("lesson_id");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime")
                        .HasColumnName("start_date");

                    b.Property<string>("Url")
                        .HasColumnType("varchar(max)")
                        .HasColumnName("url");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("UserId");

                    b.ToTable("assign", (string)null);
                });

            modelBuilder.Entity("btl_web.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AttendanceTime")
                        .HasColumnType("datetime")
                        .HasColumnName("attendance_time");

                    b.Property<DateTime>("DueTime")
                        .HasColumnType("datetime")
                        .HasColumnName("due_time");

                    b.Property<int>("LessonId")
                        .HasColumnType("int")
                        .HasColumnName("lesson_id");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(max)")
                        .HasColumnName("status");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("UserId");

                    b.ToTable("attendance", (string)null);
                });

            modelBuilder.Entity("btl_web.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime")
                        .HasColumnName("end_date");

                    b.Property<bool?>("IsHidden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("is_hidden")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime")
                        .HasColumnName("start_date");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("teacher_id");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("course", (string)null);
                });

            modelBuilder.Entity("btl_web.Models.CourseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("course_category", (string)null);
                });

            modelBuilder.Entity("btl_web.Models.CourseHasCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategorieId")
                        .HasColumnType("int")
                        .HasColumnName("categorie_id");

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.HasIndex("CourseId");

                    b.ToTable("course_has_categories", (string)null);
                });

            modelBuilder.Entity("btl_web.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool?>("IsHidden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("is_hidden")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("lesson", (string)null);
                });

            modelBuilder.Entity("btl_web.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("role", (string)null);
                });

            modelBuilder.Entity("btl_web.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("password");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("btl_web.Models.UserHasCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("user_has_course", (string)null);
                });

            modelBuilder.Entity("btl_web.Models.Assign", b =>
                {
                    b.HasOne("btl_web.Models.Lesson", "Lesson")
                        .WithMany("Assigns")
                        .HasForeignKey("LessonId")
                        .IsRequired()
                        .HasConstraintName("FK_assign_lesson_id");

                    b.HasOne("btl_web.Models.User", "User")
                        .WithMany("Assigns")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_assign_user_id");

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("btl_web.Models.Attendance", b =>
                {
                    b.HasOne("btl_web.Models.Lesson", "Lesson")
                        .WithMany("Attendances")
                        .HasForeignKey("LessonId")
                        .IsRequired()
                        .HasConstraintName("FK_attendance_lesson_id");

                    b.HasOne("btl_web.Models.User", "User")
                        .WithMany("Attendances")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_attendance_user_id");

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("btl_web.Models.Course", b =>
                {
                    b.HasOne("btl_web.Models.User", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("FK_course_teacher_id");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("btl_web.Models.CourseHasCategory", b =>
                {
                    b.HasOne("btl_web.Models.CourseCategory", "Categorie")
                        .WithMany("CourseHasCategories")
                        .HasForeignKey("CategorieId")
                        .IsRequired()
                        .HasConstraintName("FK_course_has_categories_categorie_id");

                    b.HasOne("btl_web.Models.Course", "Course")
                        .WithMany("CourseHasCategories")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_course_has_categories_course_id");

                    b.Navigation("Categorie");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("btl_web.Models.Lesson", b =>
                {
                    b.HasOne("btl_web.Models.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_lesson_course_id");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("btl_web.Models.User", b =>
                {
                    b.HasOne("btl_web.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_user_role_id");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("btl_web.Models.UserHasCourse", b =>
                {
                    b.HasOne("btl_web.Models.Course", "Course")
                        .WithMany("UserHasCourses")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_user_has_course_course_id");

                    b.HasOne("btl_web.Models.User", "User")
                        .WithMany("UserHasCourses")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_user_has_course_user_id");

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("btl_web.Models.Course", b =>
                {
                    b.Navigation("CourseHasCategories");

                    b.Navigation("Lessons");

                    b.Navigation("UserHasCourses");
                });

            modelBuilder.Entity("btl_web.Models.CourseCategory", b =>
                {
                    b.Navigation("CourseHasCategories");
                });

            modelBuilder.Entity("btl_web.Models.Lesson", b =>
                {
                    b.Navigation("Assigns");

                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("btl_web.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("btl_web.Models.User", b =>
                {
                    b.Navigation("Assigns");

                    b.Navigation("Attendances");

                    b.Navigation("Courses");

                    b.Navigation("UserHasCourses");
                });
#pragma warning restore 612, 618
        }
    }
}