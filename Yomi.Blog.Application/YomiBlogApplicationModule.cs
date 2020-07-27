using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Yomi.Blog.Application.Caching;

namespace Yomi.Blog.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(YomiBlogApplicationCachingModule)
        )]
    public class YomiBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            
        }
    }
}
