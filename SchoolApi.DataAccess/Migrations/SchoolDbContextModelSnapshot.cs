﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolApi.Infrastructure.Configurations;

#nullable disable

namespace SchoolApi.DataAccess.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FacultyPost", b =>
                {
                    b.Property<string>("facultiesid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("postsid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("facultiesid", "postsid");

                    b.HasIndex("postsid");

                    b.ToTable("FacultyPost");
                });

            modelBuilder.Entity("ScheduleScheduleTable", b =>
                {
                    b.Property<string>("ScheduleTableid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("schedulesschoolClassId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ScheduleTableid", "schedulesschoolClassId");

                    b.HasIndex("schedulesschoolClassId");

                    b.ToTable("ScheduleTableSchedules", (string)null);
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Faculty", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("faculties");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Post", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("fileUrlsString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Semester", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("semesters");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Subject", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("facultyid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("facultyid");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.Exam", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("room")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("schoolClassid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("schoolClassid");

                    b.ToTable("exams");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.Schedule", b =>
                {
                    b.Property<string>("schoolClassId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("dayOfWeek")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("end")
                        .HasColumnType("time");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("room")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("start")
                        .HasColumnType("time");

                    b.HasKey("schoolClassId");

                    b.ToTable("schedules");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.ScheduleTable", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("semesterid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("semesterid");

                    b.HasIndex("userid");

                    b.ToTable("scheduleTables");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClass", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("classType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("program")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("semesterid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("studentCount")
                        .HasColumnType("int");

                    b.Property<int>("studentMax")
                        .HasColumnType("int");

                    b.Property<string>("subjectid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("semesterid");

                    b.HasIndex("subjectid");

                    b.ToTable("schoolClasses");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClassRegistration", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("semesterid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("semesterid");

                    b.ToTable("schoolClassRegistrations");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClassSection", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SchoolClassid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("fileUrlsString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<float>("offset")
                        .HasColumnType("real");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("SchoolClassid");

                    b.ToTable("schoolClassSections");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.StudentSchoolClass.CreditLog", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("average")
                        .HasColumnType("real");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("final")
                        .HasColumnType("real");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<float>("midterm")
                        .HasColumnType("real");

                    b.Property<float>("practice")
                        .HasColumnType("real");

                    b.Property<float>("progress")
                        .HasColumnType("real");

                    b.Property<string>("schoolClassid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("studentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("schoolClassid");

                    b.HasIndex("studentId");

                    b.ToTable("creditLogs");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.StudentSchoolClass.SchoolmemberLog", b =>
                {
                    b.Property<string>("schoolClassId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("schoolClassId")
                        .HasColumnOrder(2);

                    b.Property<string>("schoolMemberId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("schoolMemberId")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("schoolClassId", "schoolMemberId");

                    b.ToTable("schoolmemberLogs");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.UserGroups.User", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("users");

                    b.HasDiscriminator<string>("role").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.UserGroups.UserProfile", b =>
                {
                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("avatarUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("joinYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("program")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("userProfiles");
                });

            modelBuilder.Entity("SchoolClassSchoolClassRegistration", b =>
                {
                    b.Property<string>("SchoolClassRegistrationid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("schoolClassesid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SchoolClassRegistrationid", "schoolClassesid");

                    b.HasIndex("schoolClassesid");

                    b.ToTable("SchoolClassRegistrationSchoolClasses", (string)null);
                });

            modelBuilder.Entity("SubjectSubject", b =>
                {
                    b.Property<string>("prequisiteSubjectsid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("previousSubjectsid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("prequisiteSubjectsid", "previousSubjectsid");

                    b.HasIndex("previousSubjectsid");

                    b.ToTable("SubjectSubject");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.StudentSchoolClass.LecturerLog", b =>
                {
                    b.HasBaseType("SchoolApi.Infrastructure.Entities.StudentSchoolClass.SchoolmemberLog");

                    b.HasIndex("schoolClassId")
                        .IsUnique();

                    b.HasIndex("schoolMemberId");

                    b.ToTable("LecturerLogs", (string)null);
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.StudentSchoolClass.StudentLog", b =>
                {
                    b.HasBaseType("SchoolApi.Infrastructure.Entities.StudentSchoolClass.SchoolmemberLog");

                    b.Property<float>("average")
                        .HasColumnType("real");

                    b.Property<float>("final")
                        .HasColumnType("real");

                    b.Property<float>("midterm")
                        .HasColumnType("real");

                    b.Property<float>("practice")
                        .HasColumnType("real");

                    b.Property<float>("progress")
                        .HasColumnType("real");

                    b.HasIndex("schoolMemberId");

                    b.ToTable("StudentLogs", (string)null);
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.UserGroups.Lecturer", b =>
                {
                    b.HasBaseType("SchoolApi.Infrastructure.Entities.UserGroups.User");

                    b.HasDiscriminator().HasValue("lecturer");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.UserGroups.Student", b =>
                {
                    b.HasBaseType("SchoolApi.Infrastructure.Entities.UserGroups.User");

                    b.HasDiscriminator().HasValue("student");
                });

            modelBuilder.Entity("FacultyPost", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Faculty", null)
                        .WithMany()
                        .HasForeignKey("facultiesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Post", null)
                        .WithMany()
                        .HasForeignKey("postsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScheduleScheduleTable", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.SchoolClassGroups.ScheduleTable", null)
                        .WithMany()
                        .HasForeignKey("ScheduleTableid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolApi.Infrastructure.Entities.SchoolClassGroups.Schedule", null)
                        .WithMany()
                        .HasForeignKey("schedulesschoolClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Subject", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Faculty", "faculty")
                        .WithMany("subjects")
                        .HasForeignKey("facultyid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("faculty");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.Exam", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClass", "schoolClass")
                        .WithMany("exams")
                        .HasForeignKey("schoolClassid");

                    b.Navigation("schoolClass");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.Schedule", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClass", "schoolClass")
                        .WithOne("schedule")
                        .HasForeignKey("SchoolApi.Infrastructure.Entities.SchoolClassGroups.Schedule", "schoolClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("schoolClass");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.ScheduleTable", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Semester", "semester")
                        .WithMany("scheduleTables")
                        .HasForeignKey("semesterid");

                    b.HasOne("SchoolApi.Infrastructure.Entities.UserGroups.User", "user")
                        .WithMany("scheduleTables")
                        .HasForeignKey("userid");

                    b.Navigation("semester");

                    b.Navigation("user");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClass", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Semester", "semester")
                        .WithMany("schoolClasses")
                        .HasForeignKey("semesterid");

                    b.HasOne("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Subject", "subject")
                        .WithMany("schoolClasses")
                        .HasForeignKey("subjectid");

                    b.Navigation("semester");

                    b.Navigation("subject");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClassRegistration", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Semester", "semester")
                        .WithMany()
                        .HasForeignKey("semesterid");

                    b.Navigation("semester");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClassSection", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClass", null)
                        .WithMany("sections")
                        .HasForeignKey("SchoolClassid");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.StudentSchoolClass.CreditLog", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClass", "schoolClass")
                        .WithMany("creditLogs")
                        .HasForeignKey("schoolClassid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolApi.Infrastructure.Entities.UserGroups.Student", "student")
                        .WithMany("creditLogs")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("schoolClass");

                    b.Navigation("student");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.UserGroups.UserProfile", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.UserGroups.User", null)
                        .WithOne("userProfile")
                        .HasForeignKey("SchoolApi.Infrastructure.Entities.UserGroups.UserProfile", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolClassSchoolClassRegistration", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClassRegistration", null)
                        .WithMany()
                        .HasForeignKey("SchoolClassRegistrationid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClass", null)
                        .WithMany()
                        .HasForeignKey("schoolClassesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectSubject", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Subject", null)
                        .WithMany()
                        .HasForeignKey("prequisiteSubjectsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Subject", null)
                        .WithMany()
                        .HasForeignKey("previousSubjectsid")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.StudentSchoolClass.LecturerLog", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClass", "schoolClass")
                        .WithOne("lecturerLog")
                        .HasForeignKey("SchoolApi.Infrastructure.Entities.StudentSchoolClass.LecturerLog", "schoolClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolApi.Infrastructure.Entities.UserGroups.Lecturer", "schoolMember")
                        .WithMany("LecturerLogs")
                        .HasForeignKey("schoolMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolApi.Infrastructure.Entities.StudentSchoolClass.SchoolmemberLog", null)
                        .WithOne()
                        .HasForeignKey("SchoolApi.Infrastructure.Entities.StudentSchoolClass.LecturerLog", "schoolClassId", "schoolMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("schoolClass");

                    b.Navigation("schoolMember");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.StudentSchoolClass.StudentLog", b =>
                {
                    b.HasOne("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClass", "schoolClass")
                        .WithMany("studentLogs")
                        .HasForeignKey("schoolClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolApi.Infrastructure.Entities.UserGroups.Student", "schoolMember")
                        .WithMany("studentLogs")
                        .HasForeignKey("schoolMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolApi.Infrastructure.Entities.StudentSchoolClass.SchoolmemberLog", null)
                        .WithOne()
                        .HasForeignKey("SchoolApi.Infrastructure.Entities.StudentSchoolClass.StudentLog", "schoolClassId", "schoolMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("schoolClass");

                    b.Navigation("schoolMember");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Faculty", b =>
                {
                    b.Navigation("subjects");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Semester", b =>
                {
                    b.Navigation("scheduleTables");

                    b.Navigation("schoolClasses");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.InformationTypeGroups.Subject", b =>
                {
                    b.Navigation("schoolClasses");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.SchoolClassGroups.SchoolClass", b =>
                {
                    b.Navigation("creditLogs");

                    b.Navigation("exams");

                    b.Navigation("lecturerLog")
                        .IsRequired();

                    b.Navigation("schedule")
                        .IsRequired();

                    b.Navigation("sections");

                    b.Navigation("studentLogs");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.UserGroups.User", b =>
                {
                    b.Navigation("scheduleTables");

                    b.Navigation("userProfile")
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.UserGroups.Lecturer", b =>
                {
                    b.Navigation("LecturerLogs");
                });

            modelBuilder.Entity("SchoolApi.Infrastructure.Entities.UserGroups.Student", b =>
                {
                    b.Navigation("creditLogs");

                    b.Navigation("studentLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
