using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Yomi.Blog.ToolKits.Extensions;

namespace Yomi.Blog.HttpApi.Hosting
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args).UseLog4Net().ConfigureWebHostDefaults(builder =>
            {
                builder.UseIISIntegration().UseStartup<Startup>();
            }).UseAutofac().Build().RunAsync();
        }
    }
}
