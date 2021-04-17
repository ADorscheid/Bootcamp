using System;
using System.Diagnostics;
using System.IO;
using HotelReservations.Dao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace HotelReservations
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // TODO 06a: Show the Swagger setup

            // Register the Swagger Generator service. This service is responsible for genrating Swagger Documents.
            // Note: Add this service at the end after AddMvc() or AddMvcCore().
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Hotels API",
                    Version = "v1",
                    Description = "Search for a hotel and make reservations.",
                    Contact = new OpenApiContact
                    {
                        Name = "Tech Elevator",
                        Email = string.Empty,
                        Url = new Uri("https://techelevator.com/"),
                    },
                });
                string filePath = Path.Combine(AppContext.BaseDirectory, "HotelReservations.xml");
                c.IncludeXmlComments(filePath);

            });

            // Add CORS policy allowing any origin
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                  builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });


            // TODO 05: Configure Dependency injection so the controller doesn't have to 
            //          create the DAOs inside the controller.
            int x = 10;
            Debug.WriteLine($"1. x = {x}");
            services.AddTransient<IHotelDao, HotelFakeDao>( (sp) => {
                Debug.WriteLine($"2. x = {x}");
                x *= 2;
                Debug.WriteLine($"3. x = {x}");
                return new HotelFakeDao();
            });
            Debug.WriteLine($"4. x = {x}");

            services.AddTransient<IReservationDao, ReservationFakeDao>( sp => {
                return new ReservationFakeDao();
            });

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // TODO 06b: Show the Swagger setup
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = "doc";
            });

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
