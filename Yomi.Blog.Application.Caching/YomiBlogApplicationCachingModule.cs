using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using Yomi.Blog.Domain;

namespace Yomi.Blog.Application.Caching
{
    [DependsOn(typeof(AbpCachingModule),
        typeof(YomiBlogDomainModule))]
    public class YomiBlogApplicationCachingModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}
