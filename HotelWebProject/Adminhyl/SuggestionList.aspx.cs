using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace HotelWebProject.Adminhyl
{
    public partial class SuggestionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptList.DataSource = new SuggestionService().GetSuggestion();
                rptList.DataBind();
            }
        }

        /// <summary>
        /// 受理投诉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOperation_Click(object sender, EventArgs e)
        {
            string suggestionId = ((LinkButton)sender).CommandArgument;
            try
            {
                new SuggestionService().HandlerSuggestion(suggestionId);
                this.ltaMsg.Text = "<script>alert('受理成功')</script>";
                rptList.DataSource = new SuggestionService().GetSuggestion();
                rptList.DataBind();
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('受理成功"+ex.Message+"')</script>";
            }
        }

    }
}