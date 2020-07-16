using System;
using System.Collections.Generic;
using System.Text;

namespace Yomi.Blog.Application.HelloWorld.Impl
{
    public class GoodByeWorldService : YomiBlogApplicationServiceBase, IGoodByeWorldService
    {
        public string GoodByeWorld()
        {
            return "GoodBye World";
        }
    }
}
