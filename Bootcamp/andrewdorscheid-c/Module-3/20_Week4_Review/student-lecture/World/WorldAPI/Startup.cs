using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.IO;
using WorldLib.DAL;

/****************************************
 * TODO 01 (Project): Add a new API project, reference WorldLib
 * TODO 02 (Startup): Setup DI for CitySqlDAO
 * TODO 03 (Startup): Setup Swagger
 ***************************************/


namespace WorldAPI
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
            //TODO: Add Swashbuckle.aspnetcore package, and configure Swagger to look at the XmlComments above our methods
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WorldDB API", Version = "v1" });
                c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "WorldAPI.xml"));
            });

            /**** DEPENDENCY INJECTION *****/
            // First, find the connection string in AppSettings.json using the Configuration object
            string connectionString = Configuration.GetConnectionString("World");

            // Setup DI for CityDAO
            services.AddTransient<ICityDAO, CitySqlDAO>((x) => new CitySqlDAO(connectionString));




            //Add Cors support to the service
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //services.AddCors();

            //var policy = new CorsPolicy();

            //policy.Headers.Add("*");
            //policy.Methods.Add("*");
            //policy.Origins.Add("*");
            //policy.SupportsCredentials = true;

            //services.ConfigureCors(x => x.AddPolicy("mypolicy", policy));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Adding Swagger and SwaggerUI
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorldDB API v1");
            });

            app.UseCors("MyPolicy");

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
