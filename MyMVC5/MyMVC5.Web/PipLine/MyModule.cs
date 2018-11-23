using System;
using System.Web;

namespace MyMVC5.Web.PipLine
{
    public class MyModule : IHttpModule
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此模块
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication application)
        {
            application.AcquireRequestState += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "AcquireRequestState        "));
            application.AuthenticateRequest += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "AuthenticateRequest        "));
            application.AuthorizeRequest += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "AuthorizeRequest           "));
            application.BeginRequest += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "BeginRequest               "));
            application.Disposed += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "Disposed                   "));
            application.EndRequest += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "EndRequest                 "));
            application.Error += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "Error                      "));
            application.LogRequest += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "LogRequest                 "));
            application.MapRequestHandler += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "MapRequestHandler          "));
            application.PostAcquireRequestState += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "PostAcquireRequestState    "));
            application.PostAuthenticateRequest += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "PostAuthenticateRequest    "));
            application.PostAuthorizeRequest += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "PostAuthorizeRequest       "));
            application.PostLogRequest += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "PostLogRequest             "));
            application.PostMapRequestHandler += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "PostMapRequestHandler      "));
            application.PostReleaseRequestState += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "PostReleaseRequestState    "));
            application.PostRequestHandlerExecute += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "PostRequestHandlerExecute  "));
            application.PostResolveRequestCache += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "PostResolveRequestCache    "));
            application.PostUpdateRequestCache += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "PostUpdateRequestCache     "));
            application.PreRequestHandlerExecute += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "PreRequestHandlerExecute   "));
            application.PreSendRequestContent += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "PreSendRequestContent      "));
            application.PreSendRequestHeaders += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "PreSendRequestHeaders      "));
            application.ReleaseRequestState += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "ReleaseRequestState        "));
            application.RequestCompleted += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "RequestCompleted           "));
            application.ResolveRequestCache += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "ResolveRequestCache        "));
            application.UpdateRequestCache += (s, e) => application.Response.Write(string.Format("<h3 style='color:#00f'>来自MyModule 的处理，{0}请求到达 {1}</h3><hr>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), "UpdateRequestCache         "));
        }

        #endregion
    }
}
