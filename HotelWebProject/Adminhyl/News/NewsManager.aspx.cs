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
    public partial class NewsManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.rptList.DataSource = new NewsService().GetNews(50);
                this.rptList.DataBind();
            }
        }

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_Click(object sender, EventArgs e)
        {
            string newsId = ((LinkButton)sender).CommandArgument;
            try
            {
                new NewsService().DeleteNews(newsId);
                this.rptList.DataSource = new NewsService().GetNews(50);
                this.rptList.DataBind();
            }
            catch(Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('删除失败!" + ex.Message + "')</script>";
            }
         
        }

    }
}