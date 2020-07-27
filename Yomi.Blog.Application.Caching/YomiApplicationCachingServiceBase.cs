using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.DependencyInjection;

namespace Yomi.Blog.Application.Caching
{
    public class YomiApplicationCachingServiceBase:ITransientDependency
    {
        public IDistributedCache Cache { get; set; }
    }
}
