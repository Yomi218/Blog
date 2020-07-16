using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Yomi.Blog.Domain.Blog;
using Yomi.Blog.Domain.Blog.Repositories;

namespace Yomi.Blog.EntityFrameworkCore.Repositories.Blog
{
    public class PostRepository : EfCoreRepository<YomiBlogDbContext, Post, int>, IPostRepository
    {
        public PostRepository(IDbContextProvider<YomiBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
