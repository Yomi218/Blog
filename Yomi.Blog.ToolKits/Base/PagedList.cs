using System.Collections.Generic;
using Yomi.Blog.ToolKits.Base.Paged;

namespace Yomi.Blog.ToolKits.Base
{
    public class PagedList<T> : ListResult<T>, IPagedList<T>
    {
        public int Total { get; set; }

        public PagedList()
        {

        }

        public PagedList(int total, IReadOnlyList<T> result) : base(result)
        {
            Total = total;
        }
    }
}
