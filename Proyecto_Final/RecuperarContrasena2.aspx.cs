using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecuperarContrasena2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/LogIn.aspx");
    }
}