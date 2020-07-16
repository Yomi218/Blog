﻿using Volo.Abp.Domain.Entities;

namespace Yomi.Blog.Domain.Blog
{
    /// <summary>
    /// 分类表
    /// </summary>
    public class Category : Entity<int>
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 展示名称
        /// </summary>
        public string DisplayName { get; set; }
    }
}
