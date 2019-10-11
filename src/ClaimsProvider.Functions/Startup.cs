using System;
using ClaimsProvider.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ClaimsProvider.Functions.Startup))]

namespace ClaimsProvider.Functions
{
    public class Startup : FunctionsStartup
    {
        internal static string SqlConnectionString =>
            Environment.GetEnvironmentVariable("SqlConnection", EnvironmentVariableTarget.Process);

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContextPool<ClaimsProviderContext>(options =>
            {
                options.UseSqlServer(
                    SqlConnectionString, 
                    sqlOptions => sqlOptions.EnableRetryOnFailure());
            });
        }
    }
}
