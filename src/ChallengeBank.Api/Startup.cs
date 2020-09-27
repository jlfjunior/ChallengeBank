using ChallengeBank.Api.Filters;
using ChallengeBank.Infra;
using ChallengeBank.Infra.Interfaces;
using ChallengeBank.Infra.Repositories;
using ChallengeBank.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChallengeBank.Api
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
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddDbContext<Context>(options => options.UseMySql(Configuration.GetConnectionString("MySQL")));

            services.AddScoped<AuthAttribute>();

            services.AddTransient<CustomerService>();
            services.AddTransient<BankAccountService>();
            services.AddTransient<TransactionService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IBankAccountRepository, BankAccountRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IDailyBalanceRepository, DailyBalanceRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
