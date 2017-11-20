using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Models;


namespace HotelWebProject.Adminhyl
{
    public partial class RecruitmentManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptList.DataSource = new RecruitmentService().GetAllRecList();
                rptList.DataBind();
            }
            this.ltaMsg.Text = "";
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            string postId = ((LinkButton)sender).CommandArgument;
            try
            {
                new RecruitmentService().DeleteRecruitment(postId);
                this.ltaMsg.Text = "<script>alert('删除成功')</script>";
                rptList.DataSource = new RecruitmentService().GetAllRecList();
                rptList.DataBind();
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('删除失败!" + ex.Message + "')</script>";
            }
        }
    }
}