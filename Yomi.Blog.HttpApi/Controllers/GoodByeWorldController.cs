using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc;
using Yomi.Blog.Application.HelloWorld;

namespace Yomi.Blog.HttpApi.Controllers
{
    [ApiController]
    [Route("goodBye")]
    public class GoodByeWorldController: AbpController
    {
        private readonly IGoodByeWorldService _goodByeWorldService;

        public GoodByeWorldController(IGoodByeWorldService goodByeWorldService)
        {
            _goodByeWorldService = goodByeWorldService;
        }

        [HttpGet]
        public string HelloWorld()
        {
            return _goodByeWorldService.GoodByeWorld();
        }
    }
}
