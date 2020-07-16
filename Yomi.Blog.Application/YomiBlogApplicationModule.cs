using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Yomi.Blog.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule)
        )]
    public class YomiBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            
        }
    }
}
