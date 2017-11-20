using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Models;
using Common;


namespace HotelWebProject.Adminhyl.Recruitment
{
    public partial class RecruitmentModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string postId = Request.QueryString["PostId"];
                if (postId != null && postId != "")
                {
                    Models.Recruitment objRec = new DAL.RecruitmentService().GetPostById(postId);

                    this.ltaPostId.Text = objRec.PostId.ToString();
                    this.txtPostName.Text = objRec.PostName;
                    this.ddlPostType.Text = objRec.PostType;
                    this.ddlwork.Text = objRec.Experience;
                    this.ddlEducation.Text = objRec.EduBackground;
                    this.txtCount.Text = objRec.RequireCount.ToString();
                    this.txtPlace.Text = objRec.PostPlace;

                    this.txtDesc.Value = objRec.PostDesc;
                    this.txtRequire.Value = objRec.PostRequire;

                    this.txtManager.Text = objRec.Manager;
                    this.txtPhone.Text = objRec.PhoneNumber;
                    this.txtEmail.Text = objRec.Email;
                }
            }
            this.ltaMsg.Text = "";
        }
        /// <summary>
        /// 提交修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPublish_Click(object sender, EventArgs e)
        {
        
            //数据验证
            string PostName = this.txtPostName.Text.Trim();
            if (PostName.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入职位名称!')</script>";
                return;
            }
            if (this.ddlPostType.SelectedIndex == -1)
            {
                this.ltaMsg.Text = "<script>alert('请选择职位类型!')</script>";
                return;
            }
            if (this.ddlwork.SelectedIndex == -1)
            {
                this.ltaMsg.Text = "<script>alert('请选择工作经验!')</script>";
                return;
            }
            if (this.ddlEducation.SelectedIndex == -1)
            {
                this.ltaMsg.Text = "<script>alert('请选择学历要求!')</script>";
                return;
            }

            string RequireCount = this.txtCount.Text.Trim();
            if (RequireCount.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入招聘人数!')</script>";
                return;
            }
            if (!DataValidate.IsInteger(RequireCount))
            {
                this.ltaMsg.Text = "<script>alert('招聘人数格式不正确!')</script>";
                return;
            }

            string PostPlace = this.txtPlace.Text.Trim();
            if (RequireCount.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入工作地点!')</script>";
                return;
            }

            string PostDesc = this.txtDesc.Value.Trim();
            if (PostDesc.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入职位描述!')</script>";
                return;
            }

            string PostRequire = this.txtRequire.Value.Trim();
            if (PostDesc.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入具体要求!')</script>";
                return;
            }

            string Manager = this.txtManager.Text.Trim();
            if (Manager.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入联系人!')</script>";
                return;
            }

            string PhoneNumber = this.txtPhone.Text.Trim();
            if (PhoneNumber.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入电话!')</script>";
                return;
            }

            string Email = this.txtEmail.Text.Trim();
            if (Email.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输 电子邮件!')</script>";
                return;
            }
            if (!DataValidate.IsEmail(Email))
            {
                this.ltaMsg.Text = "<script>alert('电子邮件格式不正确!')</script>";
                return;
            }

            //封装对象
            Models.Recruitment objRec = new Models.Recruitment()
            {
                PostId =  Convert.ToInt32(this.ltaPostId.Text),
                PostName = PostName,
                PostType = this.ddlPostType.SelectedItem.Value,
                Experience = this.ddlwork.SelectedItem.Value,
                EduBackground = this.ddlEducation.SelectedItem.Value,
                RequireCount = Convert.ToInt32(RequireCount),
                PostPlace = PostPlace,
                PostRequire = PostRequire,
                PostDesc = PostDesc,
                Manager =  Manager,
                PhoneNumber = PhoneNumber,
                Email = Email
                
            };


            try
            {
                new RecruitmentService().ModifyRecruitment(objRec);
                this.ltaMsg.Text = "<script>alert('修改成功')</script>";
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('修改失败"+ex.Message+"')</script>";
            }
        }
       
    }
}