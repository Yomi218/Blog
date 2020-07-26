using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yomi.Blog.Swagger.Filters
{
    /// <summary>
    /// 对应controller的API文档描述信息
    /// </summary>
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var tags = new List<OpenApiTag>
            {
                new OpenApiTag
                {
                    Name="Blog",
                    Description="个人博客相关接口",
                    ExternalDocs=new OpenApiExternalDocs
                    {
                        Description="包含：文章/标签/分类/友情链接"
                    }
                },
                new OpenApiTag
                {
                    Name="Auth",
                    Description="JWT模式认证授权",
                    ExternalDocs=new OpenApiExternalDocs{Description="JSON Web Token"}
                }
            };

            //按照Name升序排列
            swaggerDoc.Tags = tags.OrderBy(x => x.Name).ToList();
        }
    }
}
