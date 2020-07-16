using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Yomi.Blog.Domain
{
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public class YomiBlogDomainModule:AbpModule
    {

    }
}
