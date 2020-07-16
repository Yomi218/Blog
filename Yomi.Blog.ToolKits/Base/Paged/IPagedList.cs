using System;
using System.Collections.Generic;
using System.Text;

namespace Yomi.Blog.ToolKits.Base.Paged
{
    public interface IPagedList<T>:IListResult<T>,IHasTotalCount
    {
    }
}
