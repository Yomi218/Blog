using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Yomi.Blog.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class YomiBlogMigrationsDbContext:AbpDbContext<YomiBlogMigrationsDbContext>
    {
        public YomiBlogMigrationsDbContext(DbContextOptions<YomiBlogMigrationsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}
