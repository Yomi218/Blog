using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Yomi.Blog.EntityFrameworkCore;
using Yomi.Blog.Swagger;
using Microsoft.IdentityModel.Tokens;
using System;
using Yomi.Blog.Domain.Configurations;
using Microsoft.AspNetCore.Http;
using Yomi.Blog.ToolKits.Base;
using Yomi.Blog.ToolKits.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Yomi.Blog.HttpApi.Hosting.Filters;

namespace Yomi.Blog.HttpApi.Hosting
{
    [DependsOn(
       typeof(AbpAspNetCoreMvcModule),
       typeof(AbpAutofacModule),
        typeof(YomiBlogHttpApiModule),
        typeof(YomiBlogSwaggerModule),
        typeof(YomiBlogFrameworkCoreModule)
    )]
    public class YomiBlogHttpApiHostingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(30),
                    ValidateIssuerSigningKey = true,
                    ValidAudience = AppSettings.JWT.Domain,
                    ValidIssuer = AppSettings.JWT.Domain,
                    IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())
                };

                //应用程序提供的对象，用于处理承载引发的事件，身份验证处理程序
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                      {
                        // 跳过默认的处理逻辑，返回下面的模型数据
                        context.HandleResponse();

                          context.Response.ContentType = "application/json;charset=utf-8";
                          context.Response.StatusCode = StatusCodes.Status200OK;

                          var result = new ServiceResult();
                          result.IsFailed("UnAuthorized");

                          await context.Response.WriteAsync(result.ToJson());
                      }
                };
            });

            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                // 移除 AbpExceptionFilter
                options.Filters.Remove(filterMetadata);

                //添加自己实现的YomiBlogExceptionFilter
                options.Filters.Add(typeof(YomiBlogExceptionFilter));
            });

            //认证授权
            context.Services.AddAuthorization();

            //http请求
            context.Services.AddHttpClient();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }

            // 路由
            app.UseRouting();

            // 身份验证
            app.UseAuthentication();

            // 认证授权
            app.UseAuthorization();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}