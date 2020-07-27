using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yomi.Blog.Domain.Shared;
using Yomi.Blog.ToolKits.Base;

namespace Yomi.Blog.Application.Caching.Authorize.impl
{
    public class AuthorizeCacheService : YomiApplicationCachingServiceBase,IAuthorizeCacheService
    {
        private const string KEY_GetLoginAddress = "Authorize:GetLoginAddress";

        private const string KEY_GetAccessToken = "Authorize:GetAccessToken-{0}";

        private const string KEY_GenerateToken = "Authorize:GenerateToken-{0}";

        public async Task<ServiceResult<string>> GetLoginAddressAsync(Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetLoginAddress, factory, CacheStrategy.NEVER);
        }

        public async Task<ServiceResult<string>> GetAccessTokenAsync(string code, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetAccessToken, factory, CacheStrategy.FIVE_MINUTES);
        }

        public async Task<ServiceResult<string>> GenerateTokenAsync(string access_token, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GenerateToken, factory, CacheStrategy.ONE_HOURS);
        }
    }
}
