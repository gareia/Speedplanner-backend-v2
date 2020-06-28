
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
        //public DbSet<InscriptionProcess> InscriptionProcesses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<LearningProgramCourse> LearningProgramCourses { get; set; }
        //public DbSet<InscriptionProcessCourse> InscriptionProcessCourses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<Period> Periods { get; set; }
        //public DbSet<Classroom> Classrooms { get; set; }
        //public DbSet<ClassroomSectionSchedule> ClassroomSectionSchedules { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionSchedule> SectionSchedules { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        //public DbSet<Professor> Professors { get; set; }


        //Add for each class
        /*
         * 
        public DbSet<Constraint> Constraints { get; set; }
        
        public DbSet<CoursePossibleSchedule> CoursePossibleSchedules { get; set; }
        
        public DbSet<PossibleSchedule> PossibleSchedules { get; set; }
        
        public DbSet<SectionRequest> SectionRequests { get; set; }
        
        public DbSet<Statistic> Statistics { get; set; }
     
        public DbSet<DayConstraint> DayConstraints { get; set; }
        public DbSet<HourRangeConstraint> HourRangeConstraints { get; set; }
        public DbSet<ProfessorConstraint> ProfessorConstraints { get; set; }
         */

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

            builder.Entity<Classroom>()
                .HasOne(c => c.EducationProvider)
                .WithMany(ep => ep.Classrooms)
                .HasForeignKey(c => c.EducationProviderId);

            builder.Entity<Classroom>().HasData
                (
                new Classroom { Id=1, Type="jeje", ClassroomName="E37", Capacity=40, EducationProviderId = 1},
                new Classroom { Id=2, Type="jeje", ClassroomName="C31", Capacity=42, EducationProviderId = 1},
                new Classroom { Id=3, Type="jeje", ClassroomName="B12", Capacity=25, EducationProviderId = 1}
                );
            //------------------ ---------------

            //CLASSROOM COURSE ---------------
            builder.Entity<ClassroomSectionSchedule>().ToTable("classroom_s_schedules");
            builder.Entity<ClassroomSectionSchedule>().HasKey(csc => new { csc.ClassroomId, csc.SScheduleId });
            
            builder.Entity<ClassroomSectionSchedule>()
                .HasOne(csc => csc.Classroom)
                .WithMany(c => c.ClassroomSectionSchedules)
                .HasForeignKey(csc => csc.ClassroomId);
            
            builder.Entity<ClassroomSectionSchedule>()
                .HasOne(csc => csc.SSchedule)
                .WithMany(c => c.ClassroomSectionSchedules)
                .HasForeignKey(csc => csc.SScheduleId);

            builder.Entity<ClassroomSectionSchedule>().HasData
                (
                new ClassroomSectionSchedule { ClassroomId=1, SScheduleId=1},
                new ClassroomSectionSchedule { ClassroomId=1, SScheduleId=3 },
                new ClassroomSectionSchedule { ClassroomId = 2, SScheduleId = 2 },
                new ClassroomSectionSchedule { ClassroomId = 2, SScheduleId = 5 },
                new ClassroomSectionSchedule { ClassroomId = 3, SScheduleId = 4 },
                new ClassroomSectionSchedule { ClassroomId = 3, SScheduleId = 6 }
                );

            //------------------ ---------------
            /*
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
                .HasForeignKey<Professor>(p => p.ConstraintId);*/
            //------------------ ---------------


            //COURSE ---------------
            builder.Entity<Course>().ToTable("courses");
            builder.Entity<Course>().HasKey(c => c.Id);

            builder.Entity<Course>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Course>().Property(c => c.Code).IsRequired().HasMaxLength(10);
            builder.Entity<Course>().Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Course>().Property(c => c.IsOptional).IsRequired();
            builder.Entity<Course>().Property(c => c.IsVirtual).IsRequired();
            builder.Entity<Course>().Property(c => c.Semester).IsRequired();
            builder.Entity<Course>().Property(c => c.Credits).IsRequired();
            builder.Entity<Course>().Property(c => c.TotalNumberOfStudents);
            builder.Entity<Course>().Property(c => c.HigherCourseId);

            builder.Entity<Course>()
                .HasOne(rc => rc.HigherCourse)
                .WithMany(hc => hc.Requisites)
                .HasForeignKey(rc => rc.HigherCourseId);
            builder.Entity<Course>()
                .HasOne(c => c.EducationProvider)
                .WithMany(ep => ep.Courses)
                .HasForeignKey(c => c.EducationProviderId);


            builder.Entity<Course>().HasData
                (
                new Course { Id = 1, Code = "MATBASIC", Name = "Matematica Basica", IsOptional = false, IsVirtual = false, 
                    Semester = 1, Credits = 4, HigherCourseId = null, EducationProviderId=1 },
                new Course { Id = 2, Code = "MATCALC1", Name = "Calculo 1", IsOptional = false, IsVirtual = false, 
                    Semester = 4, Credits = 6, HigherCourseId = 1, EducationProviderId = 1 }
                );

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
            
           */

            //EDUCATION PROVIDER ---------------
            builder.Entity<EducationProvider>().ToTable("education_providers");
            builder.Entity<EducationProvider>().HasKey(ep => ep.Id);

            builder.Entity<EducationProvider>().Property(ep => ep.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<EducationProvider>().Property(ep => ep.Name).IsRequired().HasMaxLength(40);
            builder.Entity<EducationProvider>().Property(ep => ep.NumberOfCareers).IsRequired();
            builder.Entity<EducationProvider>().Property(ep => ep.CurrentPeriodId).IsRequired();

            builder.Entity<EducationProvider>()
               .HasOne(ep => ep.Subscription)
               .WithOne(s => s.EducationProvider)
               .HasForeignKey<Subscription>(s => s.EducationProviderId);

            builder.Entity<EducationProvider>().HasData
                (
                new EducationProvider { Id = 1, Name = "UPC", NumberOfCareers = 38, CurrentPeriodId = 1 }
                );
            //------------------ ---------------



            //LEARNING PROGRAM ---------------
            builder.Entity<LearningProgram>().ToTable("learning_programs");
            builder.Entity<LearningProgram>().HasKey(lp => lp.Id);

            builder.Entity<LearningProgram>().Property(lp => lp.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<LearningProgram>().Property(lp => lp.Type).IsRequired();
            builder.Entity<LearningProgram>().Property(lp => lp.Name).IsRequired();
            builder.Entity<LearningProgram>().Property(lp => lp.NumberOfCourses).IsRequired();
            builder.Entity<LearningProgram>().Property(lp => lp.EducationProviderId);

            builder.Entity<LearningProgram>()
                .HasOne(lp => lp.EducationProvider)
                .WithMany(ep => ep.Careers)
                .HasForeignKey(lp => lp.EducationProviderId);

            builder.Entity<LearningProgram>().HasData
                (
                new LearningProgram { Id = 1, Type = "Carrera universitaria", Name = "Ingenieria de Software", 
                    NumberOfCourses = 45, EducationProviderId = 1 },
                new LearningProgram { Id = 2, Type = "Carrera universitaria", Name = "Publicidad", 
                    NumberOfCourses = 46, EducationProviderId = 1 }
                );

            /*
            //INSCRIPTION PROCESS ---------------
            builder.Entity<InscriptionProcess>().ToTable("inscription_processes");
            builder.Entity<InscriptionProcess>().HasKey(ip => ip.Id);

            builder.Entity<InscriptionProcess>().Property(ip => ip.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<InscriptionProcess>().Property(ip => ip.UserId);
            builder.Entity<InscriptionProcess>().Property(ip => ip.PeriodId);

            builder.Entity<InscriptionProcess>()
                .HasOne(ip => ip.Period)
                .WithMany(p => p.InscriptionProcesses)
                .HasForeignKey(ip => ip.PeriodId);

            builder.Entity<InscriptionProcess>().HasData
                (
                new InscriptionProcess { Id = 1, UserId = 1, PeriodId = 1 }, //grecia
                new InscriptionProcess { Id = 2, UserId = 3, PeriodId = 1 } //paula
                );

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
          //------------------ ---------------*/




            //LEARNING PROGRAM COURSE ---------------
            builder.Entity<LearningProgramCourse>().ToTable("l_program_courses");
            builder.Entity<LearningProgramCourse>().HasKey(lpc => new { lpc.LProgramId, lpc.CourseId });


            builder.Entity<LearningProgramCourse>()
                .HasOne(lpc => lpc.LProgram)
                .WithMany(lp => lp.LearningProgramCourses)
                .HasForeignKey(lpc => lpc.LProgramId);
           builder.Entity<LearningProgramCourse>()
                .HasOne(lpc => lpc.Course)
                .WithMany(c => c.LearningProgramCourses)
                .HasForeignKey(lpc => lpc.CourseId);

            builder.Entity<LearningProgramCourse>().HasData
                (
                new LearningProgramCourse { LProgramId = 1, CourseId = 1},
                new LearningProgramCourse { LProgramId = 1, CourseId = 2},
                new LearningProgramCourse { LProgramId = 2, CourseId = 1}
                );

            //------------------ ---------------

            /*
            //INSCRIPTION PROCESS COURSE ---------------
            builder.Entity<InscriptionProcessCourse > ().ToTable("i_process_courses");
            builder.Entity<InscriptionProcessCourse > ().HasKey(lpc => new { lpc.IProcessId, lpc.CourseId });
            builder.Entity<InscriptionProcessCourse>()
                .HasOne(lpc => lpc.IProcess)
                .WithMany(lp => lp.InscriptionProcessCourses)
                .HasForeignKey(lpc => lpc.IProcessId);
            builder.Entity<InscriptionProcessCourse>()
                 .HasOne(lpc => lpc.Course)
                 .WithMany(c => c.InscriptionProcessCourses)
                 .HasForeignKey(lpc => lpc.CourseId);

            builder.Entity<InscriptionProcessCourse>().HasData
                (
                new InscriptionProcessCourse { IProcessId=1, CourseId=2},//grecia, cal
                new InscriptionProcessCourse { IProcessId=2, CourseId=1} //paula, matbas
                );

            //------------------ ---------------

            //PERIOD ---------------
            builder.Entity<Period>().ToTable("periods");
            builder.Entity<Period>().HasKey(p => p.Id);

            builder.Entity<Period>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Period>().Property(p => p.Code).IsRequired().HasMaxLength(10);
            builder.Entity<Period>().Property(p => p.StartDate).IsRequired().HasMaxLength(8); //DDMMAAAA
            builder.Entity<Period>().Property(p => p.EndDate).IsRequired().HasMaxLength(8); //DDMMAAAA

            builder.Entity<Period>()
                .HasOne(p => p.EducationProvider)
                .WithMany(ep => ep.Periods)
                .HasForeignKey(p => p.EducationProviderId);

            builder.Entity<Period>().HasData
                (
                new Period { Id = 1, Code = "2020-0", StartDate = "06012020", EndDate = "22022020", EducationProviderId=1 },
                new Period { Id = 2, Code = "2020-1", StartDate = "02032020", EndDate = "11072020", EducationProviderId=1 }  
                );
            //------------------ ---------------

            /*
            //POSSIBLE SCHEDULE ---------------
            builder.Entity<PossibleSchedule>().ToTable("possible_schedules");
            builder.Entity<PossibleSchedule>().HasKey(ps => ps.Id);

            builder.Entity<PossibleSchedule>().Property(ps => ps.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PossibleSchedule>().Property(ps => ps.Credits).IsRequired();
            builder.Entity<PossibleSchedule>().Property(ps => ps.FinalSchedule).IsRequired();
            //------------------ ---------------*/

            /*
            //PROFESSOR ---------------
            builder.Entity<Professor>().ToTable("professors");
            builder.Entity<Professor>().HasKey(p => p.Id);

            builder.Entity<Professor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Professor>().Property(p => p.Code).IsRequired();
            builder.Entity<Professor>().Property(p => p.IdNumber).IsRequired();
            builder.Entity<Professor>().Property(p => p.Names).IsRequired();
            builder.Entity<Professor>().Property(p => p.LastNames).IsRequired();
            builder.Entity<Professor>()
                .HasMany(p => p.Sections)
                .WithOne(s => s.Professor)
                .HasForeignKey(s => s.ProfessorId);

            builder.Entity<Professor>().HasData
                (
                new Professor { Id = 1, Code = "pc274991", IdNumber = 478901, Names = "Jose", LastNames = "Cuevas" },
                new Professor { Id = 2, Code = "pc274992", IdNumber = 478902, Names = "Maria", LastNames = "Rojas" }
                //new Professor { Id = 3, Code = "pc274993", IdNumber = 478903, Names = "Luis", LastNames = "Obando" }

                );
            //------------------ ---------------
            */


            //PROFILE ---------------
            builder.Entity<Profile>().ToTable("profiles");
            builder.Entity<Profile>().HasKey(p => p.Id);

            builder.Entity<Profile>().Property(p => p.Id).IsRequired(); //must be equal to userId
            builder.Entity<Profile>().Property(p => p.Names).IsRequired().HasMaxLength(30);
            builder.Entity<Profile>().Property(p => p.LastNames).IsRequired().HasMaxLength(50);
            builder.Entity<Profile>().Property(p => p.Gender).IsRequired();//false man true woman
            builder.Entity<Profile>().Property(p => p.Semester);
            builder.Entity<Profile>().Property(p => p.IdNumber).IsRequired();

            builder.Entity<Profile>()
                .HasOne(p => p.EducationProvider)
                .WithMany(ep => ep.Profiles)
                .HasForeignKey(p => p.EducationProviderId);

            builder.Entity<Profile>()
                .HasOne(p => p.LearningProgram)
                .WithMany(lp => lp.Profiles)
                .HasForeignKey(p => p.LearningProgramId);

            builder.Entity<Profile>().HasData
                (
                new Profile { Id=1, Names="Grecia", LastNames="Guerrero", Gender=true, Semester=5, IdNumber=73206418, 
                    UserId=1, EducationProviderId=1, LearningProgramId=1},
                new Profile { Id=2, Names="Willy", LastNames="Ugarte", Gender=false, Semester=null, IdNumber=30007078, 
                    UserId=2, EducationProviderId=1, LearningProgramId=1},
                new Profile { Id=3, Names="Paula", LastNames="Alegria", Gender=true, Semester=3, IdNumber=82347035, 
                    UserId=3, EducationProviderId=1, LearningProgramId=2 }

                );
            //------------------ ---------------
            
            //ROLE ---------------
            builder.Entity<Role>().ToTable("roles");
            builder.Entity<Role>().HasKey(r => r.Id);

            builder.Entity<Role>().Property(r => r.Id).IsRequired(); //must be equal to userId
            builder.Entity<Role>().Property(r => r.Type).IsRequired().HasMaxLength(1); //0admin 1student

            builder.Entity<Role>().HasData
                (
                new Role { Id=1, Type=1, UserId=1},
                new Role { Id=2, Type=0, UserId=2},
                new Role { Id=3, Type=1, UserId=3}
                );
            //------------------ ---------------

            
            //SECTION ---------------
            builder.Entity<Section>().ToTable("sections");
            builder.Entity<Section>().HasKey(s => s.Id);

            builder.Entity<Section>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Section>().Property(s => s.SectionName).IsRequired().HasMaxLength(5);
            builder.Entity<Section>().Property(s => s.Venue).IsRequired().HasMaxLength(20);
            builder.Entity<Section>().Property(s => s.Vacancy).IsRequired();
            builder.Entity<Section>().Property(s => s.RegisteredStudents); //sum
            builder.Entity<Section>().Property(s => s.NumberOfHours).IsRequired();

            builder.Entity<Section>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Sections)
                .HasForeignKey(s => s.CourseId);

            /*
            builder.Entity<Section>()
                .HasOne(s => s.Professor)
                .WithMany(p => p.Sections)
                .HasForeignKey(s => s.ProfessorId);*/

            builder.Entity<Section>().HasData
                (
                new Section {Id = 1, SectionName="GB001", Venue="jeje", Vacancy=22, NumberOfHours=4, CourseId=1, ProfessorName="Jose Cuevas"},
                new Section { Id = 2, SectionName = "IB001", Venue = "jeje", Vacancy = 25, NumberOfHours = 6, CourseId = 2, ProfessorName = "Maria Conchita" },
                new Section { Id = 3, SectionName = "GB002", Venue = "jeje", Vacancy = 32, NumberOfHours = 4, CourseId = 1, ProfessorName = "Luis Torres" }
                 );


            //------------------ ---------------

            /*
            //SECTION REQUEST ---------------
            builder.Entity<SectionRequest>().ToTable("section_requests");
            builder.Entity<SectionRequest>().HasKey(sr => sr.Id);

            builder.Entity<SectionRequest>().Property(sr => sr.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SectionRequest>().Property(sr => sr.Message).IsRequired().HasMaxLength(200);
            builder.Entity<SectionRequest>().Property(sr => sr.StudentName).IsRequired().HasMaxLength(40);
            //------------------ ---------------
            */

            //-----------------------------------SectionSchedule------------------------------------------------ -
            builder.Entity<SectionSchedule>().ToTable("section_schedules");
            builder.Entity<SectionSchedule>().HasKey(ss => ss.Id);

            builder.Entity<SectionSchedule>().Property(ss => ss.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SectionSchedule>().Property(ss => ss.StartTime).IsRequired().HasMaxLength(4);
            builder.Entity<SectionSchedule>().Property(ss => ss.EndTime).IsRequired().HasMaxLength(4);
            builder.Entity<SectionSchedule>().Property(ss => ss.NumberOfHours).IsRequired();
            builder.Entity<SectionSchedule>().Property(ss => ss.Day).IsRequired();
            builder.Entity<SectionSchedule>().Property(ss => ss.ClassroomName).IsRequired();

            builder.Entity<SectionSchedule>()
                .HasOne(ss => ss.Section)
                .WithMany(s => s.SectionSchedules)
                .HasForeignKey(ss => ss.SectionId);

            builder.Entity<SectionSchedule>().HasData
                (
                new SectionSchedule { Id = 1, Day="Lunes", StartTime="1000", EndTime="1200", NumberOfHours=2, SectionId=1, ClassroomName="E31"},
                new SectionSchedule { Id = 2, Day = "Martes", StartTime = "1000", EndTime = "1200", NumberOfHours = 2, SectionId = 1, ClassroomName = "E31" },
                new SectionSchedule { Id = 3, Day = "Miercoles", StartTime = "1100", EndTime = "1300", NumberOfHours = 2, SectionId = 3, ClassroomName = "B12" },
                new SectionSchedule { Id = 4, Day = "Jueves", StartTime = "1100", EndTime = "1300", NumberOfHours = 2, SectionId = 3, ClassroomName = "B12" },
                new SectionSchedule { Id = 5, Day = "Viernes", StartTime = "1700", EndTime = "2000", NumberOfHours = 3, SectionId = 2, ClassroomName = "D45" },
                new SectionSchedule { Id = 6, Day = "Sabado", StartTime = "1700", EndTime = "2000", NumberOfHours = 3, SectionId = 2, ClassroomName = "D45" }
                );

            /*
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
                */

            //---------------------------------------Subscription------------------------------------------
            builder.Entity<Subscription>().ToTable("subscriptions");
            builder.Entity<Subscription>().HasKey(s => s.Id);

            builder.Entity<Subscription>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subscription>().Property(s => s.Cost).IsRequired();
            builder.Entity<Subscription>().Property(s => s.StartDate).IsRequired().HasMaxLength(8);
            builder.Entity<Subscription>().Property(s => s.EndDate).IsRequired().HasMaxLength(8);

            builder.Entity<Subscription>().HasData
                (
                new Subscription { Id=1, Cost=1450.0, StartDate="01012020", EndDate="01012021", EducationProviderId=1}
                );



            //-----------------------------------User-------------------------------------------- -
            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().HasKey(u => u.Id);

            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(15);
            builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(8);

            /*
            builder.Entity<User>()
               .HasOne(u => u.InscriptionProcess)
               .WithOne(ip => ip.User)
               .HasForeignKey<InscriptionProcess>(ip => ip.UserId);*/

            builder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);

            builder.Entity<User>()
                .HasOne(u => u.Role)
                .WithOne(r => r.User)
                .HasForeignKey<Role>(r => r.UserId);

            builder.Entity<User>().HasData
                (
                new User { Id = 1, Username="u201620605", Email="greciaguerreroa@gmail.com", Password="11111"},
                new User { Id = 2, Username="pc00010045", Email="pcwilly@upc.edu.pe", Password="22222"},
                new User { Id = 3, Username = "u201824845", Email = "paulapesada@gmail.com", Password = "33333" }

                );

            /*             
            builder.Entity<User>()
                .HasOne(u => u.Statistic)
                .WithOne(s => s.User)
                .HasForeignKey<Statistic>(s => s.UserId);
            */


            // Db Naming convention
            builder.ApplySnakeCaseNamingConvention();

            /*BORRAR TALVEZ
             * 
             * 
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
               //DAY CONSTRAINT ---------------
            builder.Entity<Constraint>()
                .HasDiscriminator<string>("constraint_type")
                .HasValue<Constraint>("constraint_base")
                .HasValue<DayConstraint>("constraint_day");

            builder.Entity<HourRangeConstraint>().ToTable("day_constraints");
            builder.Entity<DayConstraint>().Property(dc => dc.Days).IsRequired();
            
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
              */



        }
    }

}
