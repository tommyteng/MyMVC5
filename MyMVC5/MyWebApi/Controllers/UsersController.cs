using MyWebApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyWebApi.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UsersController : ApiController
    {
        private List<Users> _userList = null;
        public UsersController()
        {
            this._userList = new List<Users>
             {
                 new Users {UserID = 1, UserName = "tommy", UserEmail = "tommy@cnblogs.com"},
                 new Users {UserID = 2, UserName = "tony", UserEmail = "tony@cnblogs.com"},
                 new Users {UserID = 3, UserName = "kate", UserEmail = "kate@cnblogs.com"}
            };
        }


        #region httpget
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [Route("api/users")]
        public IEnumerable<Users> Get()
        {
            return _userList;
        }

        /// <summary>
        /// 根据ID获取用户信息
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [Route("api/users/{id:int}")]
        public Users GetUserByID(int id)
        {
            string idParam = HttpContext.Current.Request.QueryString["id"];

            var user = _userList.FirstOrDefault(users => users.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }
        /// <summary>
        /// 根据userName获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        [Route("api/users/{userName}")]
        [HttpGet]
        public IEnumerable<Users> GetUserByName(string userName)
        {
            string userNameParam = HttpContext.Current.Request.QueryString["userName"];
            return _userList.Where(p => string.Equals(p.UserName, userName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 根据userName和id获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [Route("api/users/{userName}/{id:int}")]
        [HttpGet]
        public IEnumerable<Users> GetUserByNameId(string userName, int id)
        {
            string idParam = HttpContext.Current.Request.QueryString["id"];
            string userNameParam = HttpContext.Current.Request.QueryString["userName"];

            return _userList.Where(p => string.Equals(p.UserName, userName, StringComparison.OrdinalIgnoreCase));
        }
        /// <summary>
        /// 根据User查找用户信息
        /// </summary>
        /// <param name="user">用户实例</param>
        /// <returns></returns>
        [Route("api/users/GetUserByModel")]
        [HttpGet]
        public IEnumerable<Users> GetUserByModel(Users user)
        {
            string idParam = HttpContext.Current.Request.QueryString["UserID"];
            string userNameParam = HttpContext.Current.Request.QueryString["UserName"];
            string emai = HttpContext.Current.Request.QueryString["UserEmail"];

            return _userList;
        }
        /// <summary>
        /// 根据User查找用户信息FromUri
        /// </summary>
        /// <param name="user">用户实例</param>
        /// <returns></returns>
        [Route("api/users/GetUserByModelUri")]
        [HttpGet]
        public IEnumerable<Users> GetUserByModelUri([FromUri]Users user)
        {
            string idParam = HttpContext.Current.Request.QueryString["UserID"];
            string userNameParam = HttpContext.Current.Request.QueryString["UserName"];
            string emai = HttpContext.Current.Request.QueryString["UserEmail"];

            return _userList;
        }
        /// <summary>
        /// 根据User序列化字符串查找用户信息
        /// </summary>
        /// <param name="userString">json字符串</param>
        /// <returns></returns>
        [Route("api/users/GetUserByModelSerialize")]
        [HttpGet]
        public IEnumerable<Users> GetUserByModelSerialize(string userString)
        {
            Users user = JsonConvert.DeserializeObject<Users>(userString);
            return _userList;
        }

        /// <summary>
        /// 根据User序列化字符串查找用户信息
        /// </summary>
        /// <param name="userString">json字符串</param>
        /// <returns></returns>
        [Route("api/users/GetUserByModelSerializeWithoutGet")]
        public IEnumerable<Users> GetUserByModelSerializeWithoutGet(string userString)
        {
            Users user = JsonConvert.DeserializeObject<Users>(userString);
            return _userList;
        }

        /// <summary>
        /// 根据User序列化字符串查找用户信息  
        /// </summary>
        /// <param name="userString">json字符串</param>
        /// <returns></returns>
        [Route("api/users/Get/NoGetUserByModelSerializeWithoutGet")]   //解析成POST
        public IEnumerable<Users> NoGetUserByModelSerializeWithoutGet(string userString)
        {
            Users user = JsonConvert.DeserializeObject<Users>(userString);
            return _userList;
        }
        #endregion

        #region HttpPost
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        [Route("api/users")]
        [HttpPost]
        public Users RegisterNone()
        {
            return _userList.FirstOrDefault();
        }
        [Route("api/users/RegisterNoKey")]
        /// <summary>
        /// 通过id注册
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpPost]
        public Users RegisterNoKey([FromBody]int id)
        {
            string idParam = HttpContext.Current.Request.Form["id"];

            var user = _userList.FirstOrDefault(users => users.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }
        /// <summary>
        /// 通过id注册
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("api/users/Register")]
        [HttpPost]
        public Users Register([FromBody]int id)                                 
        {
            string idParam = HttpContext.Current.Request.Form["id"];

            var user = _userList.FirstOrDefault(users => users.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        [Route("api/users/RegisterUser")]
        [HttpPost]
        public Users RegisterUser(Users user)
        {
            string idParam = HttpContext.Current.Request.Form["UserID"];
            string nameParam = HttpContext.Current.Request.Form["UserName"];
            string emailParam = HttpContext.Current.Request.Form["UserEmail"];

            var stringContent = base.ControllerContext.Request.Content.ReadAsStringAsync().Result;
            return user;
        }

        /// <summary>
        /// 用户注册 JObject
        /// </summary>
        /// <param name="jData">用户对象</param>
        /// <returns></returns>
        [Route("api/users/RegisterObject")]
        [HttpPost]
        public string RegisterObject(JObject jData)
        {
            string idParam = HttpContext.Current.Request.Form["User[UserID]"];
            string nameParam = HttpContext.Current.Request.Form["User[UserName]"];
            string emailParam = HttpContext.Current.Request.Form["User[UserEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];
            dynamic json = jData;
            JObject jUser = json.User;
            string info = json.Info;
            var user = jUser.ToObject<Users>();

            return string.Format("{0}_{1}_{2}_{3}", user.UserID, user.UserName, user.UserEmail, info);
        }
        /// <summary>
        /// 用户注册 dynamic
        /// </summary>
        /// <param name="dynamicData">用户对象</param>
        /// <returns></returns>
        [Route("api/users/RegisterObjectDynamic")]
        [HttpPost]
        public string RegisterObjectDynamic(dynamic dynamicData)
        {
            string idParam = HttpContext.Current.Request.Form["User[UserID]"];
            string nameParam = HttpContext.Current.Request.Form["User[UserName]"];
            string emailParam = HttpContext.Current.Request.Form["User[UserEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];
            dynamic json = dynamicData;
            JObject jUser = json.User;
            string info = json.Info;
            var user = jUser.ToObject<Users>();
            return string.Format("{0}_{1}_{2}_{3}", user.UserID, user.UserName, user.UserEmail, info);
        }
        #endregion HttpPost

        #region HttpPut
        /// <summary>
        /// 注册 PUT
        /// </summary>
        /// <returns></returns>
        [Route("api/users")]
        [HttpPut]
        public Users RegisterNonePut()
        {
            return _userList.FirstOrDefault();
        }
        /// <summary>
        /// 注册 RegisterNoKeyPut
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("api/users/RegisterNoKeyPut")]
        [HttpPut]
        public Users RegisterNoKeyPut([FromBody]int id)
        {
            string idParam = HttpContext.Current.Request.Form["id"];

            var user = _userList.FirstOrDefault(users => users.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }
        /// <summary>
        ///  注册 RegisterPut
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("api/users/RegisterPut")]
        [HttpPut]
        public Users RegisterPut([FromBody]int id)                                   
        {
            string idParam = HttpContext.Current.Request.Form["id"];

            var user = _userList.FirstOrDefault(users => users.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        /// <summary>
        /// 注册 RegisterUserPut
        /// </summary>
        /// <param name="user">user</param>
        /// <returns></returns>
        [Route("api/users/RegisterUserPut")]
        [HttpPut]
        public Users RegisterUserPut(Users user)
        {
            string idParam = HttpContext.Current.Request.Form["UserID"];
            string nameParam = HttpContext.Current.Request.Form["UserName"];
            string emailParam = HttpContext.Current.Request.Form["UserEmail"];

            //var userContent = base.ControllerContext.Request.Content.ReadAsFormDataAsync().Result;
            var stringContent = base.ControllerContext.Request.Content.ReadAsStringAsync().Result;
            return user;
        }
        /// <summary>
        /// 注册 RegisterObjectPut
        /// </summary>
        /// <param name="jData">jData</param>
        /// <returns></returns>
        [Route("api/users/RegisterObjectPut")]
        [HttpPut]
        public string RegisterObjectPut(JObject jData)//可以来自FromBody   FromUri
        {
            string idParam = HttpContext.Current.Request.Form["User[UserID]"];
            string nameParam = HttpContext.Current.Request.Form["User[UserName]"];
            string emailParam = HttpContext.Current.Request.Form["User[UserEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];
            dynamic json = jData;
            JObject jUser = json.User;
            string info = json.Info;
            var user = jUser.ToObject<Users>();

            return string.Format("{0}_{1}_{2}_{3}", user.UserID, user.UserName, user.UserEmail, info);
        }
        /// <summary>
        /// 注册 RegisterObjectDynamicPut
        /// </summary>
        /// <param name="dynamicData">dynamicData</param>
        /// <returns></returns>
        [Route("api/users/RegisterObjectDynamicPut")]
        [HttpPut]
        public string RegisterObjectDynamicPut(dynamic dynamicData)//可以来自FromBody   FromUri
        {
            string idParam = HttpContext.Current.Request.Form["User[UserID]"];
            string nameParam = HttpContext.Current.Request.Form["User[UserName]"];
            string emailParam = HttpContext.Current.Request.Form["User[UserEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];
            dynamic json = dynamicData;
            JObject jUser = json.User;
            string info = json.Info;
            var user = jUser.ToObject<Users>();

            return string.Format("{0}_{1}_{2}_{3}", user.UserID, user.UserName, user.UserEmail, info);
        }
        #endregion HttpPut

        #region HttpDelete
        /// <summary>
        /// 根据id删除用户
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("api/users/{id:int}")]
        public Users Delete(int id)
        {
            return _userList.Where(item=>item.UserID== id).FirstOrDefault();
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        [Route("api/users")]
        [HttpDelete]
        public Users RegisterNoneDelete()
        {
            return _userList.FirstOrDefault();
        }
        /// <summary>
        /// 删除用户 RegisterNoKeyDelete
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("api/users/RegisterNoKeyDelete")]
        [HttpDelete]
        public Users RegisterNoKeyDelete([FromBody]int id)
        {
            string idParam = HttpContext.Current.Request.Form["id"];

            var user = _userList.FirstOrDefault(users => users.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }
        /// <summary>
        /// 删除用户 RegisterDelete
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [Route("api/users/RegisterDelete")]
        [HttpDelete]
        public Users RegisterDelete([FromBody]int id)                      
        {
            string idParam = HttpContext.Current.Request.Form["id"];

            var user = _userList.FirstOrDefault(users => users.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }
        /// <summary>
        /// 删除用户 RegisterUserDelete
        /// </summary>
        /// <param name="user">user</param>
        /// <returns></returns>
        [Route("api/users/RegisterUserDelete")]
        [HttpDelete]
        public Users RegisterUserDelete(Users user)
        {
            string idParam = HttpContext.Current.Request.Form["UserID"];
            string nameParam = HttpContext.Current.Request.Form["UserName"];
            string emailParam = HttpContext.Current.Request.Form["UserEmail"];

            //var userContent = base.ControllerContext.Request.Content.ReadAsFormDataAsync().Result;
            var stringContent = base.ControllerContext.Request.Content.ReadAsStringAsync().Result;
            return user;
        }
        /// <summary>
        /// 删除用户 RegisterObjectDelete
        /// </summary>
        /// <param name="jData">jData</param>
        /// <returns></returns>
        [Route("api/users/RegisterObjectDelete")]
        [HttpDelete]
        public string RegisterObjectDelete(JObject jData)
        {
            string idParam = HttpContext.Current.Request.Form["User[UserID]"];
            string nameParam = HttpContext.Current.Request.Form["User[UserName]"];
            string emailParam = HttpContext.Current.Request.Form["User[UserEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];
            dynamic json = jData;
            JObject jUser = json.User;
            string info = json.Info;
            var user = jUser.ToObject<Users>();

            return string.Format("{0}_{1}_{2}_{3}", user.UserID, user.UserName, user.UserEmail, info);
        }
        /// <summary>
        /// 删除用户 RegisterObjectDynamicDelete
        /// </summary>
        /// <param name="dynamicData">dynamicData</param>
        /// <returns></returns>
        [Route("api/users/RegisterObjectDynamicDelete")]
        [HttpDelete]
        public string RegisterObjectDynamicDelete(dynamic dynamicData)
        {
            string idParam = HttpContext.Current.Request.Form["User[UserID]"];
            string nameParam = HttpContext.Current.Request.Form["User[UserName]"];
            string emailParam = HttpContext.Current.Request.Form["User[UserEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];
            dynamic json = dynamicData;
            JObject jUser = json.User;
            string info = json.Info;
            var user = jUser.ToObject<Users>();

            return string.Format("{0}_{1}_{2}_{3}", user.UserID, user.UserName, user.UserEmail, info);
        }
        #endregion HttpDelete
    }
}
