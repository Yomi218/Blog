using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using Yomi.Blog.Domain;
using Yomi.Blog.Domain.Configurations;

namespace Yomi.Blog.Application.Caching
{
    [DependsOn(typeof(AbpCachingModule),
        typeof(YomiBlogDomainModule))]
    public class YomiBlogApplicationCachingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = AppSettings.Caching.RedisConnectionString;
            });
        }
    }
}
