using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Yomi.Blog.Domain.Shared;
using Yomi.Blog.Swagger.Filters;

namespace Yomi.Blog.Swagger
{
    public static class YomiBlogSwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("v1", new OpenApiInfo
                //{
                //    Version = "1.0.0",
                //    Title = "我的接口啊",
                //    Description = "接口描述"
                //});

                ApiInfos.ForEach(x =>
                {
                    options.SwaggerDoc(x.UrlPrefix, x.OpenApiInfo);
                });

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Yomi.Blog.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Yomi.Blog.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Yomi.Blog.Application.Contracts.xml"));

                options.DocumentFilter<SwaggerDocumentFilter>();

                var security = new OpenApiSecurityScheme
                {
                    Description = "JWT模式授权，请输入Bearer{Token}进行身份验证",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };
                options.AddSecurityDefinition("JWT", security);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { security, new List<string>() } });
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(options =>
            {
                //options.SwaggerEndpoint($"/swagger/v1/swagger.json", "默认接口");
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerEndpoint($"/swagger/{x.UrlPrefix}/swagger.json", x.Name);
                });

                // 模型的默认扩展深度，设置为 -1 完全隐藏模型
                options.DefaultModelExpandDepth(-1);

                // API文档仅展开标记
                options.DocExpansion(DocExpansion.List);

                // API前缀设置为空
                options.RoutePrefix = string.Empty;

                // API页面Title
                options.DocumentTitle = "😍接口文档 - Yomi⭐⭐⭐";
            });
        }

        internal class SwaggerApiInfo
        {
            /// <summary>
            /// URL前缀
            /// </summary>
            public string UrlPrefix { get; set; }

            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// <see cref="Microsoft.OpenApi.Models.OpenApiInfo"/>
            /// </summary>
            public OpenApiInfo OpenApiInfo { get; set; }
        }

        private static readonly List<SwaggerApiInfo> ApiInfos = new List<SwaggerApiInfo>()
        {
            new SwaggerApiInfo
            {
                UrlPrefix=Grouping.GroupName_v1,
                Name="博客前台接口",
                OpenApiInfo=new OpenApiInfo
                {
                    Version=version,
                    Title="Yomi-博客前台接口",
                    Description="分类描述..."
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix=Grouping.GroupName_v2,
                Name="博客后台接口",
                OpenApiInfo=new OpenApiInfo
                {
                    Version=version,
                    Title="Yomi-博客前台接口",
                    Description="分类描述..."
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix=Grouping.GroupName_v3,
                Name="通用公共接口",
                OpenApiInfo=new OpenApiInfo
                {
                    Version=version,
                    Title="Yomi-博客前台接口",
                    Description="分类描述..."
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix=Grouping.GroupName_v4,
                Name="JWT授权接口",
                OpenApiInfo=new OpenApiInfo
                {
                    Version=version,
                    Title="Yomi-博客前台接口",
                    Description="分类描述..."
                }
            },
        };

        private static string version = Domain.Configurations.AppSettings.ApiVersion;
    }
}