using Volo.Abp.Domain.Repositories;

namespace Yomi.Blog.Domain.Blog.Repositories
{
    public interface IPostRepository : IRepository<Post, int>
    {
    }
}
