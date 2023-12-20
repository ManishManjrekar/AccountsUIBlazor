﻿using AccountApi.Application.Interfaces;
using AccountApi.Infrastructure.Repository;
using AccountsUIBlazor.UIModels;
using AutoMapper;
using Microsoft.OpenApi.Models;

namespace AccountsUIBlazor
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
            // Add services needed for your application

            // Add the IUnitOfWork as a scoped service
            services.AddTransient<IUnitOfWork, UnitOfWork>(); // Replace YourUnitOfWorkImplementation with the actual implementation class
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Add other services as needed
            // services.AddScoped<IUserRepository, UserRepository>();
            // services.AddScoped<IProductRepository, ProductRepository>();

            // Add Swagger services
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSwagger",
                    builder => builder.WithOrigins("https://localhost:7207") // Update with your Blazor app URL
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);


            // Add MVC or API controllers
            services.AddControllers();
            //services.AddHttpClient();
            services.AddScoped(sp =>
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7207/");
                return client;
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name V1"));
            }
            else
            {
                // Add production-specific configuration
                // For example, app.UseExceptionHandler("/Home/Error");
                // app.UseHsts();
            }

            // Configure other middleware as needed
            app.UseCors("AllowSwagger");
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Add endpoint mapping for controllers
            });
        }
    }
}
