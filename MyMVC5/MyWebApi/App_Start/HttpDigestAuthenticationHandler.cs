using MyWebApi.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace MyWebApi.App_Start
{
    public class HttpDigestAuthenticationHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                HttpRequestHeaders headers = request.Headers;
                if (headers.Authorization != null)
                {
                    Header header = new Header(request.Headers.Authorization.Parameter, request.Method.Method);
                    if (Nonce.IsValid(header.Nonce, header.NounceCounter))
                    {
                        string password = header.UserName;
                        string ha1 = String.Format("{0}:{1}:{2}", header.UserName, header.Realm, password).ToMD5Hash();
                        string ha2 = String.Format("{0}:{1}", header.Method, header.Uri).ToMD5Hash();
                        string computedResponse = String.Format("{0}:{1}:{2}:{3}:{4}:{5}",
                                            ha1, header.Nonce, header.NounceCounter, header.Cnonce, "auth", ha2).ToMD5Hash();

                        if (String.CompareOrdinal(header.Response, computedResponse) == 0)
                        {
                            var claims = new List<Claim>{
                                new Claim(ClaimTypes.Name, header.UserName),
                                new Claim(ClaimTypes.AuthenticationMethod, AuthenticationMethods.Password)
                            };

                            ClaimsPrincipal principal = new ClaimsPrincipal(new[] { new ClaimsIdentity(claims, "Digest") });
                            Thread.CurrentPrincipal = principal;
                            if (HttpContext.Current != null)
                                HttpContext.Current.User = principal;
                        }
                    }
                }

                HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Digest", Header.GetUnauthorizedResponseHeader(request).ToString()));
                }
                return response;
            }
            catch {
                var response = request.CreateResponse(HttpStatusCode.Unauthorized);
                response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Digest", Header.GetUnauthorizedResponseHeader(request).ToString()));

                return response;
            }
        }

       
    }

    public class Header
    {
        public Header() { }

        public Header(string header, string method)
        {
            string keyValuePairs = FormsAuthentication.Decrypt(header).UserData.Replace("\"", String.Empty);
            foreach (var keyValuePair in keyValuePairs.Split(','))
            {
                int index = keyValuePair.IndexOf("=", System.StringComparison.Ordinal);
                string key = keyValuePair.Substring(0, index).Trim();
                string value = keyValuePair.Substring(index + 1).Trim();

                switch (key)
                {
                    case "username": this.UserName = value; break;
                    case "realm": this.Realm = value; break;
                    case "nonce": this.Nonce = value; break;
                    case "uri": this.Uri = value; break;
                    case "nc": this.NounceCounter = value; break;
                    case "cnonce": this.Cnonce = value; break;
                    case "response": this.Response = value; break;
                    case "method": this.Method = value; break;
                }
            }

            if (String.IsNullOrEmpty(this.Method))
                this.Method = method;
        }

        public string Cnonce { get; private set; }
        public string Nonce { get; private set; }
        public string Realm { get; private set; }
        public string UserName { get; private set; }
        public string Uri { get; private set; }
        public string Response { get; private set; }
        public string Method { get; private set; }
        public string NounceCounter { get; private set; }

        public static Header GetUnauthorizedResponseHeader(HttpRequestMessage request)
        {
            var host = request.RequestUri.DnsSafeHost;
            return new Header()
            {
                Realm = host,
                Nonce = MyWebApi.Models.Nonce.Generate()
            };
        }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();
            header.AppendFormat("realm=\"{0}\"", Realm);
            header.AppendFormat(",nonce=\"{0}\"", Nonce);
            header.AppendFormat(",qop=\"{0}\"", "auth");
            return header.ToString();
        }
    }
}