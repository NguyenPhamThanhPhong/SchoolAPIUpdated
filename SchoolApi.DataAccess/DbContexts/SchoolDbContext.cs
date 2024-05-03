using Microsoft.EntityFrameworkCore;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using SchoolApi.Infrastructure.Entities.StudentSchoolClass;
using SchoolApi.Infrastructure.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Configurations
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

                modelBuilder.Entity<SchoolClassRegistration>()
                    .HasMany(s => s.schoolClasses)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("SchoolClassRegistrationSchoolClasses"));

                modelBuilder.Entity<User>()
                    .HasDiscriminator(u => u.role)
                    .HasValue<Student>("student")
                    .HasValue<Lecturer>("lecturer");
                modelBuilder.Entity<ScheduleTable>()
                    .HasMany(s => s.schedules)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("ScheduleTableSchedules"));
                this.configSchoolClass(modelBuilder);
                this.configSchoolMemberLog(modelBuilder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void configUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.userProfile)
                .WithOne()
                .HasForeignKey<UserProfile>(u => u.userId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.scheduleTables)
                .WithOne()
                .HasForeignKey();
            // student - creditlog 1-n defined in studentlog
            //lecturer - lecturerlog 1-n defined in lecturerlog
        }
        private void configSchoolClass(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolClass>()
                .HasOne(s => s.schedule)
                .WithOne(s => s.schoolClass)
                .HasForeignKey<Schedule>(s => s.schoolClassId);
        }

        private void configSchoolMemberLog(ModelBuilder modelBuilder)
        {
            // 1 schoolclass can have many logs
            modelBuilder.Entity<SchoolClass>()
                .HasMany(s => s.studentLogs)
                .WithOne(s => s.schoolClass)
                .HasForeignKey(s => s.schoolClassId);
            // 1 schoolmember can have many logs
            // 1 log can only have 1 schoolmember
            modelBuilder.Entity<StudentLog>()
                .HasOne(s => s.schoolMember)
                .WithMany(s => s.studentLogs)
                .HasForeignKey(s => s.schoolMemberId);

            modelBuilder.Entity<SchoolClass>()
                .HasOne(s => s.lecturerLog)
                .WithOne(s => s.schoolClass)
                .HasForeignKey<LecturerLog>(s => s.schoolClassId);

            modelBuilder.Entity<LecturerLog>()
                .HasOne(s => s.schoolMember)
                .WithMany(s => s.LecturerLogs)
                .HasForeignKey(s => s.schoolMemberId);

            modelBuilder.Entity<SchoolmemberLog>()
                .HasKey(s => new { s.schoolClassId, s.schoolMemberId });


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


    }
}