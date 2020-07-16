﻿using Volo.Abp.Domain.Entities;

namespace Yomi.Blog.Domain.Blog
{
    /// <summary>
    /// 标签表
    /// </summary>
    public class Tag : Entity<int>
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// 展示名称
        /// </summary>
        public string DisplayName { get; set; }
    }
}
