using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yomi.Blog.Application.Contracts.Blog;
using Yomi.Blog.Domain.Blog;
using Yomi.Blog.Domain.Blog.Repositories;

namespace Yomi.Blog.Application.Blog.Impl
{
    public class BlogService : YomiBlogApplicationServiceBase, IBlogService
    {
        private readonly IPostRepository _postRepository;

        public BlogService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> InsertPostAsync(PostDto dto)
        {
            var entity = new Post
            {
                Title = dto.Title,
                Author = dto.Author,
                Url = dto.Url,
                Html = dto.Html,
                Markdown = dto.Markdown,
                CategoryId = dto.CategoryId,
                CreationTime = dto.CreationTime
            };

            var post = await _postRepository.InsertAsync(entity);
            return post != null;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> UpdatePostAsync(int id, PostDto dto)
        {
            var post = await _postRepository.GetAsync(id);
            var post2 = await _postRepository.FindAsync(id);

            post.Title = dto.Title;
            post.Author = dto.Author;
            post.Url = dto.Url;
            post.Html = dto.Html;
            post.Markdown = dto.Markdown;
            post.CategoryId = dto.CategoryId;
            post.CreationTime = dto.CreationTime;

            await _postRepository.UpdateAsync(post);
            return true;
        }

        public async Task<PostDto> GetPostAsync(int id)
        {
            var post = await _postRepository.GetAsync(id);

            return new PostDto
            {
                Author = post.Author,
                CategoryId = post.CategoryId,
                CreationTime = post.CreationTime,
                Html = post.Html,
                Markdown = post.Markdown,
                Title = post.Title,
                Url = post.Url
            };
        }
    }
}
