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
    public partial class BookManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptList.DataSource = new DishBookService().GetAllDishBook();
                rptList.DataBind();
            }
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Click(object sender, EventArgs e)
        {
            LinkButton linkBtn = (LinkButton)sender;
            string bookId = linkBtn.CommandArgument;
            string orderStatus = linkBtn.CommandName;
            try
            {
                //修改预定状态
                new DishBookService().ModifyBook(bookId, orderStatus);
                this.ltaMsg.Text = "<script>alert('操作成功')</script>";
                rptList.DataSource = new DishBookService().GetAllDishBook();
                rptList.DataBind();
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('修改状态失败!" + ex.Message + "')</script>";
            }
        }

    }
}