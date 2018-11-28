using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApi.Models.jwt
{
    /// <summary>
    /// jwt的 payload
    /// </summary>
    public class AuthInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 角色列表，可以用于记录该用户的角色,相当于claims
        /// </summary>
        public List<string> Roles { get; set; }
        /// <summary>
        /// 是否是管理员
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}