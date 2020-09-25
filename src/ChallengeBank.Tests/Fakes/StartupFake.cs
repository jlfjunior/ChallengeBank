using ChallengeBank.Api;
using ChallengeBank.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ChallengeBank.Tests.Fakes
{
    public class StartupFake : WebApplicationFactory<Startup>
    {
        private bool _initialize;
        private IServiceScope _serviceScope;

        public Context DbContext => Resolve<Context>();

        public T Resolve<T>()
        {
            if (!_initialize)
            {
                _serviceScope = Services.CreateScope();
                _initialize = true;
            }
            
            return _serviceScope.ServiceProvider.GetRequiredService<T>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<Context>));

                services.Remove(descriptor);

                services.AddDbContext<Context>(options =>
                {
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                }, ServiceLifetime.Singleton);

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<Context>();
                    db.Database.EnsureCreated();
                }
            });
        }
    }
}
