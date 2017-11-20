using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;


namespace HotelWebProject.Adminhyl
{
    public partial class Adminhyl : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SysAdmin"] == null)
            {
                //未登录，重定向到登录页面
                Response.Redirect("~/Adminhyl/AdminLogin.aspx");
            }
            else
            {
                ltaAdmin.Text = "[当前用户：" + ((SysAdmin)Session["SysAdmin"]).LoginName + "]";
            }
        }
    }
}