using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApi.Models.jwt
{
    /// <summary>
    /// 登录返回体
    /// </summary>
    public class LoginResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// jwtToken
        /// </summary>
        public string Token { get; set; }
  
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }
}