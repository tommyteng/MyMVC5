using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyMVC5.Web.Controllers
{
    /// <summary>
    /// 第三讲： 
    /// webapi初识：
    /// restful风格，特性路由，get、post、put、delete参数传值和接收的各种方式
    /// </summary>

    public class ValuesController : ApiController
    {
        /// <summary>
        /// 获取Value
        /// </summary>
        /// <returns>list</returns>
        [Route("api/values/v1/")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 获取Value
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [Route("api/values/{id:int}")]
        public string Get(int id)
        {
            return "value";
        }

       /// <summary>
       /// POST
       /// </summary>
        /// <param name="value">value</param>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="value">valueS</param>
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(int id)
        {
        }
    }
}
