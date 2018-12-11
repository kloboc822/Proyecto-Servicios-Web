using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void comprarBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/CompraBoleto.aspx");
    }

    protected void reservarBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53551/ReservaBoletos.aspx");
    }
}