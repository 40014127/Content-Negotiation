using Content.Controllers;
using Content.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;
using WebApplication1;

namespace Content
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
            //Add       
            // services.AddControllers().AddXmlDataContractSerializerFormatters();
            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;

                config.OutputFormatters.Add(new
            MyCustomOutputFormatter());

                //.Add(MediaTypeHeaderValue.Parse("text/vcard"));

            });

         //   services.AddControllers();

            //    var contact = new OpenApiContact()
            //    {
            //        Name = "FirstName LastName",
            //        Email = "user@example.com",
            //        Url = new Uri("http://www.example.com")
            //    };

            //    var license = new OpenApiLicense()
            //    {
            //        Name = "My License",
            //        Url = new Uri("http://www.example.com")
            //    };

            //    var info = new OpenApiInfo()
            //    {
            //        Version = "v1",
            //        Title = "Swagger Demo API",
            //        Description = "Swagger Demo API Description",
            //        TermsOfService = new Uri("http://www.example.com"),
            //        Contact = contact,
            //        License = license
            //    };

            //    services.AddSwaggerGen(c =>
            //    {
            //        c.SwaggerDoc("v1", info);

            //});
            // services.AddControllers();
            services.AddSwagger();
            IServiceCollection serviceCollection = services.AddDbContext<DbContext>(op => op.UseSqlServer(Configuration.GetConnectionString("WebApi")));

            //services.AddDbContext<TodoContext>(opt =>
            //                               opt.UseInMemoryDatabase("TodoList"));
            //services.AddControllers();
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
            app.UseCustomSwagger();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
