using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace HotelWebProject.Adminhyl
{
    public partial class DishesManager : System.Web.UI.Page
    {

        private DishService objService = new DishService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //下拉框绑定
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataSource = objService.GetAllCategory();
                ddlCategory.DataBind();

                //显示所有菜品
                rptList.DataSource = objService.GetDishes(null);
                rptList.DataBind();
            }
        }

        //根据菜品分类id查询
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            rptList.DataSource = objService.GetDishes(this.ddlCategory.SelectedValue.ToString());
            rptList.DataBind();
        }
        //删除菜品
        protected void btnDel_Click(object sender, EventArgs e)
        {
            string dishId = ((LinkButton)sender).CommandArgument;
            try
            {
                objService.DeleteDish(dishId);
                //刷新
                rptList.DataSource = objService.GetDishes(null);
                rptList.DataBind();
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('删除失败!"+ex.Message+"')</script>";
            }
            
        }
    }
}