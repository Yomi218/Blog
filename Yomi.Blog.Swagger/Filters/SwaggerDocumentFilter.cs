﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            #region 实现添加自定义描述时过滤不属于同一个分组的API

            var groupName = context.ApiDescriptions.FirstOrDefault().GroupName;

            var apis = context.ApiDescriptions.GetType().GetField("_source", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(context.ApiDescriptions) as IEnumerable<ApiDescription>;

            var controllers = apis.Where(x => x.GroupName != groupName).Select(x => ((ControllerActionDescriptor)x.ActionDescriptor).ControllerName).Distinct();

            swaggerDoc.Tags = tags.Where(x => !controllers.Contains(x.Name)).OrderBy(x => x.Name).ToList();

            #endregion
        }
    }
}
