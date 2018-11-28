using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;

namespace MyWebApi.App_Start
{

    /// <summary>
    /// form认证 :若在ASP.NET应用程序使用，则该验证方式不支持跨域，因为cookie无法跨域访问
    /// </summary>
    public class FormAuthenticationFilterAttribute : AuthorizationFilterAttribute
    {
        private const string UnauthorizedMessage = "请求未授权，拒绝访问。";

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //是否允许匿名访问
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count() > 0)
            {
                base.OnAuthorization(actionContext);
                return;
            }

            //验证已登录
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                base.OnAuthorization(actionContext);
                return;
            }

            var cookie = actionContext.Request.Headers.GetCookies();
            if (!(cookie != null && cookie.Count > 0))
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized) {
                     Content= new StringContent(UnauthorizedMessage,System.Text.Encoding.UTF8)
                };
                return;
            }

            FormsAuthenticationTicket ticket = GetTicket(cookie);
            if (ticket == null)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized) {
                    Content = new StringContent(UnauthorizedMessage,System.Text.Encoding.UTF8)
                };
                return;
            }

            //这里可以对FormsAuthenticationTicket对象进行进一步验证

            var principal = new GenericPrincipal(new FormsIdentity(ticket),null);
            HttpContext.Current.User = principal;
            Thread.CurrentPrincipal = principal;

            base.OnAuthorization(actionContext);
        }

        private FormsAuthenticationTicket GetTicket(Collection<CookieHeaderValue> cookies)
        {
            FormsAuthenticationTicket ticket = null;
            foreach (var item in cookies)
            {
                var cookie = item.Cookies.SingleOrDefault(c=> c.Name == FormsAuthentication.FormsCookieName);
                if (cookie != null)
                {
                    ticket = FormsAuthentication.Decrypt(cookie.Value);
                    break;
                }
            }
            return ticket;
        }
    }
}