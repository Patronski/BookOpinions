using System;
using System.Web;

namespace BookOpinions.Handlers
{
    public class UserInfoHandler : IHttpHandler
    {
        public bool IsReusable => throw new NotImplementedException();

        public void ProcessRequest(HttpContext context)
        {
            string userAgent = context.Request.UserAgent;
            string userIp = context.Request.UserHostAddress;
            context.Response.Write($"<p>User Agent: {userAgent} </br> User IP address: {userIp}</p>");
        }
    }
}