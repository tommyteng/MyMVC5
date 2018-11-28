using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using MyWebApi.Models.jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MyWebApi.App_Start
{
    /// <summary>
    /// Jwt过滤器
    /// </summary>
    public class JwtAuthorizeFilterAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Where(t => t.Key == "auth").FirstOrDefault().Value;
            if (authHeader != null) {
                string token = authHeader.FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(token)) {
                    try
                    {
                        const string secret = "To Live is to change the world";
                        //secret 需要加密
                        IJsonSerializer serializer = new JsonNetSerializer();
                        IDateTimeProvider provider = new UtcDateTimeProvider();
                        IJwtValidator validator = new JwtValidator(serializer, provider);
                        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                        IJwtDecoder decoder = new JwtDecoder(serializer, validator,urlEncoder);
                        var json = decoder.DecodeToObject<AuthInfo>(token,secret,true);
                        if (json != null)
                        {
                            actionContext.RequestContext.RouteData.Values.Add("auth", json);
                            return true;
                        }
                        return false;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}