﻿using Yomi.Blog.Application.Contracts.Blog;
using System.Threading.Tasks;
using Yomi.Blog.ToolKits.Base;

namespace Yomi.Blog.Application.Blog
{
    public interface IBlogService
    {
        Task<ServiceResult<string>> InsertPostAsync(PostDto dto);

        Task<ServiceResult> DeletePostAsync(int id);

        Task<ServiceResult<string>> UpdatePostAsync(int id, PostDto dto);

        Task<ServiceResult<PostDto>> GetPostAsync(int id);
    }
}
