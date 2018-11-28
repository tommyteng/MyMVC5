using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using MyWebApi.App_Start;
using MyWebApi.Models.jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApi.Controllers
{
    /// <summary>
    /// JWT 认证
    /// </summary>
    public class JWTloginController : ApiController
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">登录信息</param>
        /// <returns></returns>
        [Route("api/jwt/login")]
        public LoginResult Post([FromBody]LoginRequest request)
        {
            LoginResult rs = new LoginResult();
            if (request.UserName == "admin" && request.Password == "123456")
            {
                AuthInfo authInfo = new AuthInfo
                {
                    UserName = request.UserName,
                    Roles = new List<string> { "Admin", "Manage" },
                    IsAdmin = true
                };

                try
                {
                    const string secret = "To Live is to change the world";

                    //secret 需要加密
                    IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                    var token = encoder.Encode(authInfo, secret);
                    rs.Message = "";
                    rs.Token = token;
                    rs.Success = true;
                }
                catch (Exception ex)
                {
                    rs.Message = ex.Message;
                    rs.Success = false;
                }
            }
            else
            {
                rs.Message = "用户名或密码错误！";
                rs.Success = false;
            }
            return rs;
        }

        /// <summary>
        /// JWT get调用
        /// </summary>
        /// <returns></returns>
        [Route("api/jwt/login")]
        [JwtAuthorizeFilter]
        public string Get()
        {
            AuthInfo info = RequestContext.RouteData.Values["auth"] as AuthInfo;
            if (info == null)
            {
                return "获取不到，失败";
            }
            else
            {
                return $"获取到了，Auth的Name是 {info.UserName}";
            }
        }
    }
}
