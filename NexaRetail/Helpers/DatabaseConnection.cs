using Microsoft.Extensions.Configuration;
using System.IO;

namespace NexaRetail.Helpers
{
    public static class DatabaseConnection
    {
        private static readonly IConfiguration Configuration;

        static DatabaseConnection()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                    "appsettings.json",
                    optional: false,
                    reloadOnChange: true)
                .Build();
        }

        public static string ConnectionString
        {
            get
            {
                return Configuration
                    .GetConnectionString("DefaultConnection");
            }
        }
    }
}