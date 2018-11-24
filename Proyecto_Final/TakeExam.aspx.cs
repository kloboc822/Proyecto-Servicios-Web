using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class TakeExam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        assignatureLabel.Text = Global.examName;
        /**********************************/
        Label1Txt.Text = Global.examName;
        //SqlDataSource1.SelectParameters["topico"].DefaultValue = Global.examName;
        if (!IsPostBack)
        {
            SqlDataSource1.SelectParameters["topico"].DefaultValue = Global.examName;
        }
    }

    protected void TakeExamBtn_Click(object sender, EventArgs e)

    {
        Response.Redirect("DoExam.aspx");
    }


    protected void rbtTakeExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        Global.examName = rbtTakeExam.SelectedValue;
    }
}

