using Volo.Abp.Domain.Entities;

namespace Yomi.Blog.Domain.Blog
{
    /// <summary>
    /// 友情链接表
    /// </summary>
    public class FriendLink : Entity<int>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string LinkUrl { get; set; }
    }
}
