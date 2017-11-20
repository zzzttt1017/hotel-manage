using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Common;
using DAL;


namespace HotelWebProject.CompanyInfo
{
    public partial class Suggestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ltaMsg.Text = "";
        }
        /// <summary>
        /// 投诉建议
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSubmit_Click(object sender, EventArgs e)
        {
            string customerName = this.txtCustomerName.Text.Trim();
            if (customerName.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入客户名称')</script>";
                return;
            }
            string consumeDesc = this.txtConsumeDesc.Text.Trim();
            if (consumeDesc.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入消费情况')</script>";
                return;
            }
            string customerPhone = this.txtPhoneNumber.Text.Trim();
            if (customerPhone.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入联系电话')</script>";
                return;
            }
            string email = this.txtEmail.Text.Trim();
            if (email.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入邮件地址')</script>";
                return;
            }
            string suggestionDesc = this.txtSuggestion.Text.Trim();
            if (suggestionDesc.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入投诉建议')</script>";
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

            Models.Suggestion sug = new Models.Suggestion()
            {
                CustomerName = customerName,
                ConsumeDesc = consumeDesc,
                PhoneNumber = customerPhone,
                Email = email,
                SuggestionDesc = suggestionDesc
            };

            try
            {
                new SuggestionService().SubmitSuggestion(sug);
                this.ltaMsg.Text = "<script>alert('投诉建议成功');location.href='/Default.aspx'</script>";
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('投诉建议失败" + ex.Message + "')</script>";
            }
        }

    }
}