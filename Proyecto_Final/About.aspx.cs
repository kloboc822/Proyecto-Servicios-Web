using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void contactoBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://www.facebook.com/jorge.solanotrejos");
    }

    protected void contacto2Btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://www.facebook.com/jorge.ugalde.545");
    }

    protected void contacto3Btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://www.facebook.com/klobocampos");
    }
}