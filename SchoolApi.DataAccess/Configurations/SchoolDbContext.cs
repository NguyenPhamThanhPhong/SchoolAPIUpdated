using Microsoft.EntityFrameworkCore;
using SchoolApi.Domain.Entities.InformationTypeGroups;
using SchoolApi.Domain.Entities.SchoolClassGroups;
using SchoolApi.Domain.Entities.StudentSchoolClass;
using SchoolApi.Domain.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.DataAccess.Configurations
{

    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(
            DbContextOptions<SchoolDbContext> options) : base(options) { }
        DbSet<Faculty> faculties { get; set; }
        DbSet<Post> posts { get; set; }
        DbSet<Semester> semesters { get; set; }
        DbSet<Subject> subjects { get; set; }

        DbSet<Exam> exams { get; set; }
        DbSet<SchoolClass> schoolClasses { get; set; }
        DbSet<Schedule> schedules { get; set; }
        DbSet<ScheduleTable> scheduleTables { get; set; }
        DbSet<SchoolClassRegistration> schoolClassRegistrations { get; set; }
        DbSet<SchoolClassSection> schoolClassSections { get; set; }

        DbSet<CreditLog> creditLogs { get; set; }
        DbSet<SchoolmemberLog> schoolmemberLogs { get; set; }
        DbSet<LecturerLog> lecturerLogs { get; set; }
        DbSet<StudentLog> studentLogs { get; set; }

        DbSet<User> users { get; set; }
        DbSet<UserProfile> userProfiles { get; set; }
        DbSet<Student> students { get; set; }
        DbSet<Lecturer> lecturers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            try
            {
                modelBuilder.Entity<User>()
                    .HasDiscriminator(u => u.role)
                    .HasValue<Student>("student")
                    .HasValue<Lecturer>("lecturer");

                modelBuilder.Entity<SchoolClass>()
                    .HasOne(s => s.schedule)
                    .WithOne(s => s.schoolClass)
                    .HasForeignKey<Schedule>(s => s.schoolClassId);

                modelBuilder.Entity<SchoolClass>()
                    .HasMany(s => s.studentLogs)
                    .WithOne(s => s.schoolClass)
                    .HasForeignKey(s => s.schoolClassId);

                modelBuilder.Entity<SchoolClass>()
                    .HasOne(s => s.lecturerLog)
                    .WithOne(s => s.schoolClass)
                    .HasForeignKey<LecturerLog>(s => s.schoolClassId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<SchoolmemberLog>()
                .HasKey(s => new { s.schoolClassId, s.schoolMemberId });

                modelBuilder.Entity<StudentLog>()
                    .HasOne(s => s.schoolMember)
                    .WithMany(s => s.studentLogs)
                    .HasForeignKey(s => s.schoolMemberId);

                modelBuilder.Entity<LecturerLog>()
                    .HasOne(s => s.schoolMember)
                    .WithMany(s => s.LecturerLogs)
                    .HasForeignKey(s => s.schoolMemberId);


                //convergence for schoolMemberId
                modelBuilder.Entity<StudentLog>()
                    .Property(s => s.schoolMemberId)
                    .HasColumnName("schoolMemberId");

                modelBuilder.Entity<LecturerLog>()
                    .Property(s => s.schoolMemberId)
                    .HasColumnName("schoolMemberId");

                //convergence for schoolclassId
                modelBuilder.Entity<StudentLog>()
                    .Property(s => s.schoolClassId)
                    .HasColumnName("schoolClassId");
                modelBuilder.Entity<LecturerLog>()
                    .Property(s => s.schoolClassId)
                    .HasColumnName("schoolClassId");

                modelBuilder.Entity<StudentLog>().HasBaseType<SchoolmemberLog>().ToTable("StudentLogs");
                modelBuilder.Entity<LecturerLog>().HasBaseType<SchoolmemberLog>().ToTable("LecturerLogs");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}