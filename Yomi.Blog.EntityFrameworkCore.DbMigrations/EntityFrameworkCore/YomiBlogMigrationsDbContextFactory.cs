using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Yomi.Blog.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class YomiBlogMigrationsDbContextFactory : IDesignTimeDbContextFactory<YomiBlogMigrationsDbContext>
    {
        public YomiBlogMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var EnableDb = configuration["ConnectionStrings:Enable"];

            var builder = new DbContextOptionsBuilder<YomiBlogMigrationsDbContext>().UseSqlServer(configuration.GetConnectionString("Default"));

            return new YomiBlogMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
