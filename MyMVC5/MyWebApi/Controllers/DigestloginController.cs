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
    /// Digest 认证
    /// </summary>
    [Authorize]
    public class DigestloginController : ApiController
    {
        /// <summary>
        /// Digest 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        [Route("api/login3")]
        [AllowAnonymous]
        public object Get(string name,string pwd)
        {
            if (!ValidateUser(name, pwd))
            {
                return new { bRes = false };
            }

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, name, DateTime.Now,
                            DateTime.Now.AddHours(1), true, 
                             Newtonsoft.Json.JsonConvert.SerializeObject(new {
                                 username = name,
                                 realm = "testrealm@host.com",
                                 nonce = "dcd98b7102dd2f0e8b11d0f600bfb0c093",
                                 uri = "/api/login3",
                                 qop = "auth,auth-int",
                                 nc = 00000001,
                                 cnonce = "0a4f113b",
                                 response = "6629fae49393a05397450978507c4ef1",
                                 opaque = "5ccc069c403ebaf9f0171e9517f40e41"
                             }),
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
        /// Digest get调用
        /// </summary>
        /// <returns></returns>
        [Route("api/login3/values")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
