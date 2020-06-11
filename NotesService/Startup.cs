using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotesService.DAL.Service;
using NotesService.DAL;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using BIED.Messaging.Config;
using BIED.Messaging.Extensions;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BIED.Messaging.Abstractions;
using NotesService.Messaging;

namespace NotesService
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings
                .ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowLocalHost", builder => builder.WithOrigins("http://localhost:8080", "http://127.0.0.1:8080").AllowAnyHeader().AllowAnyMethod());
            });

            //if (Environment.IsProduction())
            //{
            //    services.AddDbContext<NotesContext>
            //        (options => options
            //            .UseSqlServer(Configuration.GetConnectionString("NotesContext")));

            //    services.AddTransient<INotesService, NoteService>();

            //    services.Configure<RabbitMqConfig>(Configuration.GetSection("RabbitMq"));
            //    services.AddRabbitMq();
            //}

            services.AddDbContext<NotesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalDB")));

            services.AddTransient<INotesService, NoteService>();

            services.AddTransient<IMessageProducer, DummyMessageProducer>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };

                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NotesContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Kan onverwachte resultaten opleveren.
            if (env.IsProduction())
            {
                context.Database.Migrate();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowLocalHost");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
