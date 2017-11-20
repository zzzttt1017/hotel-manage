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
    public partial class NewsPublish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //判断是修改还是发布
                if (Request.QueryString["Operation"] == "0")//发布
                {
                    this.btnModify.Visible = false;
                }
                else if (Request.QueryString["Operation"] == "1")//修改
                {
                    this.btnPublish.Visible = false;
                    string newsId = Request.QueryString["newsId"].ToString();
                    ViewState["newsId"] = newsId;
                    //显示新闻内容
                    News objNews = new NewsService().GetNewsById(newsId);
                    if (objNews == null)
                    {
                        Response.Redirect("~/Adminhyl/Default.aspx");
                    }
                    else
                    {
                        this.txtContent.Value = objNews.NewsContents;
                        this.txtNewsTitle.Text = objNews.NewsTitle;
                        this.ddlCategory.SelectedValue = objNews.CategoryId.ToString();
                    }
                }
                else
                {
                    Response.Redirect("~/Adminhyl/Default.aspx");
                }
            }
            this.ltaMsg.Text = "";
        }
        //发布和修改新闻
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            //数据验证
            if (this.txtNewsTitle.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入新闻标题!')</script>";
                return;
            }
            if(this.txtContent.Value.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入新闻内容!')</script>";
                return;
            }
            if (this.ddlCategory.SelectedIndex == -1)
            {
                this.ltaMsg.Text = "<script>alert('请选择新闻分类!')</script>";
                return;
            }
            //封装新闻对象
            News objNews = new News()
            {
                NewsTitle = this.txtNewsTitle.Text.Trim(),
                CategoryId = Convert.ToInt32(this.ddlCategory.SelectedValue),
                NewsContents = this.txtContent.Value
            };

            if (ViewState["newsId"] != null)
            {
                objNews.NewsId = Convert.ToInt32(ViewState["newsId"]);
            }
            //提交数据
            try
            {
                if (this.btnPublish.Visible)//发布新闻
                {
                    new NewsService().PublishNews(objNews);
                    this.ltaMsg.Text = "<script>alert('发布成功!')</script>";
                    //清除已输入内容
                    this.txtContent.Value = "";
                    this.txtNewsTitle.Text = "";
                    this.ddlCategory.SelectedIndex = -1;
                }
                else//修改
                {
                    new NewsService().ModifyNews(objNews);
                    this.ltaMsg.Text = "<script>alert('修改成功!')</script>;location.href='/Adminhyl/News/NewsManager.aspx'";
                 
                }

            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('提交失败!" +ex.Message+"')</script>";
                throw;
            }

        }       
    }
}