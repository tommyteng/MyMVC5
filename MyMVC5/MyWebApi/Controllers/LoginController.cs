using MyWebApi.App_Start;
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
    /// form认证
    /// </summary>
    [FormAuthenticationFilter]
    public class LoginController : ApiController
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        [Route("api/login")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Get(string name,string pwd)
        {
            if ("admin".Equals(name) && "123456".Equals(pwd))
            {
                //创建票据
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddMinutes(30), false, "",
                    FormsAuthentication.FormsCookiePath);

                //加密票据
                string authTicket = FormsAuthentication.Encrypt(ticket);

                //存储为cookie
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, authTicket);
                cookie.Path = FormsAuthentication.FormsCookiePath;
                HttpContext.Current.Response.AppendCookie(cookie);

                //or
                //FormsAuthentication.SetAuthCookie(name, false, "/");

                return Request.CreateResponse(HttpStatusCode.OK, "登录成功！");
            }
            else
            {
                HttpContext.Current.Response.AppendCookie(new HttpCookie(FormsAuthentication.FormsCookieName) {
                    Expires = DateTime.Now.AddDays(-10)
                });

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "登录失败，无效的用户名或密码！");
            }
        }
        /// <summary>
        /// GetValues
        /// </summary>
        /// <returns></returns>
        [Route("api/login/values")]
        public IEnumerable<string> GetValues()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
