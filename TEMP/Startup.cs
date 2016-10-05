using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.SqlServer;
using System;
[assembly: OwinStartupAttribute(typeof(SSM.Startup))]
namespace SSM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);


            GlobalConfiguration.Configuration
            .UseSqlServerStorage(
                "DefaultConnection",
                new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) })
            .UseFilter(new LogFailureAttribute());

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
