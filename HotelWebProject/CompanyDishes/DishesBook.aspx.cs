using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Models;
using DAL;

namespace HotelWebProject.CompanyDishes
{
    public partial class DishesBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ltaMsg.Text = "";
        }
        /// <summary>
        /// 预定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBook_Click(object sender, EventArgs e)
        {
            //数据验证
            if (this.txtConsumeTime.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入消费时间')</script>";
                return;
            }
            if (this.txtPersons.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入消费人数')</script>";
                return;
            }
            if (!DataValidate.IsInteger(this.txtPersons.Text.Trim()))
            {
                this.ltaMsg.Text = "<script>alert('消费人数格式不正确')</script>";
                return;
            }
            if (this.txtCustomerName.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入您的姓名')</script>";
                return;
            }
            if (this.txtPhoneNumber.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入联系电话')</script>";
                return;
            }
            if (this.ddlHotelName.SelectedIndex == -1)
            {
                this.ltaMsg.Text = "<script>alert('请选择分店名称')</script>";
                return;
            }
            if (this.ddlRoomType.SelectedIndex == -1)
            {
                this.ltaMsg.Text = "<script>alert('请选择包间类型')</script>";
                return;
            }

            if (this.txtValidateCode.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入验证码')</script>";
                return;
            }

            if (this.txtValidateCode.Text.Trim() != Session["CheckCode"].ToString())
            {
                this.ltaMsg.Text = "<script>alert('验证码不正确')</script>";
                return;
            }


            DishBook dishBook = new DishBook()
            {
               HotelName = this.ddlHotelName.SelectedItem.Value,
               ConsumeTime = Convert.ToDateTime(this.txtConsumeTime.Text.Trim()),
               ConsumePersons = Convert.ToInt32(this.txtPersons.Text.Trim()),
               RoomType = this.ddlRoomType.SelectedItem.Value,
               CustomerName = this.txtCustomerName.Text.Trim(),
               CustomerPhone = this.txtPhoneNumber.Text.Trim(),
               CustomerEmail = this.txtEmail.Text.Trim(),
               Comments = this.txtComment.Text.Trim() == "" ? "无" : this.txtComment.Text.Trim(),

            };

            try
            {
                new DishBookService().Book(dishBook);
                this.ltaMsg.Text = "<script>alert('预定成功');location.href='/Default.aspx'</script>";
            }

            catch(Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('预定失败"+ex.Message+"')</script>";
            }

        }



    }
}