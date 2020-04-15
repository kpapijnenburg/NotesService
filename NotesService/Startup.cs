using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotesService.DAL.Service;
using NotesService.DAL;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

            // TODO: Verplaats naar enviroment variable
            var connection = @"Server=notes-db;Database=NotesDB;User=sa;Password=P4ssword!;";
                       
            services.AddDbContext<NotesContext>
                (options => options
                .UseSqlServer(connection));

            services.AddTransient<INotesService, NoteService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NotesContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Kan onverwachte resultaten opleveren.
            if (env.IsDevelopment() || env.IsProduction())
            {
                context.Database.Migrate();
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
