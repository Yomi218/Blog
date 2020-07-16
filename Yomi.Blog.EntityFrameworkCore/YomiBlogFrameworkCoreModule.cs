using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using Yomi.Blog.Domain;
using Yomi.Blog.Domain.Configurations;

namespace Yomi.Blog.EntityFrameworkCore
{
    [DependsOn(
        typeof(YomiBlogDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule)
        )]
    public class YomiBlogFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<YomiBlogDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                switch (AppSettings.EnableDb)
                {
                    case "SqlServer":
                        options.UseSqlServer();
                        break;
                    default:
                        options.UseSqlServer();
                        break;
                }
            });
        }
    }
}
