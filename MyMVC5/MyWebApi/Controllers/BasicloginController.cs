using MyWebApi.App_Start;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace MyWebApi.Controllers
{
    /// <summary>
    /// Basic认证
    /// </summary>
    [HttpBasicAuthenticationFilter]
    public class BasicloginController : ApiController
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/login2")]
        [AllowAnonymous]
        public object Get(string name, string pwd)
        {
            if (!ValidateUser(name, pwd))
            {
                return new { bRes = false };
            }

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, name, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}:{1}", name, pwd),
                            FormsAuthentication.FormsCookiePath);

            var oUser = new UserInfo { bRes = true, UserName = name, Password = pwd, Ticket = FormsAuthentication.Encrypt(ticket) };

            HttpContext.Current.Session[name] = oUser;
            return oUser;
        }

        private bool ValidateUser(string strUser, string strPwd)
        {
            return (strUser == "admin" && strPwd == "123456");
        }
        /// <summary>
        /// get调用
        /// </summary>
        /// <returns></returns>
        [Route("api/login2/values")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
