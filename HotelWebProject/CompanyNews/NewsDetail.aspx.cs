using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Models;


namespace HotelWebProject.CompanyNews
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string newsId = Request.Params["NewsId"];
                if (!String.IsNullOrEmpty(newsId))
                {
                    News news = new NewsService().GetNewsById(newsId);
                    if (news == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        this.ltaNewsTitle.Text = news.NewsTitle;
                        this.ltaPublishTime.Text = news.PublishTime.ToShortDateString();
                        this.ltaNewsContents.Text = news.NewsContents;
                             
                    }
                }
            }
        }
    }
}