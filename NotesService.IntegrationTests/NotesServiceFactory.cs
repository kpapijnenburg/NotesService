using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using notes_service.Context;

namespace NotesService.IntegrationTests
{
    class NotesServiceFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                services.AddSingleton<INotesContext, DummyNotesContext>();
            });

            base.ConfigureWebHost(builder);
        }
    }
}
