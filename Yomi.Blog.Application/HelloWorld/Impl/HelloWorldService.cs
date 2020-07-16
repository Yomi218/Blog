
namespace Yomi.Blog.Application.HelloWorld.Impl
{
    public class HelloWorldService : YomiBlogApplicationServiceBase, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World!";
        }
    }
}
