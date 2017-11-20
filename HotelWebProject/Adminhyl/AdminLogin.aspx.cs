using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using DAL;


namespace HotelWebProject.Adminhyl
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //登录
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            //调用后台数据访问实现用户登录
            string loginId = this.txtLoginId.Text;
            string loginPwd = this.txtLoginPwd.Text;
            SysAdmin objAdmin = new SysAdminService().AdminLogin(loginId, loginPwd);
            if (objAdmin == null)
            {
                this.ltaMsg.Text = "<script>alert('用户名或密码错误')</script>";
            }
            else
            {
                //登录成功
                Session["SysAdmin"] = objAdmin;
                Response.Redirect("./Default.aspx");
            }
        }

     
    }
}