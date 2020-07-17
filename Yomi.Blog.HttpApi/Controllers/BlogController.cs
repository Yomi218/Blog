using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Yomi.Blog.Application.Blog;
using Yomi.Blog.Application.Contracts.Blog;
using Yomi.Blog.Domain.Shared;
using Yomi.Blog.ToolKits.Base;

namespace Yomi.Blog.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : AbpController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost]
        [ApiExplorerSettings(GroupName =Grouping.GroupName_v1)]
        public async Task<ServiceResult<string>> InsertPostAsync([FromBody] PostDto dto)
        {
            return await _blogService.InsertPostAsync(dto);
        }

        [HttpDelete]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v1)]
        public async Task<ServiceResult> DeletePostAsync([Required] int id)
        {
            return await _blogService.DeletePostAsync(id);
        }

        [HttpPut]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v1)]
        public async Task<ServiceResult<string>> UpdatePostAsync([Required] int id, [FromBody] PostDto dto)
        {
            return await _blogService.UpdatePostAsync(id, dto);
        }

        [HttpGet]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v1)]
        public async Task<ServiceResult<PostDto>> GetPostAsync([Required] int id)
        {
            return await _blogService.GetPostAsync(id);
        }
    }
}
