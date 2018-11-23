using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyMVC5.Web.Controllers
{
    /// <summary>
    /// 遗留： 
    /// 1、跨域问题解决：CORS的使用
    /// 2、swagger的接入及介绍
    /// 3、webapi认证方式：windows，form，basic，Digest 
    /// Basic基础认证与Digest摘要认证流程基本相同，区别在于：Basic是将密码直接base64编码(明文),而Digest是用MD5进行加密后传输。
    /// http://www.cnblogs.com/zuowj/p/5123943.html
    /// 扩展内容：
    /// 4、四大filter介绍
    /// 5、JWT认证
    /// 
    /// 用户
    /// </summary>
    public class UsersController : ApiController
    {
        // GET: api/Users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
