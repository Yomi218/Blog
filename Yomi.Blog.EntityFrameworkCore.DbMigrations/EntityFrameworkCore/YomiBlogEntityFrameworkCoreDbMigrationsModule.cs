using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Yomi.Blog.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    [DependsOn(typeof(YomiBlogFrameworkCoreModule))]
    public class YomiBlogEntityFrameworkCoreDbMigrationsModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<YomiBlogMigrationsDbContext>();
        }
    }
}
