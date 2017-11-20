using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Common;
using Models;


namespace HotelWebProject.Adminhyl
{
    public partial class DishesPublish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //下拉框初始化
                this.ddlCategory.DataValueField = "CategoryId";
                this.ddlCategory.DataTextField = "CategoryName";
                this.ddlCategory.DataSource = new DishService().GetAllCategory();
                this.ddlCategory.DataBind();

                //判断是修改还是新增
                if (Request.QueryString["Operation"] == "0")//新增
                {
                    this.btnEdit.Visible = false;
                }
                else if (Request.QueryString["Operation"] == "1")//修改
                {
                    this.btnPublish.Visible = false;
                    string dishId = Request.QueryString["dishId"];
                    if (string.IsNullOrEmpty(dishId))//如果没有提供该参数
                    {
                        Response.Redirect("~/Adminhyl/Default.aspx");
                        return;
                    }
                    //根据菜品编号获取菜品对象
                    Dish dish = new DishService().GetDishById(dishId);
                    if (dish == null)
                    {
                        Response.Redirect("~/Adminhyl/Default.aspx");
                        return;
                    }
                    //保存要修改的菜品id
                    ViewState["dishId"] = dishId;

                    //显示要修改的菜品信息
                    this.txtDishName.Text = dish.DishName;
                    this.txtUnitPrice.Text = dish.UnitPrice.ToString();
                    this.ddlCategory.SelectedValue = dish.CategoryId.ToString();
                    this.dishImage.ImageUrl = "~/Images/dish/" + dishId + ".png";
                }
                else
                {
                    Response.Redirect("~/Adminhyl/Default.aspx");
                    return;
                }

            }

            this.itaMsg.Text = "";

        }

        //新增菜品or修改按钮事件
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            //数据验证
            if (this.txtDishName.Text.Trim().Length == 0)
            {
                this.itaMsg.Text = "<script>alert('请输入菜品名称！')</script>";
                return;
            }
            if (this.txtUnitPrice.Text.Trim().Length == 0)
            {
                this.itaMsg.Text = "<script>alert('请输入菜品价格！')</script>";
                return;
            }
            if (this.ddlCategory.SelectedIndex == -1)
            {
                this.itaMsg.Text = "<script>alert('请输选择菜品分类！')</script>";
                return;
            }

            if (!DataValidate.IsInteger(this.txtUnitPrice.Text))
            {
                this.itaMsg.Text = "<script>alert('菜品价格必须是整数！')</script>";
                return;
            }

            //封装对象
            Dish dish = new Dish()
            {
                DishName = this.txtDishName.Text.Trim(),
                UnitPrice = Convert.ToInt32(this.txtUnitPrice.Text),
                CategoryId = Convert.ToInt32(this.ddlCategory.SelectedValue)
            };

            if (ViewState["dishId"] != null)//如果是修改则需要封装菜品编号
            {
                dish.DishId = Convert.ToInt32(ViewState["dishId"]);
            }

            try
            {
                if (this.btnPublish.Visible)//添加菜品
                {
                    if (!this.fulImage.HasFile)//如果是新增菜品，必须选择图片
                    {
                        this.itaMsg.Text = "<script>alert('请选择菜品图片！')</script>";
                        return;
                    }
                    //提交菜品信息，并返回菜品编号
                    int dishId = new DishService().AddDish(dish);
                    //上传图片
                    this.UploadImage(dishId);
                    this.itaMsg.Text = "<script>alert('添加成功！')</script>";
                    //清空输入的内容
                    this.txtDishName.Text = "";
                    this.txtUnitPrice.Text = "";
                    this.ddlCategory.SelectedIndex = -1;
                }
                else//修改
                {
                    new DishService().ModifyDish(dish);
                    this.UploadImage(dish.DishId);
                    this.itaMsg.Text = "<script>alert('修改成功！');location.href='/Adminhyl/Dishes/DishesManager.aspx'</script>";
                }
            }
            catch (Exception ex)
            {
                this.itaMsg.Text = "<script>alert('添加失败！"+ex.Message+ "')</script>";
                throw ex;
            }

        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="dishId">图片id</param>
        private void UploadImage(int dishId)
        {
            //判断是否是文件
            if (!this.fulImage.HasFile) return;
            //获取文件大小，判断是否符合要求
            double fileLength = this.fulImage.FileContent.Length / (1024.0 * 1024.0);
            if (fileLength > 2.0)
            {
                this.itaMsg.Text = "<script>alert('图片大小不能超过2M！')</script>";
                return;
            }
            //获取文件名
            string fileName = this.fulImage.FileName;
            if (fileName.Substring(fileName.LastIndexOf(".")+1).ToLower() != "png")
            {
                this.itaMsg.Text = "<script>alert('图片必须是png格式！')</script>";
                return;
            }
            fileName = dishId + ".png";

            //上传图片
            try
            {
                string path = Server.MapPath("~/Images/dish");
                this.fulImage.SaveAs(path + "/" + fileName);
            }
            catch (Exception ex)
            {
                this.itaMsg.Text = "<script>alert('图片上传失败！')</script>";
            }
        }

    }
}