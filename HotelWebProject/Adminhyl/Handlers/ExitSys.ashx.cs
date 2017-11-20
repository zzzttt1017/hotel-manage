using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace HotelWebProject.Adminhyl.Handlers
{
    /// <summary>
    /// ExitSys 的摘要说明
    /// 在handler中使用session，该类必须引入命名空间，同时必须实现标记接口IRequiresSessionState
    /// </summary>
    public class ExitSys : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //结束session，跳转到登录页
            context.Session.Abandon();
            context.Response.Redirect("~/Adminhyl/AdminLogin.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}