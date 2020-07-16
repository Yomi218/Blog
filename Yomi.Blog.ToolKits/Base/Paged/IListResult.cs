using System;
using System.Collections.Generic;
using System.Text;

namespace Yomi.Blog.ToolKits.Base.Paged
{
    /// <summary>
    /// 返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListResult<T>
    {
        IReadOnlyList<T> Item { get; set; }
    }
}
