using System;
using System.Collections.Generic;
using System.Text;
using Yomi.Blog.Domain.Configurations;

namespace Yomi.Blog.ToolKits.GitHub
{
    public class AuthorizeRequest
    {
        public string Client_ID = GitHubConfig.Client_ID;

        public string Redirect_Uri = GitHubConfig.Redirect_Uri;

        public string State { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 该参数可选，需要调用Github哪些信息，可以填写多个，以逗号分割，比如：scope=user,public_repo。
        /// 如果不填写，那么你的应用程序将只能读取Github公开的信息，比如公开的用户信息，公开的库(repository)信息以及gists信息
        /// </summary>
        public string Scope { get; set; } = "user,public_repo";
    }
}
