using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using speedplanner.Domain.Models;
using speedplanner.Domain.Persistence.Contexts;
using speedplanner.Domain.Repositories;
using speedplanner.Domain.Services;
using speedplanner.Persistence.Repositories;
using speedplanner.Services;

namespace speedplanner
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddDbContext<AppDbContext>(options => 
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            } );

            //REPOS-----
            services.AddScoped<IEducationProviderRepository, EducationProviderRepository>();
            services.AddScoped<ILearningProgramRepository, LearningProgramRepository>();
            //services.AddScoped<IInscriptionProcessRepository, InscriptionProcessRepository>();
            services.AddScoped<ILearningProgramCourseRepository, LearningProgramCourseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<ISectionScheduleRepository, SectionScheduleRepository>();

            //SERVICES-----
            services.AddScoped<IEducationProviderService, EducationProviderService>();
            services.AddScoped<ILearningProgramService, LearningProgramService>();
            //services.AddScoped<IInscriptionProcessService, InscriptionProcessService>();
            services.AddScoped<ILearningProgramCourseService, LearningProgramCourseService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<ISectionScheduleService, SectionScheduleService>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
