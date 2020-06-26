
using Microsoft.EntityFrameworkCore;
using speedplanner.Domain.Models;
using speedplanner.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace speedplanner.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<EducationProvider> EducationProviders { get; set; }
        public DbSet<LearningProgram> LearningPrograms { get; set; }
        public DbSet<InscriptionProcess> InscriptionProcesses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<LearningProgramCourse> LearningProgramCourses { get; set; }
        public DbSet<Constraint> Constraints { get; set; }
        public DbSet<Professor> Professors { get; set; }

        //Add for each class
        /*
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<ClassroomCourse> ClassroomCourses { get; set; }
        
        
        public DbSet<CoursePossibleSchedule> CoursePossibleSchedules { get; set; }
        public DbSet<DayConstraint> DayConstraints { get; set; }
        public DbSet<HourRangeConstraint> HourRangeConstraints { get; set; }
       
        public DbSet<Period> Periods { get; set; }
        public DbSet<PossibleSchedule> PossibleSchedules { get; set; }
        
        //public DbSet<ProfessorConstraint> ProfessorConstraints { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionRequest> SectionRequests { get; set; }
        public DbSet<SectionSchedule> SectionSchedules { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
     
         //*/

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /*
            //CLASSROOM ---------------
            builder.Entity<Classroom>().ToTable("classrooms");
            builder.Entity<Classroom>().HasKey(c => c.Id);

            builder.Entity<Classroom>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Classroom>().Property(c => c.Type).IsRequired();
            builder.Entity<Classroom>().Property(c => c.ClassroomName).IsRequired();
            builder.Entity<Classroom>().Property(c => c.Capacity).IsRequired();
            //------------------ ---------------

            //CLASSROOM COURSE ---------------
            builder.Entity<ClassroomCourse>().ToTable("classroom_courses");
            builder.Entity<ClassroomCourse>().HasKey(cc => new { cc.ClassroomId, cc.CourseId });
            
            builder.Entity<ClassroomCourse>()
                .HasOne(cc => cc.Classroom)
                .WithMany(c => c.ClassroomCourses)
                .HasForeignKey(cc => cc.ClassroomId);
            
            builder.Entity<ClassroomCourse>()
                .HasOne(cc => cc.Course)
                .WithMany(c => c.ClassroomCourses)
                .HasForeignKey(cc => cc.CourseId);
            //------------------ ---------------
            */

            //CONSTRAINT ---------------
            builder.Entity<Constraint>().ToTable("constraints");
            builder.Entity<Constraint>().HasKey(c => c.Id);

            builder.Entity<Constraint>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Constraint>().Property(c => c.StartTime).IsRequired().HasMaxLength(4);
            builder.Entity<Constraint>().Property(c => c.EndTime).IsRequired().HasMaxLength(4);
            builder.Entity<Constraint>().Property(c => c.NumberOfHours).IsRequired();
            builder.Entity<Constraint>().Property(c => c.Days).IsRequired().HasMaxLength(7);

            builder.Entity<Constraint>()
                .HasOne(c => c.Professor)
                .WithOne(p => p.Constraint)
                .HasForeignKey<Professor>(p => p.ConstraintId);
            //------------------ ---------------


            //COURSE ---------------
            builder.Entity<Course>().ToTable("courses");
            builder.Entity<Course>().HasKey(c => c.Id);

            builder.Entity<Course>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Course>().Property(c => c.Code).IsRequired().HasMaxLength(10);
            builder.Entity<Course>().Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Course>().Property(c => c.TotalNumberOfStudents).IsRequired();
            builder.Entity<Course>().Property(c => c.IsOptional).IsRequired();
            builder.Entity<Course>().Property(c => c.IsVirtual).IsRequired();
            builder.Entity<Course>().Property(c => c.Semester).IsRequired();
            builder.Entity<Course>().Property(c => c.Credits).IsRequired();

            builder.Entity<Course>()
                .HasOne(rc => rc.HigherCourse)
                .WithMany(hc => hc.Requisites)
                .HasForeignKey(rc => rc.HigherCourseId);

            builder.Entity<Course>()
               .HasOne(c => c.InscriptionProcess)
               .WithMany(ip => ip.Courses)
               .HasForeignKey(c => c.InscriptionProcessId);

            /*
            builder.Entity<Course>()
                .HasMany(c => c.Sections)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);*/


            //------------------ ---------------

            /*
            //COURSE POSSIBLE SCHEDULE ---------------
            builder.Entity<CoursePossibleSchedule>().ToTable("course_possible_schedules");
            builder.Entity<CoursePossibleSchedule>().HasKey(cps => new { cps.CourseId, cps.PossibleScheduleId });

            builder.Entity<CoursePossibleSchedule>()
                .HasOne(cps => cps.PossibleSchedule)
                .WithMany(ps => ps.CoursePossibleSchedules)
                .HasForeignKey(cps => cps.PossibleScheduleId);
            builder.Entity<CoursePossibleSchedule>()
                .HasOne(cps => cps.Course)
                .WithMany(c => c.CoursePossibleSchedules)
                .HasForeignKey(cps => cps.CourseId);
            //------------------ ---------------

            //DAY CONSTRAINT ---------------
            builder.Entity<Constraint>()
                .HasDiscriminator<string>("constraint_type")
                .HasValue<Constraint>("constraint_base")
                .HasValue<DayConstraint>("constraint_day");

            builder.Entity<HourRangeConstraint>().ToTable("day_constraints");
            builder.Entity<DayConstraint>().Property(dc => dc.Days).IsRequired();
            
            //------------------ ---------------
           */

            //EDUCATION PROVIDER ---------------
            builder.Entity<EducationProvider>().ToTable("education_providers");
            builder.Entity<EducationProvider>().HasKey(ep => ep.Id);

            builder.Entity<EducationProvider>().Property(ep => ep.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<EducationProvider>().Property(ep => ep.Name).IsRequired().HasMaxLength(40);

            builder.Entity<EducationProvider>().Property(ep => ep.NumberOfCareers).IsRequired();

            /*
            builder.Entity<EducationProvider>().HasData(
                new EducationProvider { Id=1, Name="UPC", NumberOfCareers=20, }
                );*/
            /*
             builder.Entity<EducationProvider>()
                 .HasOne(ep => ep.AcademicPeriod)
                 .WithOne(p => p.EducationProvider)
                 .HasForeignKey<Period>(p => p.EducationProviderId);
                //

             /*
             builder.Entity<EducationProvider>()
                 .HasMany(ep => ep.Classrooms)
                 .WithOne(c => c.EducationProvider)
                 .HasForeignKey(c => c.EducationProviderId);
             builder.Entity<EducationProvider>()
                 .HasOne(ep => ep.Subscription)
                 .WithOne(s => s.EducationProvider)
                 .HasForeignKey<Subscription>(s => s.EducationProviderId);
                 */
            //------------------ ---------------



            //LEARNING PROGRAM ---------------
            builder.Entity<LearningProgram>().ToTable("learning_programs");
            builder.Entity<LearningProgram>().HasKey(lp => lp.Id);

            builder.Entity<LearningProgram>().Property(lp => lp.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<LearningProgram>().Property(lp => lp.Type).IsRequired();
            builder.Entity<LearningProgram>().Property(lp => lp.Name).IsRequired();
            builder.Entity<LearningProgram>().Property(lp => lp.NumberOfCourses).IsRequired();

            builder.Entity<LearningProgram>()
                .HasOne(lp => lp.EducationProvider)
                .WithMany(ep => ep.Careers)
                .HasForeignKey(lp => lp.EducationProviderId);

            /*
            builder.Entity<LearningProgram>()
                .HasMany(lp => lp.Periods)
                .WithOne(p => p.LearningProgram)
                .HasForeignKey(p => p.LearningProgramId);
            //------------------ ---------------*/

            
            //INSCRIPTION PROCESS ---------------
            builder.Entity<InscriptionProcess>().ToTable("inscription_processes");
            builder.Entity<InscriptionProcess>().HasKey(ip => ip.Id);

            builder.Entity<InscriptionProcess>().Property(ip => ip.Id).IsRequired().ValueGeneratedOnAdd();
            
            /*

  builder.Entity<InscriptionProcess>()
      .HasMany(ip => ip.PossibleSchedules)
      .WithOne(ps => ps.InscriptionProcess)
      .HasForeignKey(ps => ps.InscriptionProcessId);
  builder.Entity<InscriptionProcess>()
      .HasMany(ip => ip.Constraints)
      .WithOne(c => c.InscriptionProcess)
      .HasForeignKey(c => c.InscriptionProcessId);
  builder.Entity<InscriptionProcess>()
      .HasMany(ip => ip.SectionRequests)
      .WithOne(sr => sr.InscriptionProcess)
      .HasForeignKey(sr => sr.InscriptionProcessId);
  //------------------ ---------------


  /*
  //HOUR RANGE CONSTRAINT ---------------

  builder.Entity<Constraint>()
     .HasDiscriminator<string>("constraint_type")
     .HasValue<Constraint>("constraint_base")
     .HasValue<HourRangeConstraint>("constraint_hour_range");

  builder.Entity<HourRangeConstraint>().ToTable("hour_range_constraints");
  builder.Entity<HourRangeConstraint>().Property(hrc => hrc.StartTime).IsRequired();
  builder.Entity<HourRangeConstraint>().Property(hrc => hrc.EndTime).IsRequired();
  builder.Entity<HourRangeConstraint>().Property(hrc => hrc.NumberOfHours).IsRequired();

  //------------------ ---------------
  //
 */

            //LEARNING PROGRAM COURSE ---------------
            builder.Entity<LearningProgramCourse>().ToTable("learning_program_courses");
            builder.Entity<LearningProgramCourse>().HasKey(lpc => new { lpc.LearningProgId, lpc.CourseId });
            builder.Entity<LearningProgramCourse>()
                .HasOne(lpc => lpc.LearningProgram)
                .WithMany(lp => lp.LearningProgramCourses)
                .HasForeignKey(lpc => lpc.LearningProgId);
           builder.Entity<LearningProgramCourse>()
                .HasOne(lpc => lpc.Course)
                .WithMany(c => c.LearningProgramCourses)
                .HasForeignKey(lpc => lpc.CourseId);
            //------------------ ---------------

            /*
            //PERIOD ---------------
            builder.Entity<Period>().ToTable("periods");
            builder.Entity<Period>().HasKey(p => p.Id);

            builder.Entity<Period>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Period>().Property(p => p.Code).IsRequired().HasMaxLength(10);
            builder.Entity<Period>().Property(p => p.StartDate).IsRequired();

            builder.Entity<Period>()
                .HasOne(p => p.InscriptionProcess)
                .WithOne(ip => ip.Period)
                .HasForeignKey<InscriptionProcess>(ip => ip.PeriodId);
            //------------------ ---------------

            //POSSIBLE SCHEDULE ---------------
            builder.Entity<PossibleSchedule>().ToTable("possible_schedules");
            builder.Entity<PossibleSchedule>().HasKey(ps => ps.Id);

            builder.Entity<PossibleSchedule>().Property(ps => ps.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PossibleSchedule>().Property(ps => ps.Credits).IsRequired();
            builder.Entity<PossibleSchedule>().Property(ps => ps.FinalSchedule).IsRequired();
            //------------------ ---------------

            //PROFESSOR ---------------
            builder.Entity<Professor>().ToTable("professors");
            builder.Entity<Professor>().HasKey(p => p.Id);

            builder.Entity<Professor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Professor>().Property(p => p.Code).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Professor>().Property(p => p.IdNumber).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Professor>().Property(p => p.Names).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Professor>().Property(p => p.LastNames).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Professor>()
                .HasMany(p => p.Sections)
                .WithOne(s => s.Professor)
                .HasForeignKey(s => s.ProfessorId);
            //------------------ ---------------

            //PROFESSOR CONSTRAINT
            builder.Entity<Constraint>()
                .HasDiscriminator<string>("constraint_type")
                .HasValue<Constraint>("constraint_base")
                .HasValue<ProfessorConstraint>("constraint_professor");

            builder.Entity<HourRangeConstraint>().ToTable("professor_constraints");
            builder.Entity<ProfessorConstraint>()
                .HasOne(pc => pc.Professor)
                .WithOne(p => p.ProfessorConstraint)
                .HasForeignKey<Professor>(p => p.ProfessorConstraintId);
            //------------------ ---------------

            //PROFILE ---------------
            builder.Entity<Profile>().ToTable("profiles");
            builder.Entity<Profile>().HasKey(p => p.Id);

            builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profile>().Property(p => p.Names).IsRequired().HasMaxLength(30);
            builder.Entity<Profile>().Property(p => p.LastNames).IsRequired().HasMaxLength(50);
            builder.Entity<Profile>().Property(p => p.Gender).IsRequired();
            builder.Entity<Profile>().Property(p => p.Semester).IsRequired();
            builder.Entity<Profile>().Property(p => p.IdNumber).IsRequired();
            builder.Entity<Profile>()
                .HasOne(p => p.EducationProvider)
                .WithOne(ep => ep.Profile)
                .HasForeignKey<EducationProvider>(ep => ep.ProfileId);

            builder.Entity<Profile>()
                .HasOne(p => p.LearningProgram)
                .WithOne(lp => lp.Profile)
                .HasForeignKey<LearningProgram>(lp => lp.ProfileId);
            //------------------ ---------------

            //ROLE ---------------
            builder.Entity<Role>().ToTable("roles");
            builder.Entity<Role>().HasKey(r => r.Id);

            builder.Entity<Role>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(r => r.Type).IsRequired().HasMaxLength(15);
            //------------------ ---------------

            //SECTION ---------------
            builder.Entity<Section>().ToTable("sections");
            builder.Entity<Section>().HasKey(s => s.Id);
            builder.Entity<Section>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Section>().Property(s => s.SectionName).IsRequired().HasMaxLength(5);
            builder.Entity<Section>().Property(s => s.Venue).IsRequired().HasMaxLength(20);
            builder.Entity<Section>().Property(s => s.Vacancy).IsRequired();
            builder.Entity<Section>().Property(s => s.RegisteredStudents).IsRequired();
            builder.Entity<Section>().Property(s => s.NumberOfHours).IsRequired();
            builder.Entity<Section>()
               .HasMany(s => s.SectionSchedules)
               .WithOne(ss => ss.Section)
               .HasForeignKey(ss => ss.SectionId);
            //------------------ ---------------

            //SECTION REQUEST ---------------
            builder.Entity<SectionRequest>().ToTable("section_requests");
            builder.Entity<SectionRequest>().HasKey(sr => sr.Id);

            builder.Entity<SectionRequest>().Property(sr => sr.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SectionRequest>().Property(sr => sr.Message).IsRequired().HasMaxLength(200);
            builder.Entity<SectionRequest>().Property(sr => sr.StudentName).IsRequired().HasMaxLength(40);
            //------------------ ---------------


            //-----------------------------------SectionSchedule------------------------------------------------ -
            builder.Entity<SectionSchedule>().ToTable("section_schedules");
            builder.Entity<SectionSchedule>().HasKey(ss => ss.Id);

            builder.Entity<SectionSchedule>().Property(ss => ss.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SectionSchedule>().Property(ss => ss.SectionName).IsRequired().HasMaxLength(15);
            builder.Entity<SectionSchedule>().Property(ss => ss.StartTime).IsRequired();
            builder.Entity<SectionSchedule>().Property(ss => ss.EndTime).IsRequired();
            builder.Entity<SectionSchedule>().Property(ss => ss.NumberOfHours).IsRequired();
            builder.Entity<SectionSchedule>().Property(ss => ss.Day).IsRequired();


            //----------------------------------------Statistic------------------------------------------------ -
            builder.Entity<Statistic>().ToTable("Statistics");

            builder.Entity<Statistic>().HasKey(s => s.Id);
            builder.Entity<Statistic>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Statistic>().Property(s => s.WomenPercentageInPeriod).IsRequired();
            builder.Entity<Statistic>().Property(s => s.MenPercentageInPeriod).IsRequired();
            builder.Entity<Statistic>().Property(s => s.RegisteredStudentsPeriod).IsRequired();

            builder.Entity<Statistic>()
                .HasOne(s => s.LearningProgram)
                .WithOne(lp => lp.Statistic)
                .HasForeignKey<LearningProgram>(lp => lp.StatisticId);


            //---------------------------------------Subscription------------------------------------------
            builder.Entity<Subscription>().ToTable("subscriptions");
            builder.Entity<Subscription>().HasKey(s => s.Id);

            builder.Entity<Subscription>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subscription>().Property(s => s.Cost).IsRequired();
            builder.Entity<Subscription>().Property(s => s.StartDate).IsRequired();
            builder.Entity<Subscription>().Property(s => s.EndDate).IsRequired();
            */

            //-----------------------------------User-------------------------------------------- -
            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().HasKey(u => u.Id);

            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(15);
            builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(30);

            builder.Entity<User>()
               .HasOne(u => u.InscriptionProcess)
               .WithOne(ip => ip.User)
               .HasForeignKey<InscriptionProcess>(ip => ip.UserId);


            /*              

            builder.Entity<User>()
                .HasOne(u => u.Statistic)
                .WithOne(s => s.User)
                .HasForeignKey<Statistic>(s => s.UserId);

             builder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);

            builder.Entity<User>()
                .HasOne(u => u.Role)
                .WithOne(r => r.User)
                .HasForeignKey<Role>(r => r.UserId);

             //

    */
            // Db Naming convention
            builder.ApplySnakeCaseNamingConvention();

        }
    }

}
