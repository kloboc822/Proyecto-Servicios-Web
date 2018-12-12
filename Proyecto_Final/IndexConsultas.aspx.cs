using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexConsultas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void bitacBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("verBitacora.aspx");
    }

    protected void aeroBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MostrarAero.aspx");
    }

    protected void puertaBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("verPuerta.aspx");
    }
}