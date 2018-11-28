using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;

namespace MyWebApi.App_Start
{
    /// <summary>
    /// Basic认证
    /// </summary>
    public class HttpBasicAuthenticationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0)
            {
                base.OnAuthorization(actionContext);
                return;
            }

            if (Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                base.OnAuthorization(actionContext);
                return;
            }

            string authParameter = null;

            var authValue = actionContext.Request.Headers.Authorization;

            if (authValue != null && authValue.Scheme == "BasicAuth")
            {
                authParameter = authValue.Parameter;
            }

            if (string.IsNullOrWhiteSpace(authParameter)|| authParameter =="undefined")
            {
                Challenge(actionContext);
                return;
            }

            //解密用户ticket,并校验用户名密码是否匹配
            if (!ValidateTicket(authParameter))
            {
                Challenge(actionContext);
                return;
            }
            
            base.OnAuthorization(actionContext);
        }

        private bool ValidateTicket(string encryptTicket)
        {
            //解密Ticket
            var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;

            //从Ticket里面获取用户名和密码
            var index = strTicket.IndexOf(":");
            string strUser = strTicket.Substring(0, index);
            string strPwd = strTicket.Substring(index + 1);

            var match = strUser == "admin" && strPwd == "123456";
            if (match)
            {
                var principal = new GenericPrincipal(new GenericIdentity(strUser), null);
                Thread.CurrentPrincipal = principal;
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.User = principal;
                }
            }
            return match;
        }

        private void Challenge(HttpActionContext actionContext)
        {
            var host = actionContext.Request.RequestUri.DnsSafeHost;
            actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "请求未授权，拒绝访问");
            actionContext.Response.Headers.WwwAuthenticate.Add(new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", $"realm={host}"));
        }
    }
}