using Volo.Abp.Domain.Repositories;

namespace Yomi.Blog.Domain.Blog.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}
