using Yomi.Blog.Domain.Blog;
using Yomi.Blog.Domain.Blog.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Yomi.Blog.EntityFrameworkCore.Repositories.Blog
{
    public class CategoryRepository : EfCoreRepository<YomiBlogDbContext, Category, int>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<YomiBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
