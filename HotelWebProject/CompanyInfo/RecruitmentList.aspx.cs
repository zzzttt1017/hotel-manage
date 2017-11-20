using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace HotelWebProject.CompanyInfo
{
    public partial class RecruitmentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.rptList.DataSource = new RecruitmentService().GetAllRecList();
                this.rptList.DataBind();
            }
        }
    }
}