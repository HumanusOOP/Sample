﻿using EFDomain.Data;
using EFDomain.Repositories;
using EFDomain.Repositories.Interfaces;
using EFDomain.Services;
using EFDomain.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFApi
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
            services.AddDbContext<SampleContext>(options => options.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=PlayGround;Integrated Security=True"));
            services.AddTransient<IValueService, ValueService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IValueRepository, ValueRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
