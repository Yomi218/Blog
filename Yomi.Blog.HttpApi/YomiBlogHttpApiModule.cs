using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Yomi.Blog.Application;

namespace Yomi.Blog.HttpApi
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(YomiBlogApplicationModule)
        )]
    public class YomiBlogHttpApiModule : AbpModule
    {
        
    }
}
