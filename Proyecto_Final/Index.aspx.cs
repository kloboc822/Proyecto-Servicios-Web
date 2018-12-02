using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PaisesBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/IndexPaises.aspx");
    }

    protected void applyScienceBtn_Click(object sender, EventArgs e)
    {
        Global.examName = "Science";
        Response.Redirect("TakeExam.aspx");
    }

    protected void applyMathBtn_Click(object sender, EventArgs e)
    {
        Global.examName = "Maths";
        Response.Redirect("TakeExam.aspx");
    }
}