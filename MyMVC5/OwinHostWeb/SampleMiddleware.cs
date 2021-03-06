﻿using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinHostWeb
{
    public class SampleMiddleware : OwinMiddleware
    {
        object m_Options;
        public SampleMiddleware(OwinMiddleware next)
            : base(next) 
        {
            
        }

        public override Task Invoke(IOwinContext context)
        {
            PathString tickPath = new PathString("/tick");
            //判断Request路径为/tick开头
            if (context.Request.Path.StartsWithSegments(tickPath))
            {
                string content = DateTime.Now.Ticks.ToString();
                //输出答案--当前的Tick数字
                context.Response.ContentType = "text/plain";
                context.Response.ContentLength = content.Length;
                context.Response.StatusCode = 200;
                context.Response.Expires = DateTimeOffset.Now;
                context.Response.Write(content);
                //解答者告诉Server解答已经完毕,后续Middleware不需要处理
                return Task.FromResult(0);
            }
            else
                //如果不是交给后续的Middleware处理
                return Next.Invoke(context);
        }

    }
}
