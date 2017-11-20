using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using DAL;


namespace HotelWebProject.CompanyInfo
{
    public partial class RecruitmentDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string postId = Request.Params["PostId"];
                if (string.IsNullOrEmpty(postId))
                {
                    Response.Redirect("/Default.aspx");
                }
                Models.Recruitment objRec = new RecruitmentService().GetPostById(postId);

                this.ltaPostName.Text = objRec.PostName;
                this.ltaPostType.Text = objRec.PostType;
                this.ltaExp.Text = objRec.Experience;
                this.ltaEduBac.Text = objRec.EduBackground;
                this.ltaRecCount.Text = objRec.RequireCount.ToString();
                this.ltaPublisTime.Text = objRec.PublishTime.ToShortDateString();
                this.ltaDesc.Text = objRec.PostDesc;
                this.ltaRequire.Text = objRec.PostRequire;
                this.ltamManager.Text = objRec.Manager;
                this.ltaPhone.Text = objRec.PhoneNumber;
                this.ltaEmail.Text = objRec.Email;

            }
        }
    }
}